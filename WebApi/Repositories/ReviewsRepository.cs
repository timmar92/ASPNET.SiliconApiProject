using WebApi.Contexts;
using WebApi.Entities;

namespace WebApi.Repositories;

public class ReviewsRepository(DataContext context) : Repo<Reviews>(context)
{
    private readonly DataContext _context = context;
}
