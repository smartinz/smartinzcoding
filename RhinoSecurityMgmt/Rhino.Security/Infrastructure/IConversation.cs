using System;

namespace Conversation
{
	public interface IConversation : IDisposable
	{
		IDisposable SetAsCurrent();
		void ResetCurrent();

		void Flush();

		void Close();
	}
}