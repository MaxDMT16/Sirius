using System.Threading.Tasks;
using SiriusCRM.Abstractions.Contracts;

namespace SiriusCRM.Abstractions.Buses
{
    public interface IQueryBus
    {
        Task<TQueryResult> Execute<TQuery, TQueryResult>(TQuery query)
            where TQueryResult : IQueryResult
            where TQuery : IQuery<TQueryResult>;
    }
}