﻿using System.Threading.Tasks;
using TicketTrader.Orders.Canonical.Queries;
using TicketTrader.Orders.Domain;
using TicketTrader.Orders.Domain.Queries;
using TicketTrader.Orders.Domain.Queries.ReadModels;
using TicketTrader.Shared.Base.CQRS.Commands;

namespace TicketTrader.Orders.Application.Queries.Handlers
{
    class GetSelectedPaymentQueryHandler : IQueryHandler<GetSelectedPaymentQuery, GetSelectedPaymentQuery.Response>
    {
        private readonly DomainActorSystem _domainActorSystem;

        public GetSelectedPaymentQueryHandler(DomainActorSystem domainActorSystem)
        {
            _domainActorSystem = domainActorSystem;
        }

        public async Task<GetSelectedPaymentQuery.Response> Handle(GetSelectedPaymentQuery query)
        {
            var response = await _domainActorSystem.Query<RespondSelectedPayment>(new GetSelectedPayment(query.ClientId, query.OrderId));

            var value = response == null ? null : new GetSelectedPaymentQuery.PaymentDto
            {
                OrderId = response.Id,
                PaymentId = response.PaymentId
            };

            return new GetSelectedPaymentQuery.Response
            {
                Value = value
            };
        }
    }
}