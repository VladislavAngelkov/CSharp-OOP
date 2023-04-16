namespace Prototype.Models
{
    public class Sandwich : SandwichProtoype
    {
        private string bread;
        private string meat;
        private string cheese;
        private string veggies;

        public Sandwich(string bread, string meat, string cheese, string veggies)
        {
            this.bread = bread;
            this.meat = meat;
            this.cheese = cheese;
            this.veggies = veggies;
        }

        public override SandwichProtoype Clone()
        {
            string ingredientList = this.GetIngredientList();
            Console.WriteLine($"Cloning sandwich with ingredients: {ingredientList}");
            
            return this.MemberwiseClone() as SandwichProtoype;
        }
        private string GetIngredientList()
        {
            return $"{this.bread}, {this.meat}, {this.cheese}, {this.veggies}";
        }
    }
}
