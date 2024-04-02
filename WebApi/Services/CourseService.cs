using WebApi.Dtos;
using WebApi.Entities;
using WebApi.Repositories;

namespace WebApi.Services;

public class CourseService(CourseRepository courseRepository, AuthorRepository authorRepository, DetailsListRepository detailsListRepository, PointListRepository pointListRepository, ReviewsRepository reviewsRepository)
{
    private readonly CourseRepository _courseRepository = courseRepository;
    private readonly AuthorRepository _authorRepository = authorRepository;
    private readonly DetailsListRepository _detailsListRepository = detailsListRepository;
    private readonly PointListRepository _pointListRepository = pointListRepository;
    private readonly ReviewsRepository _reviewsRepository = reviewsRepository;

    // Create

    public async Task<CourseEntity> CreateCourseAsync(CreateCourseDto dto)
    {
        try
        {
            var courseDto = dto.Course;
            var authorDto = dto.Author;
            var detailsListDto = dto.DetailsList;
            var pointListDto = dto.PointList;
            var reviewsDto = dto.Reviews;

            var course = new CourseEntity
            {
                Title = courseDto.Title,
                Subtitle = courseDto.Subtitle,
                Description = courseDto.Description,
                ImageUrl = courseDto.ImageUrl,
                ArticleNumber = courseDto.ArticleNumber,
                DownloadResource = courseDto.DownloadResource,
                Price = courseDto.Price,
                DiscountPrice = courseDto.DiscountPrice,
                Hours = courseDto.Hours,
                IsBestSeller = courseDto.IsBestSeller,
                LikesInNumbers = courseDto.LikesInNumbers,
                LikesInPercent = courseDto.LikesInPercent,
            };
            course = await _courseRepository.CreateOne(course);


            var author = new Author
            {
                Name = authorDto!.Name,
                ImageUrl = authorDto.ImageUrl,
                Description = authorDto.Description,
                YoutubeUrl = authorDto.YoutubeUrl,
                FacebookUrl = authorDto.FacebookUrl,
                CourseEntityId = course.Id
            };
            author = await _authorRepository.CreateOne(author);


            var detailsList = new DetailsList
            {
                Detail_1 = detailsListDto!.Detail_1,
                Detail_2 = detailsListDto.Detail_2,
                Detail_3 = detailsListDto.Detail_3,
                Detail_4 = detailsListDto.Detail_4,
                Detail_5 = detailsListDto.Detail_5,
                Detail_6 = detailsListDto.Detail_6,
                Detail_7 = detailsListDto.Detail_7,
                Detail_8 = detailsListDto.Detail_8,
                Detail_9 = detailsListDto.Detail_9,
                Detail_10 = detailsListDto.Detail_10,
                CourseEntityId = course.Id
            };
            detailsList = await _detailsListRepository.CreateOne(detailsList);


            var pointList = new PointList
            {
                Point_1 = pointListDto!.Point_1,
                Point_2 = pointListDto.Point_2,
                Point_3 = pointListDto.Point_3,
                Point_4 = pointListDto.Point_4,
                Point_5 = pointListDto.Point_5,
                Point_6 = pointListDto.Point_6,
                Point_7 = pointListDto.Point_7,
                Point_8 = pointListDto.Point_8,
                Point_9 = pointListDto.Point_9,
                Point_10 = pointListDto.Point_10,
                CourseEntityId = course.Id
            };
            pointList = await _pointListRepository.CreateOne(pointList);


            var reviews = new Reviews
            {
                ReviewNumbers = reviewsDto!.ReviewNumbers,
                FullStarUrl = reviewsDto.FullStarUrl,
                EmptyStarUrl = reviewsDto.EmptyStarUrl,
                CourseEntityId = course.Id
            };
            reviews = await _reviewsRepository.CreateOne(reviews);

            course.Author = author;
            course.DetailsList = detailsList;
            course.PointList = pointList;
            course.Reviews = reviews;

            return course;
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }

    // Read

    public async Task<bool> CourseExistsAsync(string title)
    {
        try
        {
            if (title != null)
            {
                return await _courseRepository.ExistsAsync(x => x.Title == title);
            }

        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
        return false;
    }


    public async Task<CourseEntity> GetCourseByTitleAsync(string title)
    {
        try
        {
            if (title != null)
            {
                return await _courseRepository.GetOne(x => x.Title == title);
            }

        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
        return null!;
    }

    public async Task<CourseEntity> GetCourseByIdAsync(int id)
    {
        try
        {
            if (id != 0)
            {
                return await _courseRepository.GetOne(x => x.Id == id);
            }

        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
        return null!;
    }

    public async Task<IEnumerable<CourseEntity>> GetAllCoursesAsync()
    {
        try
        {
            return await _courseRepository.GetAll();
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }


    // Update

    public async Task<bool> UpdateCourseAsync(int id, UpdateCourseDto dto)
    {
        try
        {
            var courseDto = dto.Course;
            var detailsListDto = dto.DetailsList;
            var pointListDto = dto.PointList;
            var reviewsDto = dto.Reviews;

            var existingCourse = await _courseRepository.GetOne(x => x.Id == id);

            if (existingCourse == null)
            {
                return false;
            }

            if (existingCourse != null)
            {
                existingCourse.Title = courseDto.Title;
                existingCourse.Subtitle = courseDto.Subtitle;
                existingCourse.Description = courseDto.Description;
                existingCourse.ImageUrl = courseDto.ImageUrl;
                existingCourse.ArticleNumber = courseDto.ArticleNumber;
                existingCourse.DownloadResource = courseDto.DownloadResource;
                existingCourse.Price = courseDto.Price;
                existingCourse.DiscountPrice = courseDto.DiscountPrice;
                existingCourse.Hours = courseDto.Hours;
                existingCourse.IsBestSeller = courseDto.IsBestSeller;
                existingCourse.LikesInNumbers = courseDto.LikesInNumbers;
                existingCourse.LikesInPercent = courseDto.LikesInPercent;
            }

            if (detailsListDto != null && existingCourse!.DetailsList != null)
            {
                existingCourse.DetailsList.Detail_1 = detailsListDto.Detail_1;
                existingCourse.DetailsList.Detail_2 = detailsListDto.Detail_2;
                existingCourse.DetailsList.Detail_3 = detailsListDto.Detail_3;
                existingCourse.DetailsList.Detail_4 = detailsListDto.Detail_4;
                existingCourse.DetailsList.Detail_5 = detailsListDto.Detail_5;
                existingCourse.DetailsList.Detail_6 = detailsListDto.Detail_6;
                existingCourse.DetailsList.Detail_7 = detailsListDto.Detail_7;
                existingCourse.DetailsList.Detail_8 = detailsListDto.Detail_8;
                existingCourse.DetailsList.Detail_9 = detailsListDto.Detail_9;
                existingCourse.DetailsList.Detail_10 = detailsListDto.Detail_10;
            }

            if (pointListDto != null && existingCourse!.PointList != null)
            {
                existingCourse.PointList.Point_1 = pointListDto.Point_1;
                existingCourse.PointList.Point_2 = pointListDto.Point_2;
                existingCourse.PointList.Point_3 = pointListDto.Point_3;
                existingCourse.PointList.Point_4 = pointListDto.Point_4;
                existingCourse.PointList.Point_5 = pointListDto.Point_5;
                existingCourse.PointList.Point_6 = pointListDto.Point_6;
                existingCourse.PointList.Point_7 = pointListDto.Point_7;
                existingCourse.PointList.Point_8 = pointListDto.Point_8;
                existingCourse.PointList.Point_9 = pointListDto.Point_9;
                existingCourse.PointList.Point_10 = pointListDto.Point_10;
            }

            if (reviewsDto != null && existingCourse!.Reviews != null)
            {
                existingCourse.Reviews.ReviewNumbers = reviewsDto.ReviewNumbers;
                existingCourse.Reviews.FullStarUrl = reviewsDto.FullStarUrl;
                existingCourse.Reviews.EmptyStarUrl = reviewsDto.EmptyStarUrl;
            }

            await _courseRepository.UpdateOne(existingCourse!);

            return true;

        }


        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }

    // Delete

    public async Task<bool> DeleteCourseAsync(int id)
    {
        try
        {
            var existingCourse = await _courseRepository.GetOne(x => x.Id == id);
            if (existingCourse != null)
            {
                await _courseRepository.DeleteOne(x => x.Id == id);
                await _authorRepository.DeleteOne(x => x.CourseEntityId == id);
                await _detailsListRepository.DeleteOne(x => x.CourseEntityId == id);
                await _pointListRepository.DeleteOne(x => x.CourseEntityId == id);
                await _reviewsRepository.DeleteOne(x => x.CourseEntityId == id);
                return true;
            }
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
        return false;
    }
}
