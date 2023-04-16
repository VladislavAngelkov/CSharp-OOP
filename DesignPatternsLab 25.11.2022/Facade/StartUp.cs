using Facade.Models;

var car = new CarBuilderFacade()
    .Info
    .WithType("SUV")
    .WithColor("Silver")
    .WithNumberOfDoors(5)
    .Adress
    .WithCity("Sofia")
    .WithAdress("st. Carigradsko shose")
    .Build();

Console.WriteLine(car.ToString());