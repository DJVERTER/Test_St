using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_Stefanini
{
    class Program
    {
        static void Main(string[] args)
        {
            var Cooks = new List<Cook>()
            {
                new Cook("Alex"),
                new Cook("Boris")
            };

            var Ingredients = new List<Ingredient>()
            {
                new Ingredient("Tomatoes", 2.55f),
                new Ingredient("Mozzarella", 1.32f),
                new Ingredient("Prosciuto", 1.15f),
                new Ingredient("Pasta", 3f),
                new Ingredient("Egg", 2f),
                new Ingredient("Potatoes", 2.35f),
                new Ingredient("Sausages", 1.15f),
                new Ingredient("HotDog bread", 2f)
            };

            var Dishes = new List<Dish>()
            {
                new Dish("Pizza", "Original Neapolitan", 25, Ingredients[0], Ingredients[1], Ingredients[2]),
                new Dish("Fries", "Belorussian potatoes", 10, Ingredients[5]),
                new Dish("Carbonara", "Fresh Pasta", 15, Ingredients[3], Ingredients[4]),
                new Dish("Hotdog", "No dogs were harmed", 10, Ingredients[6], Ingredients[7])
            };

            //App Menu
            Console.WriteLine("\nHello\nWe welcome you to our restaurant\nHere is our menu for today");
            for (int i = 0; i < Dishes.Count; i++)
            {
                Console.WriteLine($"\nName of Dish: { Dishes[i].name}");
                Console.WriteLine($"Description: { Dishes[i].description}");

                for (int j = 0; j < Dishes[i].ingredients.Count; j++)
                {
                    Console.WriteLine(Dishes[i].ingredients[j].name);
                }

                Console.WriteLine($"Price: {Math.Round(Dishes[i].price, 2)} $");
                Console.WriteLine("\n");
            }

            //Dish Order
            int CookNumber = 0;
            int minDishNumber = 0;
            while (true)
            {
                Console.WriteLine("\nPlease choose your dish");

                string nameOfOrderedDish = Console.ReadLine();

                // finding the cook with least number of dishes
                for (int i = 0; i < Cooks.Count - 1; i++)
                {
                    if (Cooks[i].dishesNumber < Cooks[i + 1].dishesNumber)
                    {
                        minDishNumber = Cooks[i].dishesNumber;
                        CookNumber = i;
                    }
                    else if (Cooks[i].dishesNumber > Cooks[i + 1].dishesNumber)
                    {
                        minDishNumber = Cooks[i + 1].dishesNumber;
                        CookNumber = i + 1;
                    }
                    else if (Cooks[i].dishesNumber == Cooks[i + 1].dishesNumber)
                    {
                        if (i == Cooks.Count - 2)
                        {
                            minDishNumber = Cooks[i].dishesNumber;
                            CookNumber = i;
                        }
                        else
                        {
                            continue;
                        }
                    }

                    break;
                }

                // Maximum dishes asigned to cook
                if (minDishNumber == 5)
                {
                    Console.WriteLine("\nSorry all chefs are busy");
                    break;
                }
                else
                {
                    int temp = 0;

                    for (int i = 0; i < Dishes.Count; i++)
                    {
                        if (nameOfOrderedDish == Dishes[i].name)
                        {
                            Cooks[CookNumber].dishes.Add(Dishes[i]);
                            Cooks[CookNumber].dishesNumber++;

                            // calculate cooking finish time
                            Cooks[CookNumber].cookingTime += Dishes[i].estimatedCookingTime;

                            Console.WriteLine($"Cooking finish time:  { Cooks[CookNumber].cookingTime}  minutes");
                        }
                        else
                        {
                            if (temp == Dishes.Count - 1)
                            {
                                Console.WriteLine("Ordered dish does't exist.");
                            }
                            temp++;
                        }
                    }
                }
            }
            Console.ReadKey();
        }
    }
}
