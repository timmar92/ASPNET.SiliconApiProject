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

    public async Task<CourseEntity> UpdateCourseAsync(int id, CourseDto courseDto, AuthorDto authorDto, DetailsListDto detailsListDto, PointListDto pointListDto, ReviewsDto reviewsDto)
    {
        try
        {
            var existingCourse = await _courseRepository.GetOne(x => x.Id == id);

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



            var existingAuthor = await _authorRepository.GetOne(x => x.CourseEntityId == id);
            if (existingAuthor != null)
            {
                existingAuthor.Name = authorDto.Name;
                existingAuthor.ImageUrl = authorDto.ImageUrl;
                existingAuthor.Description = authorDto.Description;
                existingAuthor.YoutubeUrl = authorDto.YoutubeUrl;
                existingAuthor.FacebookUrl = authorDto.FacebookUrl;
            }
            await _authorRepository.UpdateOne(existingAuthor!);



            var existingDetailsList = await _detailsListRepository.GetOne(x => x.CourseEntityId == id);
            if (existingDetailsList != null)
            {
                existingDetailsList.Detail_1 = detailsListDto.Detail_1;
                existingDetailsList.Detail_2 = detailsListDto.Detail_2;
                existingDetailsList.Detail_3 = detailsListDto.Detail_3;
                existingDetailsList.Detail_4 = detailsListDto.Detail_4;
                existingDetailsList.Detail_5 = detailsListDto.Detail_5;
                existingDetailsList.Detail_6 = detailsListDto.Detail_6;
                existingDetailsList.Detail_7 = detailsListDto.Detail_7;
                existingDetailsList.Detail_8 = detailsListDto.Detail_8;
                existingDetailsList.Detail_9 = detailsListDto.Detail_9;
                existingDetailsList.Detail_10 = detailsListDto.Detail_10;
            }
            await _detailsListRepository.UpdateOne(existingDetailsList!);



            var existingPointList = await _pointListRepository.GetOne(x => x.CourseEntityId == id);
            if (existingPointList != null)
            {
                existingPointList.Point_1 = pointListDto.Point_1;
                existingPointList.Point_2 = pointListDto.Point_2;
                existingPointList.Point_3 = pointListDto.Point_3;
                existingPointList.Point_4 = pointListDto.Point_4;
                existingPointList.Point_5 = pointListDto.Point_5;
                existingPointList.Point_6 = pointListDto.Point_6;
                existingPointList.Point_7 = pointListDto.Point_7;
                existingPointList.Point_8 = pointListDto.Point_8;
                existingPointList.Point_9 = pointListDto.Point_9;
                existingPointList.Point_10 = pointListDto.Point_10;
            }
            await _pointListRepository.UpdateOne(existingPointList!);




            var existingReviews = await _reviewsRepository.GetOne(x => x.CourseEntityId == id);
            if (existingReviews != null)
            {
                existingReviews.ReviewNumbers = reviewsDto.ReviewNumbers;
                existingReviews.FullStarUrl = reviewsDto.FullStarUrl;
                existingReviews.EmptyStarUrl = reviewsDto.EmptyStarUrl;
            }
            await _reviewsRepository.UpdateOne(existingReviews!);


            return await _courseRepository.UpdateOne(existingCourse!);
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
