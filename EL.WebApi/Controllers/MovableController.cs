﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using EL.EntityModels;
using EL.Logic.Controller;

namespace EL.WebApi.Controllers
{
    public class MovableController : ApiController
    {
	    private readonly IMovable _movable;

	    public MovableController(IMovable movable)
	    {
		    _movable = movable;
	    }

        // GET api/movable
        public ICollection<Movables> Get()
        {
            return new List<Movables>
            {
	            new Movables{ Id = 12}
            };
        }

		// Get api/movable/bycategory/2
		[ActionName("bycategory")]
	    public Task<IEnumerable<Movables>> GetByCategory(int id)
		{
			return _movable.GetByCategory(id);
		}

        // GET api/movable/get/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/movable
        public void Post([FromBody]string value)
        {
        }

        // PUT api/movable/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/movable/5
        public void Delete(int id)
        {
        }
    }
}
