using System;

namespace EL.Logic.CuttingEdge
{
	public class LoggerObserver<T> : IObserver<T>, IObservable<T>
	{
		public void OnCompleted()
		{
			throw new NotImplementedException();
		}

		public void OnError(Exception error)
		{
			throw new NotImplementedException();
		}

		public void OnNext(T value)
		{
			throw new NotImplementedException();
		}

		public IDisposable Subscribe(IObserver<T> observer)
		{
			throw new NotImplementedException();
		}

		public IObserver<T> GetObserver()
		{
			return null;
		} 
	}
}
