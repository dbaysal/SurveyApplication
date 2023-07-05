using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using NLayer.Core.DTOs;
using NLayer.Core.Models;
using NLayer.Core.Services;
using NLayer.Repository;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using NLayer.API.UtilityClasses;
using NLayer.Core.DTOs.RequestDTOs;
using NLayer.Core.DTOs.ResponseDTOs;


namespace NLayer.API.Controllers
{
    public class LoginController : CustomBaseController
    {
        private readonly IService<User> _userService;
        private readonly IService<UserRole> _userRoleService;
        private readonly IMapper _mapper;
        private IConfiguration _config;
        private readonly AppDbContext _context;



        public LoginController(AppDbContext context, IConfiguration config,
            IService<User> userService, IMapper mapper, IService<UserRole> userRoleService)
        {
            _config = config;
            _userService = userService;
            _mapper = mapper;
            _context = context;
            _userRoleService = userRoleService;
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] Login userLogin)
        {
            var user = await Authenticate(userLogin);

            if (user != null)
            {
                var token = "Bearer " + TokenHelper.Generate(user, _config, _userRoleService);
                return CreateActionResult(CustomResponseDto<TokenDto>.Success(200, new TokenDto(token)));
            }

            return CreateActionResult(CustomResponseDto<Login>.Fail(404, "User not found"));


        }


        private async Task<AuthenticatedUser?> Authenticate(Login userLogin)
        {
            var users = await _userService.GetAllAsync();
            var userList = users.ToList();

            foreach (var user in userList)
            {
                if ((userLogin.Username == user.Username) && (userLogin.Password == user.Password))
                {
                    return _mapper.Map<AuthenticatedUser>(user);
                }
            }
            return null;
        }
    }
}
