using Microsoft.EntityFrameworkCore;
using WebApi.Entities;

namespace WebApi.Contexts;

public class DataContext(DbContextOptions<DataContext> options) : DbContext(options)
{
    public DbSet<CourseEntity> Courses { get; set; }
    public DbSet<PointList> pointLists { get; set; }
    public DbSet<DetailsList> detailsLists { get; set; }
    public DbSet<Author> Authors { get; set; }
    public DbSet<Reviews> Reviews { get; set; }

    public DbSet<SubscriberEntity> Subscribers { get; set; }

    public DbSet<ContactEntity> ContactForms { get; set; }

    public DbSet<CategoryEntity> Categories { get; set; }
}
