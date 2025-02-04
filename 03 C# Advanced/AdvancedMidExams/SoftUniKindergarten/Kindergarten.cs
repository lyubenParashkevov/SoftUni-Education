using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftUniKindergarten
{
    public class Kindergarten
    {

        private List<Child> registry;
        public Kindergarten(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.Registry = new List<Child>();
        }

        public string Name { get; set; }
        public int Capacity { get; set; }

        public List<Child> Registry
        {
            get { return registry; }


            set { registry = value; }
        }

        public int ChildrenCount
        {
            get
            {
                return Registry.Count;
            }
        }
        public bool AddChild(Child child)
        {
            if (Registry.Count < Capacity)
            {
                Registry.Add(child);
                return true;
            }
            return false;
        }

        public bool RemoveChild(string childFullName)
        {
            Child childToRemove = GetChild(childFullName);
            bool isRemoved = Registry.Remove(childToRemove);
            return isRemoved;
        }


        public Child GetChild(string childFullName)
        {
            return Registry.Find(c => childFullName == $"{c.FirstName} {c.LastName}");
        }

        public string RegistryReport()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Registered children in {this.Name}:");


            foreach (Child child in Registry.OrderByDescending(x => x.Age).ThenBy(x => x.LastName).ThenBy(x => x.FirstName))
            {
                sb.AppendLine(child.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
