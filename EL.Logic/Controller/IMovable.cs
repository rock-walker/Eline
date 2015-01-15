using System.Collections.Generic;
using System.Threading.Tasks;
using EL.EntityModels.Models;

namespace EL.Logic.Controller
{
	public interface IMovable
	{
		Task<IEnumerable<Movable>> GetByCategory(int id);
	}
}
