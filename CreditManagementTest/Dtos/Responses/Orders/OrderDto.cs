using System;
using System.Collections.Generic;
using CreditManagementTest.Dtos.Responses.Category;
using CreditManagementTest.Dtos.Responses.Products;
using CreditManagementTest.Dtos.Responses.Tag;
using CreditManagementTest.Dtos.Responses.User;
using CreditManagementTest.Entities;
using CreditManagementTest.Enums;

namespace CreditManagementTest.Dtos.Responses.Orders
{
    public class OrderDto
    {
        public long Id { get; set; }
        public string TrackingNumber { get; set; }
        public ShippingStatus OrderStatus { get; set; }
        public UserBasicEmbeddedInfoDto User { get; set; }
        public AddressDto Address { get; set; }


        public static OrderDto Build(Order order, bool includeUser = false)
        {
            var dto = new OrderDto
            {
                Id = order.Id,
                TrackingNumber = order.TrackingNumber,
                OrderStatus = order.OrderStatus,
                Address = AddressDto.Build(order.Address),
            };

            if (includeUser)
                dto.User = UserBasicEmbeddedInfoDto.Build(order.User);

            return dto;
        }
    }
}