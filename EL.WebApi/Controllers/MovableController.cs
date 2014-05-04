using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using EL.EntityModels;

namespace EL.WebApi.Controllers
{
    public class MovableController : ApiController
    {
		readonly MovablesContext _ctxMovables = new MovablesContext();
		readonly CategoryContext _ctxCategory = new CategoryContext();
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
	    public ICollection<Movables> GetByCategory(int id)
		{
			var parentCatIds = (from c in _ctxCategory.Categories
				where c.Parent == id
				select c.Id).ToList();

			var movableIds = (parentCatIds.Count > 0) 
					? (from p in parentCatIds
						from cm in _ctxMovables.CategoriesToMovables
						where cm.CategoryId == p
						select cm.MovableId).ToList()
					: (from cm in _ctxMovables.CategoriesToMovables
					    where cm.CategoryId == id
					    select cm.MovableId).ToList();

			var res = from mId in movableIds
					  from mObj in _ctxMovables.Movables
								.Include("Gallery")
								.Include("Details")
				where mObj.Id == mId
				select mObj;

			return res.ToList();
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
