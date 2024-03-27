using WebApi.Contexts;
using WebApi.Entities;

namespace WebApi.Repositories
{
    public class SubscriberRepository(DataContext context) : Repo<SubscriberEntity>(context)
    {
        private readonly DataContext _context = context;
    }
}
