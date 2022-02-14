using AutoMapper;
using BusinessObjects;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using ProcessManager.Interface;
using StoreBookWebApi.Models.Register;
using StoreBookWebApi.Token;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace StoreBookWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private IUserProcessManager _employeeProcessManager;
        private IMapper _mapper;

        public AuthenticationController(IUserProcessManager employeeProcessManager, IMapper mapper)
        {
            _mapper = mapper;
            _employeeProcessManager = employeeProcessManager;
        }
        [HttpPost("register")]
        public async Task<ActionResult> Register([FromBody] RegisterDto registerDto)
        {

            var user = await _employeeProcessManager.GetByEmail(registerDto.Name);
            if (user != null)
                return BadRequest("The user already exists");
            await _employeeProcessManager.Register(_mapper.Map<User>(registerDto));

            return Ok(registerDto);
        }
        [HttpPost("login")]
        public async Task<ActionResult> Login(RegisterDto dto)
        {
            try
            {
                var identity = await GetIdentity(dto);
                if (identity == null)
                    return BadRequest("Credetnials wrong");

                var now = DateTime.UtcNow;
                // создаем JWT-токен
                var jwt = new JwtSecurityToken(
                        issuer: AuthOptions.ISSUER,
                        audience: AuthOptions.AUDIENCE,
                        notBefore: now,
                        claims: identity.Claims,
                        expires: now.Add(TimeSpan.FromMinutes(AuthOptions.LIFETIME)),
                        signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
                var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

                var response = new
                {
                    access_token = encodedJwt,
                    username = dto.Name
                };

                return Ok(response);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
        private async Task<ClaimsIdentity> GetIdentity(RegisterDto dto)
        {
            User? user = await _employeeProcessManager.GetByEmail(dto.Name);
            if (user == null)
                return null;
            if (!BCrypt.Net.BCrypt.Verify(dto.Password, user.Password))
                return null;

            var claims = new List<Claim>
                {
                    new Claim(ClaimsIdentity.DefaultNameClaimType, user.Name),
                    new Claim(ClaimsIdentity.DefaultRoleClaimType, user.Role.Rolename)
                };

            ClaimsIdentity claimsIdentity =
            new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType,
                ClaimsIdentity.DefaultRoleClaimType);
            return claimsIdentity;

        }
    }
}

