using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceAbstraction;
using SharedData.DTOs;
using SharedData.Wrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class AuthController : ControllerBase
	{
		private readonly ILoggingService _logger;
		private readonly IAuthService _authService;
		public AuthController(IAuthService authService, ILoggingService loggingService)
		{
			_authService = authService;
			_logger = loggingService;
		}

		[HttpPost]
		[EndpointSummary("Login with email and password")]
		public async Task<IActionResult> LoginAsync([FromBody] LoginDTO loginDTO)
		{
			if (loginDTO == null)
			{
				_logger.LogWarning("Login data is null or empty");
				return BadRequest(ApiResponse<string>.FailResponse("Login data is required"));
			}

			try
			{
				LoginResultDTO loginResultDTO = await _authService.LoginAsync(loginDTO);
				if (loginResultDTO == null)
				{
					_logger.LogInformation("Failed to login");
					return NotFound(ApiResponse<string>.FailResponse("Failed to Login"));
				}
				_logger.LogInformation("Successfully login");
				return Ok(ApiResponse<LoginResultDTO>.SuccessResponse(loginResultDTO, "Login successful"));
			}
			catch (Exception ex)
			{
				_logger.LogError(ex.Message, ex);
				// Log the exception here if you have logging configured
				return StatusCode(500, ApiResponse<string>.FailResponse("An error occurred during login"));
			}
		}
	}
}
