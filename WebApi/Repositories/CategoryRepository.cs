using WebApi.Contexts;
using WebApi.Entities;

namespace WebApi.Repositories;

public class CategoryRepository(DataContext context) : Repo<CategoryEntity>(context)
{
    private readonly DataContext _context = context;
}
