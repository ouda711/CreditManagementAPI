using System;
using System.Security.Claims;
using System.Threading.Tasks;
using CreditManagementTest.Dtos.Requests.Invoice;
using CreditManagementTest.Entities;
using CreditManagementTest.Models;
using CreditManagementTest.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Migrations.Internal;

namespace CreditManagementTest.Controllers
{
    [Route("api/")]
    [Authorize]
    public class InvoiceController : Controller
    {
        private readonly IUsersService _usersService;
        private readonly IInvoiceService _invoiceService;
        private readonly IAuthorizationService _authorization;
        private readonly IConfigurationService _configService;

        public InvoiceController(IUsersService usersService, IAuthorizationService authorizationService,
            IInvoiceService invoiceService, IConfigurationService configService)
        {
            _usersService = usersService;
            _authorization = authorizationService;
            _configService = configService;
            _invoiceService = invoiceService;
        }

        [Authorize]
        [HttpPost("invoices/{name}/create")]
        public async Task<IActionResult> Create(string name, [FromBody] CreateOrEditInvoiceDto model)
        {
            if(!ModelState.IsValid)
                return StatusCodeAndDtoWrapper.BuilBadRequest(ModelState);
            long userId = Convert.ToInt64(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            ApplicationUser user = await _usersService.GetCurrentUserAsync();
            Invoice invoice = await _invoiceService.CreateAsync(user, name, model, userId);
            
            return StatusCodeAndDtoWrapper.BuildSuccess("Invoice created");
        }
    }
}