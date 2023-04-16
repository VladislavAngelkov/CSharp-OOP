namespace Facade.Models
{
    public class CarAdressBuilder : CarBuilderFacade
    {
        public CarAdressBuilder(Car car) 
        {
            this.car = car;
        }

        public CarAdressBuilder WithCity(string city)
        {
            car.City = city;
            return this;
        }
        public CarAdressBuilder WithAdress(string adress)
        {
            car.Adress = adress;    
            return this;
        }
    }
}
