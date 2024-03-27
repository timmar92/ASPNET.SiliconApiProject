using Microsoft.AspNetCore.Hosting;
using WebApi.Dtos;
using WebApi.Entities;
using WebApi.Repositories;

namespace WebApi.Services;

public class SubscriberService(SubscriberRepository subscriberRepository)
{
    private readonly SubscriberRepository _subscriberRepository = subscriberRepository;


    public async Task<SubscriberEntity> CreateSubscriberAsync(SubscriberDto dto)
    {
        try
        {
            var subscriber = new SubscriberEntity
            {
                Email = dto.Email,
                Events = dto.Events,
                DailyNews = dto.DailyNews,
                WeekReview = dto.WeekReview,
                Advertising = dto.Advertising,
                Startups = dto.Startups,
                Podcasts = dto.Podcasts
            };
            await _subscriberRepository.CreateOne(subscriber);
            return subscriber;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public async Task<bool> DeleteSubscriber(string email)
    {
        try
        {
            var subscriber = await _subscriberRepository.GetOne(x => x.Email == email);
            if (subscriber != null)
            {
                await _subscriberRepository.DeleteOne(x => x.Email == email);
                return true;
            }
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
        return false;
    }

    public async Task<bool> SubscriberExists(string email)
    {
        try
        {
            var subscriber = await _subscriberRepository.ExistsAsync(x => x.Email == email);
            return subscriber;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}
