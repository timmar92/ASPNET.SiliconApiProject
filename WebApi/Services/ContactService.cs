using WebApi.Dtos;
using WebApi.Entities;
using WebApi.Repositories;

namespace WebApi.Services;

public class ContactService(ContactRepository contactRepository)
{
    private readonly ContactRepository _contactRepository = contactRepository;

    public async Task<ContactEntity> CreateContactFormAsync(ContactFormDto dto)
    {
        try
        {

            var contactForm = new ContactEntity
            {
                FullName = dto.FullName,
                Email = dto.Email,
                SelectedOption = dto.SelectedOption,
                Message = dto.Message
            };

            return await _contactRepository.CreateOne(contactForm);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

}
