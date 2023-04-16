namespace Facade.Models
{
    public class CarBuilderFacade
    {
        protected Car car;

        public CarBuilderFacade()
        {
            this.car = new Car();
        }

        public Car Build()
        {
            return this.car;
        }

        public CarInfoBuilder Info
        {
            get
            {
               return new CarInfoBuilder(car);
            }
        }

        public CarAdressBuilder Adress
        {
            get
            {
                return new CarAdressBuilder(car);
            }
        }
    }
}
