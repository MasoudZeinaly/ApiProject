using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class PeopleRepository : IPeopleRepository
    {
        private string ConnectionString = "Data Source=.;Initial Catalog=MyApi_DB;Integrated Security=true;";
        public async Task<bool> DeletePerson(int personId)
        {
            try
            {
                using (IDbConnection db = new SqlConnection(ConnectionString))
                {
                    string Query = "Delete From People Where ID=@id)";
                    await db.ExecuteAsync(Query, new { id = personId });
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async  Task<IEnumerable<PersonViewModel>> GetAllPerson()
        {
            IEnumerable<PersonViewModel> PeopleList;
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                PeopleList =  await db.QueryAsync<PersonViewModel>("Select * From People");
            }
            return PeopleList.ToList();
        }

        public async Task<PersonViewModel> GetPersonById(int personId)
        {
            PersonViewModel Person;
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                Person = (PersonViewModel)await db.QueryAsync<PersonViewModel>("Select * From People Where ID=@id", new { id = personId });
            }
            return Person;
        }

        public async Task<bool> InsertPerson(PersonViewModel person)
        {
            try
            {
                using (IDbConnection db = new SqlConnection(ConnectionString))
                {
                    string Query = "Insert Into People (Name,Age,Email) Values (@name,@age,@email)";
                    await db.ExecuteAsync(Query, person);
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> UpdatePerson(PersonViewModel person)
        {
            try
            {
                using (IDbConnection db = new SqlConnection(ConnectionString))
                {
                    string Query = "Update People Set Name=@name,Age=@age,Email=@email Where ID=@id)";
                    await db.ExecuteAsync(Query, person);
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
