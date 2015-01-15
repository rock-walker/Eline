using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using EL.EntityModels;
using EL.EntityModels.Contexts;
using EL.EntityModels.ModelHelpers;
using EL.EntityModels.Models;

namespace EL.WebApi.Controllers
{
	public class CategoryController : ApiController
	{
		readonly GeneralContext _ctxCategory = new GeneralContext();

		[ActionName("hierarchical")]
		public IEnumerable<DomainModels.ChildrenCategory> GetHierarchical()
		{
			var categories = _ctxCategory.Categories.ToList();
			if (!categories.Any())
				//throw Exception here
				;

			var builtCategories = MenuBuilder.BuildCategoriesHierarchy(categories.OfType<DomainModels.ChildrenCategory>(), 0);

			return builtCategories;
		}

		// GET api/category
		public ICollection<DomainModels.BaseCategory> Get()
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