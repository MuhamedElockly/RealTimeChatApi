using Domain.Contracts;
using Service.CoreServices;
using ServiceAbstraction;
using System;
using System.Threading.Tasks;

namespace Service.CoreServices
{
    public class ChatService : IChatService
    {
        private readonly ILoggingService _loggingService;

        public ChatService(ILoggingService loggingService)
        {
            _loggingService = loggingService;
        }

        public async Task<string> GetChatHistoryAsync(string userId)
        {
            return await _loggingService.LogOperationAsync("GetChatHistoryAsync", async () =>
            {
                // Simulate database call
                await Task.Delay(100);
                
                if (userId == "admin")
                {
                    _loggingService.LogInformation("Admin user accessing chat history");
                }
                
                return $"Chat history for user {userId} - Sample messages...";
            });
        }

        public async Task<bool> SaveChatMessageAsync(string userId, string message)
        {
            return await _loggingService.LogOperationAsync("SaveChatMessageAsync", async () =>
            {
                // Simulate database save
                await Task.Delay(50);
                
                if (string.IsNullOrEmpty(message))
                {
                    _loggingService.LogWarning("Attempted to save empty message for user: {UserId}", userId);
                    return false;
                }
                
                _loggingService.LogInformation("Saved chat message for user: {UserId}, Message length: {MessageLength}", 
                    userId, message.Length);
                
                return true;
            });
        }
    }
}
