using System.Threading.Tasks;
using SiriusCRM.Abstractions.CQRS.Contracts;

namespace SiriusCRM.Abstractions.CQRS.Buses
{
    public interface IQueryBus
    {
        Task<TQueryResult> Execute<TQuery, TQueryResult>(TQuery query)
            where TQueryResult : IQueryResult
            where TQuery : IQuery<TQueryResult>;
    }
}