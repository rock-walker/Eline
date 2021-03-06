﻿using System.Collections.Generic;
using System.Linq;

namespace EL.EntityModels.ModelHelpers
{
	public class MenuBuilder
	{
		public static IEnumerable<T> BuildCategoriesHierarchy<T>(IEnumerable<T> source, int level) where T : DomainModels.ChildrenCategory
		{
			var initializedSource = source as IList<T> ?? source.ToList();
			return initializedSource.Where(s => s.Parent == level).ToList()
				.Select(x =>
				{
					var children = from m in initializedSource
								   where m.Parent == x.Id
								   select m;

					var initializedChildren = children as IList<T> ?? children.ToList();
					if (initializedChildren.Any())
						x.SubCategories = BuildCategoriesHierarchy(initializedChildren, ++level);
					return x;
				}).ToList();
		}
	}
}
