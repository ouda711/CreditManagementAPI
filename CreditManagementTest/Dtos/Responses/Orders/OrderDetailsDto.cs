using System.Collections;
using System.Collections.Generic;
using CreditManagementTest.Dtos.Responses.OrderItems;
using CreditManagementTest.Dtos.Responses.Products;
using CreditManagementTest.Dtos.Responses.Shared;
using CreditManagementTest.Dtos.Responses.User;
using CreditManagementTest.Entities;
using CreditManagementTest.Enums;

namespace CreditManagementTest.Dtos.Responses.Orders
{
    public class OrderDetailsDto : SuccessResponse
    {
        public long Id { get; set; }
        public string TrackingNumber { get; set; }
        public ShippingStatus OrderStatus { get; set; }
        public UserBasicEmbeddedInfoDto User { get; set; }
        public AddressDto Address { get; set; }
        public ICollection<OrderItemDto> OrderItems { get; set; }

        public static OrderDetailsDto Build(Order order, bool includeUser = false)
        {
            List<OrderItemDto> orderItemDtos = new List<OrderItemDto>(order.OrderItems.Count);
                
            foreach (var orderItem in order.OrderItems)
            {
                orderItemDtos.Add(OrderItemDto.Build(orderItem));
            }
            
            var dto = new OrderDetailsDto
            {
                Id = order.Id,
                TrackingNumber = order.TrackingNumber,
                OrderStatus = order.OrderStatus,
                Address = AddressDto.Build(order.Address),
                OrderItems = orderItemDtos
            };

            return dto;
        }
    }
}