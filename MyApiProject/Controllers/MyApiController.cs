using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace MyApiProject.Controllers
{
    public class MyApiController : ApiController
    {
        IPeopleRepository peopleRepository = new PeopleRepository();
        // GET: api/MyApi
        [Route("~/api/myapi")]
        [HttpGet]
        public async Task<IEnumerable<PersonViewModel>> Get()
        {
            return  await peopleRepository.GetAllPerson();
        }

        // GET: api/MyApi/5
        [Route("~/api/myapi/{id}")]
        public async Task<PersonViewModel> Get(int id)
        {
            return await peopleRepository.GetPersonById(id);
        }

        // POST: api/MyApi
        [Route("~/api/myapi/addperson")]
        [HttpPost]
        public async Task Post([FromBody] PersonViewModel person)
        {
            await peopleRepository.InsertPerson(person);
        }

        // PUT: api/MyApi/5
        [Route("~/api/myapi/updateperson")]
        [HttpPut]
        public async Task Put([FromBody] PersonViewModel person)
        {
            await peopleRepository.UpdatePerson(person);
        }

        // DELETE: api/MyApi/5
        [Route("~/api/myapi/deleteperson")]
        [HttpDelete]
        public async Task Delete(int id)
        {
            await peopleRepository.DeletePerson(id);
        }
    }
}
