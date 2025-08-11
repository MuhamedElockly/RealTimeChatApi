using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using ServiceAbstraction;
using System;
using System.Threading.Tasks;

namespace Presentation.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class ChatController : ControllerBase
	{
		private readonly ILoggingService _loggingService;

		public ChatController(ILoggingService loggingService)
		{
			_loggingService = loggingService;
		}

		[HttpGet]
		public async Task<IActionResult> GetChatHistory(string userId)
		{
			_loggingService.LogInformation("Getting chat history for user: {UserId}", userId);
			
			if (string.IsNullOrEmpty(userId))
			{
				_loggingService.LogWarning("UserId is null or empty");
				return BadRequest("UserId is required");
			}

			try
			{
				var chatService = HttpContext.RequestServices.GetRequiredService<IChatService>();
				var result = await chatService.GetChatHistoryAsync(userId);

				_loggingService.LogInformation("Successfully retrieved chat history for user: {UserId}", userId);
				return Ok(result);
			}
			catch (Exception ex)
			{
				//_loggingService.LogError(ex, "Error retrieving chat history for user: {UserId}", userId);
				return StatusCode(500, "Internal server error");
			}
		}

		[HttpGet("test")]
		public IActionResult Test()
		{
			return Ok("ChatController is working!");
		}
	}
}
