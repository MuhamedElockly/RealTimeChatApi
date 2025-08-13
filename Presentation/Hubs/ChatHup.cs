using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using ServiceAbstraction;
using SharedData.DTOs;


namespace Presentation.Hubs
{
	public class ChatHub : Hub
	{
		private readonly IChatService _chatService;
		private readonly ILoggingService _loggingService;
		public ChatHub(IChatService chatService, ILoggingService loggingService)
		{
			_chatService = chatService;
			_loggingService = loggingService;
		}

		public async Task SendMessage(SessionMessageDTO messageDTO, int senderId, int receiverId)
		{
			_loggingService.LogInformation($"Sending message  for user: {receiverId} from {senderId}");
			try
			{
				int messageId = await _chatService.AddSessionMessage(messageDTO);

				if (messageId > 0)
				{

					await Clients.Caller.SendAsync("messageSent", new
					{
						success = true,
						messageId = messageId,
						timestamp = DateTime.UtcNow
					});

					string receiverConnectionId = await _chatService.GetChatUserConnectionId(receiverId);

					if (!string.IsNullOrEmpty(receiverConnectionId))
					{
						await Clients.Client(receiverConnectionId).SendAsync("newMessage", messageDTO);
						_loggingService.LogInformation("Message send successfully",senderId);
					}
					else
					{
						_loggingService.LogWarning("ReceiverId is null or empty");
					}
				}
				else
				{
					_loggingService.LogError($"Failed to save message to database from sender {senderId}");
					await Clients.Caller.SendAsync("messageSent", new
					{
						success = false,
						error = "Failed to save message"
					});
				}
			}
			catch (Exception ex)
			{
				_loggingService.LogError($"Failed to save message to database from sender {senderId}",ex);
				await Clients.Caller.SendAsync("messageSent", new
				{
					success = false,
					error = ex.Message
				});


			}
		}
	}
}


