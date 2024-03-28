using Microsoft.AspNetCore.Http.HttpResults;
using WebApi.Dtos.User;
using WebApi.Entities.User;
using WebApi.Helpers;
using WebApi.Repositories.Users;

namespace WebApi.Services;

public class UserService(UserRepository userRepository)
{
    private readonly UserRepository _userRepository = userRepository;


    public async Task<UserEntity> RegisterUser(UserRegistrationDto dto)
    {
        try
        {
            var user = new UserEntity
            {
                Id = Guid.NewGuid().ToString(),
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Email = dto.Email,
                Password = PasswordHasher.GenerateSecurePassword(dto.Password)
            };

            await _userRepository.CreateOne(user);

            return user;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
        
    }
}
