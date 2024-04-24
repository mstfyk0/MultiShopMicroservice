using MediatR;
using MulitShop.Order.Application.Features.Meditor.Queries.OrderingQueries;
using MulitShop.Order.Application.Features.Meditor.Results.OrderingResults;
using MulitShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;


namespace MulitShop.Order.Application.Features.Meditor.Handlers.OrderingHandlers
{
    public class GetOrderingByIdQueryHandler : IRequestHandler<GetOrderingByIdQuery, GetOrderingByIdQueryResult>
    {

        private readonly IRepository<Ordering> _repository;

        public GetOrderingByIdQueryHandler(IRepository<Ordering> repository)
        {
            _repository = repository;
        }

        public async Task<GetOrderingByIdQueryResult> Handle(GetOrderingByIdQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.Id);
            return new GetOrderingByIdQueryResult
            {
                OrderDate = values.OrderDate,
                OrderingId = values.OrderingId,
                TotalPrice = values.TotalPrice,
                UserId = values.UserId,
            };
        }
    }
}
