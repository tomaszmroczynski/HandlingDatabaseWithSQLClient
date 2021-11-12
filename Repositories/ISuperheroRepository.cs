using LearningSQLClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningSQLClient.Repositories
{
    public interface ISuperheroRepository
    {
        public Superheroes GetSuperhero(string id);

        public List<Superheroes> GetAllSuperheroes();

        public bool AddNewSuperheroe(Superheroes superhero);

        public bool DeleteSuperhero(string id);
   }
}
