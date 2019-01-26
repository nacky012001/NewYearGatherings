using System;
namespace Assets.tasks
{
    public class TVShow
    {
        public int index;
        public void setIndex(int index)
        {
            this.index = index;
        }
        public bool IsComplete(int prop)
        {
            return prop == index;
        }
    }
}
