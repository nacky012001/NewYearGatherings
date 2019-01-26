using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.tasks
{
    public class Food
    {
        public Food()
        {

        }

        public bool IsComplete(string prop)
        {
            return prop == "food";
        }
    }
}
