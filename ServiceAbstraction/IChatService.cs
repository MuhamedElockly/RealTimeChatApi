using System.Threading.Tasks;
using SharedData.DTOs;
namespace ServiceAbstraction
{
	public interface IChatService
	{
		Task<string> GetChatHistoryAsync(string userId);
		Task<bool> SaveChatMessageAsync(string userId, string message);
		public Task<string> GetChatUserConnectionId(int userId);
		public Task<int> AddSessionMessage(SessionMessageDTO sessionMessageDTO);
	}
}
