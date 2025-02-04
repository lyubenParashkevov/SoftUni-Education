using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityCompetition.Models.Contracts;
using UniversityCompetition.Repositories.Contracts;

namespace UniversityCompetition.Repositories
{
    public class StudentRepository : IRepository<IStudent>
    {
       
        private List<IStudent> models;

        public StudentRepository()
        {
            models = new List<IStudent>();
        }
        
        public IReadOnlyCollection<IStudent> Models
        { 
            get => models.AsReadOnly();
        }

        public void AddModel(IStudent model)
        {
            models.Add(model);
        }

        public IStudent FindById(int id)
        {
            return models.FirstOrDefault(x => x.Id == id);
        }

        public IStudent FindByName(string name)
        {
            string[] studentsFulлName = name.Split();
            string curentfirstName = studentsFulлName[0];
            string curentlastName = studentsFulлName[1];
            return models.FirstOrDefault(x => x.FirstName == curentfirstName && x.LastName == curentlastName);
        }
    }
}
