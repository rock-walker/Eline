using System.Linq;
using System.Threading.Tasks;
using EL.EntityModels;
using System.Collections.Generic;
using System.Web.Http;
using EL.EntityModels.ModelHelpers;

namespace EL.WebApi.Controllers
{
	public class CategoryController : ApiController
	{
		readonly CategoryContext _ctxCategory = new CategoryContext();

		[ActionName("hierarchical")]
		public IEnumerable<Category> GetHierarchical()
		{
			var categories = _ctxCategory.Categories.ToList();
			var builtCategories = MenuBuilder.BuildCategoriesHierarchy(categories, 0);

			return builtCategories;
		}

		// GET api/category
		public ICollection<Category> Get()
		{
			return _ctxCategory.Categories.ToList();
		}

		// GET api/values/5
		public string Get(int id)
		{
			return "value";
		}

		// POST api/values
		public void Post([FromBody]string value)
		{
		}

		// PUT api/values/5
		public void Put(int id, [FromBody]string value)
		{
		}

		// DELETE api/values/5
		public void Delete(int id)
		{
		}
	}
}