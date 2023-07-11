﻿using Customers.Consumer.Messages;
using MediatR;

namespace Customers.Consumer.Handlers;

public class CustomerDeletedHandler : IRequestHandler<CustomerDeleted>
{
    private readonly ILogger<CustomerCreatedHandler> _logger;

    public CustomerDeletedHandler(ILogger<CustomerCreatedHandler> logger)
    {
        _logger = logger;
    }

    public Task Handle(CustomerDeleted request, CancellationToken cancellationToken)
    {
        _logger.LogInformation(request.Id.ToString());
        return Unit.Task;
    }
}
