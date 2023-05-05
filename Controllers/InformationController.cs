using Microsoft.AspNetCore.Mvc;
using ResumeMaker.API.DTOs;
using ResumeMaker.Models;

namespace ResumeMaker.API.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class InformationController : ControllerBase
    {
        public InformationController() { }

        [HttpPost]
        public Task<ActionResult<ServiceResponse<string>>> AddUserInformation(UserInformationDto userInfo)
        {
            return null;
        }

        [HttpGet]
        public Task<ActionResult<ServiceResponse<UserInformationDto>>> GetUserInformation()
        {
            return null;
        }

        [HttpDelete]
        public Task<ActionResult<ServiceResponse<string>>> RemoveUserInformation(UserInformationDto userInfo)
        {
            return null;
        }


    }
}
