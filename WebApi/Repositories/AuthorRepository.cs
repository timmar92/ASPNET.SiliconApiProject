using WebApi.Contexts;
using WebApi.Entities;

namespace WebApi.Repositories;

public class AuthorRepository(DataContext context) : Repo<Author>(context)
{
    private readonly DataContext _context = context;
}
