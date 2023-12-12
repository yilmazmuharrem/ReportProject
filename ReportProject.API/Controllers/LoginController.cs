using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using ReportProject.DataService.Repositories.Interfaces;
using ReportProject.Entities.Dtos.Requests;
using ReportProject.Entities.Models.Authorization;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ReportProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : BaseController
    {

      private readonly JwtModels _jwtModels;
        public LoginController(IUnitOfWork unitOfWork, IMapper mapper, IOptions<JwtModels> jwtModel) : base(unitOfWork, mapper)
        {
            _jwtModels = jwtModel.Value;
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody ]LoginUserDto admin,CancellationToken cancellationToken)
        {
  
         if (!ModelState.IsValid) return BadRequest();
        var mapping = _mapper.Map<User>(admin);

        var user =    await _unitOfWork.Users.Login(mapping,cancellationToken);
            await _unitOfWork.CompleteAsync(cancellationToken);

        if (user == null) return BadRequest("Kullanıcı Bulunamadı !");
        
        var token = CreateToken(user);
          return Ok(token);
        }


        private string CreateToken(User admin)
        {
            if (_jwtModels == null) throw new Exception("Jwt Ayarlarındaki Key değeri null olamaz");
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtModels.Key!));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.Name,admin.UserName!),
                
            };
            var token = new JwtSecurityToken(_jwtModels.Issuer,
               _jwtModels.Audience,
               claims,
               expires: DateTime.Now.AddHours(1),
               signingCredentials: credentials);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

    }
}
