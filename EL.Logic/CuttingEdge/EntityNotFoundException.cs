using System;

namespace EL.Logic.CuttingEdge
{
	/// <summary>
	/// Generalized exception for case 'something not found'
	/// </summary>
	public class EntityNotFoundException : ApplicationException
	{
		public EntityNotFoundException(string message) : base(message)
		{
		}

		public EntityNotFoundException(string message, Exception inner) : base(message, inner)
		{
			
		}
	}
}
