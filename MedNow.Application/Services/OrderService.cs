using MedNow.Domain.Commands;
using MedNow.Domain.Commands.Order;
using MedNow.Infra.Contracts.Repositories;
using MedNow.Application.Contracts.Services;
using MedNow.Domain.Entities;
using MedNow.Domain.ValueObjects;
using System.Threading.Tasks;

namespace MedNow.Application.Services
{
    public class OrderService : IOrderService
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
                return new CommandResponse<Order>(null, command.Notifications);
            }

            var user = await _userRepository.GetById(command.UserId);
            var creditCard = new CreditCard(command.CreditCard.Number, command.CreditCard.Name, command.CreditCard.Cvv, command.CreditCard.ExpirationDate);
            var address = new Address(command.Address.ZipCode, command.Address.Street, command.Address.Number, command.Address.Neighborhood, command.Address.City, command.Address.State);

            var order = new Order(user, creditCard, address);

            if(!order.IsValid)
            {
                return new CommandResponse<Order>(null, order.Notifications);
            }

            foreach (var item in command.Products)
            {
                var product = await _productRepository.GetById(item.Id);
                var orderItem = new OrderItem(order.Id, product, item.Quantity);

                if (!orderItem.IsValid)
                {
                    return new CommandResponse<Order>(null, orderItem.Notifications);
                }

                order.AddOrderItem(orderItem);
            }

            await _orderRepository.CreateOrder(order);

            return new CommandResponse<Order>(order, order.Notifications);
        }
    }
}
