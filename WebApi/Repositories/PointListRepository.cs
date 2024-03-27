using WebApi.Contexts;
using WebApi.Entities;

namespace WebApi.Repositories;

public class PointListRepository(DataContext context) : Repo<PointList>(context)
{
    private readonly DataContext _context = context;
}
