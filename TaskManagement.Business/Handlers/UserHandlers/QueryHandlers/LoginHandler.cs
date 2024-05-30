using FluentValidation.Results;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TaskManagement.Business.Queries.UserQueries;
using TaskManagement.Business.Repositories.UserRepositories;
using TaskManagement.Business.Shared;
using TaskManagement.Business.Validators;
using TaskManagement.Entities.Dtos;
using TaskManagement.Infrastructure.APIs;

namespace TaskManagement.Business.Handlers.UserHandlers.QueryHandlers
{
    public class LoginHandler(IUserReadRepository repository, IConfiguration configuration) : IRequestHandler<LoginQuery, Response<LoginResponse>>
    {
        private readonly IUserReadRepository _repository = repository;
        private readonly IConfiguration _configuration = configuration;
        public async Task<Response<LoginResponse>> Handle(LoginQuery request, CancellationToken cancellationToken)
        {
            var getUser = await _repository.Find(x => x.Status && x.Email == request.Email && x.Password == request.Password);

            if (getUser == null)
                return Response<LoginResponse>.Fail("Please check login information", 409);

            var getRoles = await TaskManagementAPIs.GetAllRole<List<RoleResponse>>();
            var getUserRole = getRoles.Where(x => x.Id == getUser.RoleId).FirstOrDefault();

            var role = getUserRole?.Name;

            if (string.IsNullOrEmpty(role))
            {
                return Response<LoginResponse>.Fail("User has no role assigned", 409);
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var keyJwt = _configuration["keyJwt"];

            if (string.IsNullOrEmpty(keyJwt))
            {
                return Response<LoginResponse>.Fail("Token error", 409);
            }

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(keyJwt));
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new(ClaimTypes.NameIdentifier, getUser.Id.ToString()),
                    new(ClaimTypes.Role, role)
                }),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            LoginResponse response = new()
            {
                Token = tokenHandler.WriteToken(token)
            };

            return Response<LoginResponse>.Success(response, 200);
        }
    }
}
