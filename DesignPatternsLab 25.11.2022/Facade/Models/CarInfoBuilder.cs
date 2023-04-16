namespace Facade.Models
{
    public class CarInfoBuilder : CarBuilderFacade
    {
        public CarInfoBuilder(Car car) 
        {
            this.car = car;
        }
        public CarInfoBuilder WithType(string type)
        {
            car.Type = type;
            return this;
        }
        public CarInfoBuilder WithColor(string color)
        {
            car.Color = color;
            return this;
        }
        public CarInfoBuilder WithNumberOfDoors(int numberOfDoors)
        {
            car.NumberOfDoors = numberOfDoors;
            return this;
        }
    }
}
