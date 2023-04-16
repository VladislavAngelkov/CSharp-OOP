using Formula1.Core.Contracts;
using Formula1.Models;
using Formula1.Models.Contracts;
using Formula1.Repositories;
using Formula1.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Formula1.Core
{
    public class Controller : IController
    {
        private readonly FormulaOneCarRepository carRepository;
        private readonly PilotRepository pilotRepository;
        private readonly RaceRepository raceRepository;

        public Controller()
        {
            carRepository = new FormulaOneCarRepository();
            pilotRepository = new PilotRepository();
            raceRepository = new RaceRepository();
        }
        public string AddCarToPilot(string pilotName, string carModel)
        {
            if (pilotRepository.FindByName(pilotName)==null || pilotRepository.FindByName(pilotName).Car!=null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.PilotDoesNotExistOrHasCarErrorMessage, pilotName));
            }

            if (carRepository.FindByName(carModel)==null)
            {
                throw new NullReferenceException(string.Format(ExceptionMessages.CarDoesNotExistErrorMessage, carModel));
            }

            var pilot = pilotRepository.FindByName(pilotName);
            var car = carRepository.FindByName(carModel);
            pilot.AddCar(car);
            carRepository.Remove(car);
            string carType = car.GetType().Name;

            return string.Format(OutputMessages.SuccessfullyPilotToCar, pilot.FullName, carType, car.Model);
        }

        public string AddPilotToRace(string raceName, string pilotFullName)
        {
            if (raceRepository.FindByName(raceName)==null)
            {
                throw new NullReferenceException(string.Format(ExceptionMessages.RaceDoesNotExistErrorMessage, raceName));
            }

            if (pilotRepository.FindByName(pilotFullName)==null 
                || !pilotRepository.FindByName(pilotFullName).CanRace 
                || raceRepository.Models.Any(r=>r.Pilots
                .Any(p=>p.FullName==pilotFullName)))
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.PilotDoesNotExistErrorMessage, pilotFullName));
            }

            var race = raceRepository.FindByName(raceName);
            var pilot = pilotRepository.FindByName(pilotFullName);
            
            race.AddPilot(pilot);

            return string.Format(OutputMessages.SuccessfullyAddPilotToRace, pilot.FullName, race.RaceName);
        }

        public string CreateCar(string type, string model, int horsepower, double engineDisplacement)
        {
            if (carRepository.FindByName(model) != null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.CarExistErrorMessage, model));
            }

            Type carType = Type.GetType($"Formula1.Models.{type}");
            
            if (carType == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InvalidTypeCar, type));
            }

            IFormulaOneCar car = Activator.CreateInstance(carType, new object[] { model, horsepower, engineDisplacement }) as IFormulaOneCar;
            carRepository.Add(car);

            return string.Format(OutputMessages.SuccessfullyCreateCar, type, model);
        }

        public string CreatePilot(string fullName)
        {
            if (pilotRepository.FindByName(fullName) != null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.PilotExistErrorMessage, fullName));
            }

            var pilot = new Pilot(fullName);
            pilotRepository.Add(pilot);

            return string.Format(OutputMessages.SuccessfullyCreatePilot, fullName);
        }

        public string CreateRace(string raceName, int numberOfLaps)
        {
            if (raceRepository.FindByName(raceName) != null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceExistErrorMessage, raceName));
            }

            var race = new Race(raceName, numberOfLaps);
            raceRepository.Add(race);

            return string.Format(OutputMessages.SuccessfullyCreateRace, raceName);
        }

        public string PilotReport()
        {
            var pilots = pilotRepository.Models.OrderByDescending(p => p.NumberOfWins);

            StringBuilder message= new StringBuilder();

            foreach (var pilot in pilots)
            {
                message.AppendLine(pilot.ToString());
            }

            return message.ToString().TrimEnd();
        }

        public string RaceReport()
        {
            StringBuilder message = new StringBuilder();

            var races = raceRepository.Models.Where(r => r.TookPlace);

            foreach (var race in races)
            {
                message.AppendLine(race.RaceInfo());
            }

            return message.ToString().TrimEnd();
        }

        public string StartRace(string raceName)
        {
            if (raceRepository.FindByName(raceName)==null)
            {
                throw new NullReferenceException(string.Format(ExceptionMessages.RaceDoesNotExistErrorMessage, raceName));
            }

            if (raceRepository.FindByName(raceName).Pilots.Count<3)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InvalidRaceParticipants, raceName));
            }

            if (raceRepository.FindByName(raceName).TookPlace)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceTookPlaceErrorMessage, raceName));
            }

            var race = raceRepository.FindByName(raceName);

            List<IPilot> pilots = race.Pilots
                .OrderByDescending(p => p.Car.RaceScoreCalculator(race.NumberOfLaps))
                .Take(3)
                .ToList();

            pilots.First().WinRace();

            StringBuilder message = new StringBuilder();
            message.AppendLine($"Pilot {pilots[0].FullName} wins the {raceName} race.");
            message.AppendLine($"Pilot {pilots[1].FullName} is second in the {raceName} race.");
            message.AppendLine($"Pilot {pilots[2].FullName} is third in the {raceName} race.");

            race.TookPlace = true;

            return message.ToString().TrimEnd();
        }
    }
}
