﻿using EventBus.Base.Abstraction;
using MediatR;
using Microsoft.Extensions.Logging;
using OrderService.Api.IntegrationEvents.Events;
using OrderService.Application.Features.Commands.CreateOrder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderService.Api.IntegrationEvents.EventHandlers
{
    public class OrderCreatedIntegrationEventHandler : IIntegrationEventHandler<OrderCreatedIntegrationEvent>
    {
        private readonly IMediator mediator;
        private readonly ILogger<OrderCreatedIntegrationEventHandler> logger;

        public OrderCreatedIntegrationEventHandler(IMediator mediator, ILogger<OrderCreatedIntegrationEventHandler> logger)
        {
            this.mediator = mediator;
            this.logger = logger;
        }

        public async Task Handle(OrderCreatedIntegrationEvent @event)
        {
            logger.LogInformation("Handling integration event: {IntegrationEventId} at {AppName} - ({@IntegrationEvent})",
                @event.Id,
                typeof(Startup).Namespace,
                @event);

            var createOrderCommand = new CreateOrderCommand(@event.Basket.Items, @event.UserId,
                @event.UserName, @event.City, @event.Street,
                @event.State, @event.Country, @event.CardNumber,
                @event.ZipCode, @event.CardHolderName, @event.CardExpiration,
                @event.CardSecurityNumber, @event.CardTypeId, @event.CorrelationId);

            await mediator.Send(createOrderCommand);
        }
    }
}
