using System;
using System.Security.Claims;
using System.Threading.Tasks;
using CreditManagementTest.Dtos.Requests.CreditDetail;
using CreditManagementTest.Dtos.Responses.Comments;
using CreditManagementTest.Dtos.Responses.CustomerCreditDetail;
using CreditManagementTest.Dtos.Responses.Shared;
using CreditManagementTest.Entities;
using CreditManagementTest.Models;
using CreditManagementTest.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CreditManagementTest.Controllers
{
    [Route("api/")]
    public class CustomerCreditDetailContoller : Controller
    {
        private readonly IUsersService _usersService;
        private readonly ICustomerCreditDetail _creditDetail;
        private readonly IAuthorizationService _authorizationService;
        private readonly IConfigurationService _configService;

        public CustomerCreditDetailContoller(IUsersService usersService, IAuthorizationService authorizationService,
            ICustomerCreditDetail customerCreditDetail, IConfigurationService configService)
        {
            _usersService = usersService;
            _authorizationService = authorizationService;
            _configService = configService;
            _creditDetail = customerCreditDetail;
        }

        [Authorize]
        [HttpPost("/credit-details")]
        public async Task<IActionResult> Create([FromBody] CreateOrEditCreditDetailDto model)
        {
            if(!ModelState.IsValid)
                return StatusCodeAndDtoWrapper.BuilBadRequest(ModelState);

            long userId = Convert.ToInt64(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            ApplicationUser user = await _usersService.GetCurrentUserAsync();
            CustomerCreditDetail customerCreditDetails = await _creditDetail.CreateAsync(user, model, userId);
            
            return StatusCodeAndDtoWrapper.BuildSuccess(CustomerDetailDto.Build(customerCreditDetails));
        }

        [Authorize]
        [HttpGet("/credit-details")]
        public async Task<IActionResult> GetCreditDetails(ApplicationUser user)
        {
            long userId = Convert.ToInt64(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            user = await _usersService.GetCurrentUserAsync();
            CustomerCreditDetail customerCreditDetail = await _creditDetail.GetByUserAsync(userId);

            if (customerCreditDetail == null)
            {
                return StatusCodeAndDtoWrapper.BuildErrorResponse("Not found");
            }
            return StatusCodeAndDtoWrapper.BuildSuccess("Found");
        }

        [Authorize]
        [HttpGet("/get-details")]
        public async Task<IActionResult> GetActualDetails(ApplicationUser user)
        {
            long userId = Convert.ToInt64(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            user = await _usersService.GetCurrentUserAsync();
            CustomerCreditDetail customerCreditDetail = await _creditDetail.GetByUserAsync(userId);
            if (customerCreditDetail == null)
            {
                return StatusCodeAndDtoWrapper.BuildErrorResponse("Not found");
            }
            return StatusCodeAndDtoWrapper.BuildSuccess(CustomerDetailDto.Build(customerCreditDetail));
        }

    }
}