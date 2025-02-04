using System;
using System.Collections.Generic;


namespace CustomRandomList
{
    public class RandomList : List<String>
    {
        public string RandomString()
        {
            Random random = new Random();

            int index = random.Next(0, this.Count);
            string str = this.ElementAt(index);
            this.RemoveAt(index);           
            return str;

        }
            
    }
}
