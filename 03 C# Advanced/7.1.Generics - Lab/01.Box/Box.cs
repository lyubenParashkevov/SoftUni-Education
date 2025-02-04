using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoxOfT
{
    public class Box<T>
    {

        private List<T> items;


        public Box() 
        {
            items = new List<T>();
        }
        
        public int Count 
        { 
            get 
            { 
                return items.Count;
            } 
        } 

        public void Add(T element) 
        {
            items.Add(element);
        }

        public T Remove()
        {
            T item = items[items.Count - 1];
            items.RemoveAt(items.Count - 1); 
            return item;
        }
    }
}
