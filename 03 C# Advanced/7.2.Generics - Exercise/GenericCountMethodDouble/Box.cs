using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericCountMethodDouble
{
    public class Box<T> where T : IComparable<T>
    {
        private List<T> list;
        private int count;

        public Box()
        {
            list = new List<T>();
        }

        public void Add(T input)
        {
            list.Add(input);
        }


        public int Count(List<T> list, T item)
        {
            foreach (var l in list)
            {
                if (l.CompareTo(item) > 0)
                {
                    count++;
                }
            }
            return count;
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
