using ResumeMaker.API.DTOs.CardDTOs;
using ResumeMaker.Models;

namespace ResumeMaker.API.Services
{
    public interface ICardService
    {
        Task<ServiceResponse<GetCardDto>> AddUserCard(string token, AddCardDto userInfo);
        Task<ServiceResponse<GetCardDto>> ModifyUserCard(string token, ModifyCardDto userInfo);

    }
}
