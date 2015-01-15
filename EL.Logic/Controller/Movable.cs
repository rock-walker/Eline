using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EL.EntityModels.Contexts;
using EL.EntityModels.Models;

namespace EL.Logic.Controller
{
	public class MovableItem: IMovable
	{
		private readonly MovablesContext _ctxMovables;

		public MovableItem()
		{
			_ctxMovables = new MovablesContext();
		}

		public Task<IEnumerable<Movable>> GetByCategory(int id)
		{
			var action = new Func<Task<IEnumerable<Movable>>>(() =>
			{
				var parentCatIds = (from c in _ctxMovables.Categories
					where c.Parent == id
					select c.Id).ToList();

				var getMovableIds = new Func<int, IEnumerable<Movable>>(x =>
				{
					var mIds = (
									from cm in _ctxMovables.Movables
									where cm.Category.Id == x
									select cm
								).ToList();

					return mIds;
				});

				var movables = (parentCatIds.Any())
					? parentCatIds.SelectMany(getMovableIds)
					: getMovableIds(id);

				return Task.FromResult(movables);
			});

			return action();
		}
	}
}
