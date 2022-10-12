using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_Stefanini
{
    public class Dish
    {
        public string name;
        public string description;
        public float price = 0;
        public int estimatedCookingTime;
        public List<Ingredient> ingredients = new List<Ingredient>();

        public Dish(string Name, string Description, int EstimatedCookingTime, params Ingredient[] Ingredients)
        {
            name = Name;
            description = Description;
            estimatedCookingTime = EstimatedCookingTime;

            for (int i = 0; i < Ingredients.Length; i++)
            {
                ingredients.Add(Ingredients[i]);
            }

            for (int i = 0; i < ingredients.Count; i++)
            {
                price += Ingredients[i].price;
            }
            price = price * 1.2f;
        }
    }
}
