using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static main;

namespace Assets
{
    public static class ListExtensions
    {
        public static GameTask GetMyTask(this List<GameTask> tasks, int index)
        {
            return tasks.Where(t => t.index == index && t.status == 'N').FirstOrDefault();
        }
    }
}
