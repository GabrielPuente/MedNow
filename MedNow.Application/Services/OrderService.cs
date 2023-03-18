using MedNow.Application.Commands;
using MedNow.Application.Commands.Order;
using MedNow.Application.Contracts.Services;
using MedNow.Domain.Entities;
using MedNow.Domain.ValueObjects;
using MedNow.Infra.Contracts;

namespace MedNow.Application.Services
{
    public class OrderService : CommandHandler, IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IUserRepository _userRepository;
        private readonly IProductRepository _productRepository;

        public OrderService(IOrderRepository orderRepository, IProductRepository productRepository, IUserRepository userRepository)
        {
            _orderRepository = orderRepository;
            _productRepository = productRepository;
            _userRepository = userRepository;
        }

        public async Task<CommandResponse<Order>> CreateOrder(CreateOrderCommand command)
        {
            command.Validate();

            if (!command.IsValid)
            {
                return Fail<Order>(null, command.Notifications);
            }

            var user = await _userRepository.GetById(command.UserId);
            var order = new Order(user);

            if (!order.IsValid)
            {
                return Fail<Order>(null, order.Notifications);
            }

            foreach (var item in command.Products)
            {
                var product = await _productRepository.GetById(item.Id);
                var orderItem = new OrderItem(order.Id, product, item.Quantity);

                if (!orderItem.IsValid)
                {
                    return Fail<Order>(null, orderItem.Notifications);
                }

                order.AddOrderItem(orderItem);
            }

            await _orderRepository.CreateOrder(order);

            return Ok(order, order.Notifications);
        }
    }
}
