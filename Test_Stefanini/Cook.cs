using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_Stefanini
{
    public class Cook
    {
        public string name;
        public int dishesNumber = 0;
        public int cookingTime = 0;
        public List<Dish> dishes = new List<Dish>();

        public Cook(string Name)
        {
            name = Name;
        }
    }
}
