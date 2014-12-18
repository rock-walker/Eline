using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EL.EntityModels;

namespace EL.Logic.Controller
{
	public class Movable: IMovable
	{
		private readonly MovablesContext _ctxMovables;
		private readonly CategoryContext _ctxCategory;

		public Movable()
		{
			_ctxMovables = new MovablesContext();
			_ctxCategory = new CategoryContext();
		}

		public Task<IEnumerable<Movables>> GetByCategory(int id)
		{
			var action = new Func<Task<IEnumerable<Movables>>>(() =>
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

				return Task.FromResult(res);
			});

			return action();
		}
	}
}
