using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Linq.Expressions;
using WebApi.Contexts;
using WebApi.Entities;

namespace WebApi.Repositories;

public class CourseRepository(DataContext context) : Repo<CourseEntity>(context)
{
    private readonly DataContext _context = context;

    //public async override Task<IEnumerable<CourseEntity>> GetAll()
    //{
    //    try
    //    {
    //        return await _context.Courses
    //            .Include(x => x.PointList)
    //            .Include(x => x.DetailsList)
    //            .Include(x => x.Author)
    //            .Include(x => x.Reviews)
    //            .Include(x => x.Category)
    //            .ToListAsync();

    //    }
    //    catch (Exception ex)
    //    {
    //        Debug.WriteLine("ERROR :: " + ex.Message);
    //    }
    //    return null!;
    //}

    public override IQueryable<CourseEntity> GetAllAsQueryable()
    {
        try
        {
            return _context.Courses
                .Include(x => x.PointList)
                .Include(x => x.DetailsList)
                .Include(x => x.Author)
                .Include(x => x.Reviews)
                .Include(x => x.Category)
                .AsQueryable();

        }
        catch (Exception ex)
        {
            Debug.WriteLine("ERROR :: " + ex.Message);
        }
        return null!;
    }

    public async override Task<CourseEntity> GetOne(Expression<Func<CourseEntity, bool>> predicate)
    {
        try
        {
            var result = await _context.Courses
                .Include(x => x.PointList)
                .Include(x => x.DetailsList)
                .Include(x => x.Author)
                .Include(x => x.Reviews)
                .FirstOrDefaultAsync(predicate);
            if (result != null)
            {
                return result;
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine("ERROR :: " + ex.Message);
        }
        return null!;
    }
}
