using MediatR;
using MulitShop.Order.Application.Features.Meditor.Results.OrderingResults;

namespace MulitShop.Order.Application.Features.Meditor.Queries.OrderingQueries
{
    public class GetOrderingQuery : IRequest<List<GetOrderingQueryResult>>
    {


    }
}
