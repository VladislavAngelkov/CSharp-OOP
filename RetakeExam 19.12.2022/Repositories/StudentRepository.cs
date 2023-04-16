using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UniversityCompetition.Models.Contracts;
using UniversityCompetition.Repositories.Contracts;

namespace UniversityCompetition.Repositories
{
    public class StudentRepository : IRepository<IStudent>
    {
        private List<IStudent> models;
        public StudentRepository()
        {
            models= new List<IStudent>();
        }
        public IReadOnlyCollection<IStudent> Models
        {
            get { return models.AsReadOnly(); }
        }

        public void AddModel(IStudent model)
        {
           models.Add(model);
        }

        public IStudent FindById(int id)
        {
            return models.FirstOrDefault(m => m.Id == id);
        }

        public IStudent FindByName(string name)
        {
            string[] names = name.Split(' ');   
            string firstName = names[0];
            string lastName = names[1];

            return models.FirstOrDefault(m => m.FirstName == firstName && m.LastName == lastName);
        }
    }
}
