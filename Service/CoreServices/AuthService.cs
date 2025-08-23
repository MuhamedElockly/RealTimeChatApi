using Domain.Contracts;
using Domain.Entities.IdentityEntity;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using ServiceAbstraction;
using SharedData.DTOs;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Service.CoreServices
{
	public class AuthService : IAuthService
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly UserManager<ApplicationUser> _userManager;
		private readonly IConfiguration _configuration;
		public AuthService(IUnitOfWork unitOfWork, UserManager<ApplicationUser> userManager, IConfiguration configuration)
		{
			_unitOfWork = unitOfWork;
			_userManager = userManager;
			_configuration = configuration;

		}
		public async Task<LoginResultDTO> LoginAsync(LoginDTO loginDTO)
		{
			ApplicationUser applicationUser = await _userManager.FindByEmailAsync(loginDTO.Email);

			if (applicationUser != null)
			{
				bool isValidPassword = await _userManager.CheckPasswordAsync(applicationUser, loginDTO.Password);
				if (isValidPassword)
				{
					var roles = await _userManager.GetRolesAsync(applicationUser);
					var token = GenerateToken(applicationUser, (List<string>)roles);
					return new LoginResultDTO
					{
						Token = token
					};
				}
				else
				{
					return null;
				}

			}
			else
			{
				return null;
			}

		}
		public string GenerateToken(ApplicationUser applicationUser, List<string> roles)
		{
			List<Claim> claims = new List<Claim>();
			claims.Add(new Claim(ClaimTypes.Name, applicationUser.UserName));
			claims.Add(new Claim(ClaimTypes.NameIdentifier, applicationUser.Id));
			claims.Add(new Claim(ClaimTypes.Email, applicationUser.Email));
			foreach (var role in roles)
			{
				claims.Add(new Claim(ClaimTypes.Role, role.ToString()));
			}
			var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Key"]));
			var cred = new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256);
			var token = new JwtSecurityToken(
				  issuer: _configuration["JWT:ValidIssuer"],
				audience: _configuration["JWT:ValidAudience"],
				expires: DateTime.Now.AddHours(3),
				claims: claims,
				signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
				);
			var stringToken = new JwtSecurityTokenHandler().WriteToken(token);

			return stringToken.ToString();
		}

		
	}
}
