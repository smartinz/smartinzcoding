using System.Linq;
using Iesi.Collections.Generic;
using SpikeRhinoSecurity.Infrastructure;

namespace SpikeRhinoSecurity.Infrastructure
{
	public class PresentableSetFactory
	{
		public IPresentableSet<T> Create<T>(IQueryable<T> queryable)
		{
			return new QueryablePresentableSet<T>(queryable);
		}

		public IPresentableSet<T> Create<T>(ISet<T> set)
		{
			return new QueryablePresentableSet<T>(set.AsQueryable());
		}
	}
}