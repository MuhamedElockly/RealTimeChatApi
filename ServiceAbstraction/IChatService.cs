using System.Threading.Tasks;

namespace ServiceAbstraction
{
    public interface IChatService
    {
        Task<string> GetChatHistoryAsync(string userId);
        Task<bool> SaveChatMessageAsync(string userId, string message);
    }
}
