using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL.Logic.ApplicationLevel
{
	public interface IBootstrapper
	{
		IDisposable Run();
	}
}
