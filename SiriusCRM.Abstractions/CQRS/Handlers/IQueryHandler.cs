using System.Threading.Tasks;
using SiriusCRM.Abstractions.CQRS.Contracts;

namespace SiriusCRM.Abstractions.CQRS.Handlers
{
    public interface IQueryHandler<in TQuery, TQueryResult>
        where TQueryResult : IQueryResult
        where TQuery : IQuery<TQueryResult>
    {
        Task<TQueryResult> Execute(TQuery query);
    }
}