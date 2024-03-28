using WebApi.Contexts;
using WebApi.Entities.User;

namespace WebApi.Repositories.Users;

public class UserRepository(DataContext context) : Repo<UserEntity>(context)
{
    private readonly DataContext _context = context;
}
