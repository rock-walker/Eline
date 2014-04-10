using System.Collections.Generic;
using System.IO;
using System.Web.Optimization;

namespace EL.Server.Base
{
	internal class AsIsBundleOrderer : IBundleOrderer
	{
		public virtual IEnumerable<FileInfo> OrderFiles(BundleContext context, IEnumerable<FileInfo> files)
		{
			return files;
		}
	}

	internal static class BundleExtensions
	{
		public static Bundle ForceOrdered(this Bundle sb)
		{
			sb.Orderer = new AsIsBundleOrderer();
			return sb;
		}
	}
}