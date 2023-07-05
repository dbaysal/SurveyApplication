using Microsoft.IdentityModel.Tokens;
using NLayer.Core.DTOs.ResponseDTOs;
using NLayer.Core.Models;
using NLayer.Core.Services;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace NLayer.API.UtilityClasses
{
	public class TokenHelper
	{
		public static string Generate(AuthenticatedUser user, IConfiguration config,
			IService<UserRole> userRoleService)
		{

			var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Jwt:Key"]));
			var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

			var userRoles = userRoleService.Where(x => x.UserId == user.Id).ToList();

			var claims = new List<Claim>();
			claims.Add(new Claim(ClaimTypes.NameIdentifier, user.Username));

			foreach (var userRole in userRoles)
			{
				claims.Add(new Claim(ClaimTypes.Role, userRole.RoleId.ToString()));
			}

			var token = new JwtSecurityToken(config["Jwt:Issuer"],
				config["Jwt:Audience"],
				claims,
				expires: DateTime.Now.AddMinutes(15),
				signingCredentials: credentials);

			return new JwtSecurityTokenHandler().WriteToken(token);
		}
	}
}
