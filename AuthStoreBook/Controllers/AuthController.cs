using AuthCommon;
using AuthStoreBook.Models;
using AutoMapper;
using BusinessObjects;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using ProcessManager.Interface;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace AuthStoreBook.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserProcessManager _userProcessManager;
        private readonly IOptions<AuthOptions> authOptions;
        private readonly IMapper _mapper;

        public AuthController(IUserProcessManager userProcessManager, 
            IOptions<AuthOptions> authOptions,
            IMapper mapper)
        {
            _mapper = mapper;
            _userProcessManager = userProcessManager;
            this.authOptions = authOptions;
        }

        [HttpPost("login")]
        public async Task<ActionResult> Login([FromBody] UserDto dto)
        {
            try
            {
                var identity = await _userProcessManager.GetUserByCred(dto.Email, dto.Password);

                if (identity == null)
                    return BadRequest("Credetnials wrong");

                var token = GenerateJWT(dto);

                return Ok(new
                {
                   access_token = token
                });
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpPost("register")]
        public async Task<ActionResult> Register([FromBody] UserDto registerDto)
        {

            var user = await _userProcessManager.GetByEmail(registerDto.Email);
            if (user != null)
                return BadRequest("The user already exists");
            await _userProcessManager.Register(_mapper.Map<User>(registerDto));

            return Ok(registerDto);
        }
        private string GenerateJWT(UserDto userDto)
        {
            var authParams = authOptions.Value;
            var securityKey = authParams.GetSymmetricSecurityKey();
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>()
            {
                new Claim(JwtRegisteredClaimNames.Email, userDto.Email),
                new Claim(JwtRegisteredClaimNames.Sub, userDto.Email),
            };
            var jwt = new JwtSecurityToken(
                       issuer: authParams.Issuer,
                       audience: authParams.Audience,
                       claims: claims,
                       expires: DateTime.Now.AddSeconds(authParams.TokenLifeTime),
                       signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(jwt);
        }
    }
}
