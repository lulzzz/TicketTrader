﻿using System.Threading.Tasks;
using TicketTrader.Deliveries.Domain;
using TicketTrader.Deliveries.ReadModel;
using TicketTrader.Shared.Base.DDD;

namespace TicketTrader.Deliveries.Application.Events
{
    class NewDeliveryRegisteredEventHandler : IEventHandler<NewDeliveryRegisteredEvent>
    {
        private readonly IRepository<Delivery> _repository;
        private readonly IDeliveryDenormalizer _denormalizer;

        public NewDeliveryRegisteredEventHandler(IRepository<Delivery> repository, IDeliveryDenormalizer denormalizer)
        {
            _repository = repository;
            _denormalizer = denormalizer;
        }

        public async Task Handle(NewDeliveryRegisteredEvent domainEvent)
        {
            var delivery = await _repository.Get(domainEvent.DeliveryId);
            await _denormalizer.AddDelivery(delivery);
        }
    }
}