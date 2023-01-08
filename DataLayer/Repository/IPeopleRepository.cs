using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public interface IPeopleRepository
    {
        Task<IEnumerable<PersonViewModel>> GetAllPerson();
        Task<PersonViewModel> GetPersonById(int personId);
        Task<bool> InsertPerson(PersonViewModel person);
        Task<bool> UpdatePerson(PersonViewModel person);
        Task<bool> DeletePerson(int personId);
    }
}
