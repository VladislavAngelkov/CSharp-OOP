using Gym.Core.Contracts;
using Gym.Models.Athletes;
using Gym.Models.Athletes.Contracts;
using Gym.Models.Equipment;
using Gym.Models.Equipment.Contracts;
using Gym.Models.Gyms;
using Gym.Models.Gyms.Contracts;
using Gym.Repositories;
using Gym.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gym.Core
{
    public class Controller : IController
    {
        private EquipmentRepository equipment;
        private List<IGym> gyms;

        public Controller()
        {
            equipment= new EquipmentRepository();
            gyms= new List<IGym>();
        }

        public string AddAthlete(string gymName, string athleteType, string athleteName, string motivation, int numberOfMedals)
        {
            IGym gym = gyms.FirstOrDefault(g => g.Name == gymName);
            string gymType = gym.GetType().Name;

            if (athleteType == "Boxer")
            {
                if (gymType != "BoxingGym")
                {
                    return OutputMessages.InappropriateGym;
                }

                IAthlete athlete = new Boxer(athleteName, motivation, numberOfMedals);
                gym.AddAthlete(athlete);
                
            }
            else if (athleteType == "Weightlifter")
            {
                if (gymType != "WeightliftingGym")
                {
                    return OutputMessages.InappropriateGym;
                }
                IAthlete athlete = new Boxer(athleteName, motivation, numberOfMedals);
                gym.AddAthlete(athlete);
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidAthleteType);
            }

            return string.Format(OutputMessages.EntityAddedToGym, athleteType, gymName);
        }

        public string AddEquipment(string equipmentType)
        {
            if (equipmentType == "BoxingGloves")
            {
                IEquipment currEquipment = new BoxingGloves();
                equipment.Add(currEquipment);
            }
            else if (equipmentType == "Kettlebell")
            {
                IEquipment currEquipment = new Kettlebell();
                equipment.Add(currEquipment);
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidEquipmentType);
            }

            return string.Format(OutputMessages.SuccessfullyAdded, equipmentType);
        }

        public string AddGym(string gymType, string gymName)
        {
            if (gymType != "BoxingGym" && gymType != "WeightliftingGym")
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidGymType);
            }

            if (gymType == "BoxingGym")
            {
                IGym gym = new BoxingGym(gymName);
                gyms.Add(gym);
            }
            else
            {
                IGym gym = new WeightliftingGym(gymName);
                gyms.Add(gym);
            }

            return string.Format(OutputMessages.SuccessfullyAdded, gymType);
        }

        public string EquipmentWeight(string gymName)
        {
            IGym gym = gyms.FirstOrDefault(g => g.Name == gymName);
            string weight = String.Format("{0:0.00}", gym.EquipmentWeight);

            return string.Format(OutputMessages.EquipmentTotalWeight, gymName, weight);
        }

        public string InsertEquipment(string gymName, string equipmentType)
        {
            IGym gym = gyms.FirstOrDefault(g => g.Name == gymName);
            IEquipment euqip = equipment.Models.FirstOrDefault(m => m.GetType().Name == equipmentType);

            if (euqip == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InexistentEquipment, equipmentType));
            }

            gym.AddEquipment(euqip);
            equipment.Remove(euqip);

            return string.Format(OutputMessages.EntityAddedToGym, equipmentType, gymName);
        }

        public string Report()
        {
            StringBuilder message = new StringBuilder();

            foreach (var gym in gyms)
            {
                message.AppendLine(gym.GymInfo());
            }

            return message.ToString().TrimEnd();
        }

        public string TrainAthletes(string gymName)
        {
            IGym gym = gyms.FirstOrDefault(g => g.Name == gymName);

            gym.Exercise();

            int count = gym.Athletes.Count;

            return string.Format(OutputMessages.AthleteExercise, count);
        }
    }
}
