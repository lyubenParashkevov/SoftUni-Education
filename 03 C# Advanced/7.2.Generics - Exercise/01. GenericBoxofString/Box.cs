using System;
using System.Collections.Generic;
using System.Text;

namespace GenericBoxofString
{
    public class Box<T>
    {
        private List<T> list ;

        public Box() 
        { 
            list = new List<T>();
        }

        public void Add(T input)
        {
            list.Add(input);
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var input in list)
            {
                sb.AppendLine($"{typeof(T)}: {input}");
            }
            return sb.ToString().TrimEnd();
        }
    }
}
