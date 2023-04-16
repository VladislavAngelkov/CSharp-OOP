namespace WildFarm.Models
{
    public abstract class Food
    {
        private int amount;

        protected Food(int amount)
        {
            this.amount = amount;
        }

        public int Amount
        {
            get { return amount; }
        }
    }
}
