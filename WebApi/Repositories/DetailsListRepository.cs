using WebApi.Contexts;
using WebApi.Entities;

namespace WebApi.Repositories;

public class DetailsListRepository(DataContext context) : Repo<DetailsList>(context)
{
    private readonly DataContext _context = context;
}
