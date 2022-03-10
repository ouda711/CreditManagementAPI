using System;
using System.Security.Claims;
using System.Threading.Tasks;
using CreditManagementTest.Dtos.Requests.Account;
using CreditManagementTest.Dtos.Responses.Account;
using CreditManagementTest.Entities;
using CreditManagementTest.Models;
using CreditManagementTest.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CreditManagementTest.Controllers
{
    [Route("/api")]
    [Authorize]
    public class AccountController : Controller
    {
        private readonly IUsersService _usersService;
        private readonly IAccountService _accountService;

        private readonly IAuthorizationService _authorizationService;
        private readonly IConfigurationService _configService;

        public AccountController(IUsersService usersService, IAuthorizationService authorizationService, IAccountService accountService, IConfigurationService configService)
        {
            _usersService = usersService;
            _authorizationService = authorizationService;
            _configService = configService;
            _accountService = accountService;
        }
        
        [HttpPost("/accounts/create")]
        public async Task<IActionResult> Create([FromBody] CreateOrEditAccountDto model)
        {
            if (!ModelState.IsValid)
            {
                return StatusCodeAndDtoWrapper.BuilBadRequest(ModelState);
            }

            long userId = Convert.ToInt64(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            ApplicationUser user = await _usersService.GetCurrentUserAsync();
            Account account = await _accountService.CreateAsync(user, model, userId);
            
            return StatusCodeAndDtoWrapper.BuildSuccess("Account created successfully");
        }

        [Route("accounts")]
        [HttpGet]
        public async Task<IActionResult> Index([FromQuery] int page = 1, [FromQuery] int pageSize = 5)
        {
            var accounts =
                await _accountService.FetchPageByUser(await _usersService.GetCurrentUserAsync(), page, pageSize);
            var basePath = Request.Path;
            
            return StatusCodeAndDtoWrapper.BuildSuccess(AccountListDto.Build(accounts.Item2, basePath, currentPage: page, pageSize: pageSize, totalItemCount: accounts.Item1));
        }
    }
}