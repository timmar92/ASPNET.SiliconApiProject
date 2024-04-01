using WebApi.Contexts;
using WebApi.Entities;

namespace WebApi.Repositories;

public class ContactRepository(DataContext context) : Repo<ContactEntity>(context)
{
    private readonly DataContext _context = context;
}
