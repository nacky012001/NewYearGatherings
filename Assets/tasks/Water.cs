using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.tasks
{
    public class Water
    {
        public Water()
        {

        }

        public bool IsComplete(string prop)
        {
            return prop == "water";
        }
    }
}
