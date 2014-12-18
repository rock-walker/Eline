using System.Collections.Generic;
using System.Threading.Tasks;
using EL.EntityModels;

namespace EL.Logic.Controller
{
	public interface IMovable
	{
		Task<IEnumerable<Movables>> GetByCategory(int id);
	}
}
