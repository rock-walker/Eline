using System;
using System.Collections.Generic;
using System.Linq;
using EL.DataContracts.General;
using Microsoft.Practices.Unity;

namespace EL.Logic.Controller
{
	public class ElineServiceFactory : IElineServiceFactory
	{
		private readonly IUnityContainer _ioc;

		private readonly IEnumerable<int> _convertedTypes;

		public ElineServiceFactory(IUnityContainer ioc)
		{
			_ioc = ioc;
			_convertedTypes = Enum.GetValues(typeof(ServiceType)).Cast<int>();
		}

		public IElineService Create(short serviceType)
		{
			var strType = EnsureServiceType(serviceType);

			return _ioc.Resolve<IElineService>(strType);
		}

		private string EnsureServiceType(short serviceType)
		{
			var has = _convertedTypes.Any(x => x == serviceType);

			if (has)
				return ((ServiceType) serviceType).ToString();

			throw new NotSupportedException("Unknown type of service");
		}
	}
}
