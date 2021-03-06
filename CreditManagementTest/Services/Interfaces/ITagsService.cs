using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CreditManagementTest.Entities;
using Microsoft.AspNetCore.Http;

namespace CreditManagementTest.Services.Interfaces
{
    public interface ITagsService
    {
        Task<Tag> Create(string name, string description, List<IFormFile> files);
        Task<Tuple<int, List<Tag>>> FetchPage(int page, int pageSize);
        Task<Tuple<int, List<Tag>>> FetchPageWithImages(int page, int pageSize);
    }
}