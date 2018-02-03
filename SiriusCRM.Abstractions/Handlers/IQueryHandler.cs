using System.Threading.Tasks;
using SiriusCRM.Abstractions.Contracts;

namespace SiriusCRM.Abstractions.Handlers
{
    public interface IQueryHandler<TQuery, TQueryResult>
        where TQueryResult : IQueryResult
        where TQuery : IQuery<TQueryResult>
    {
        Task<TQueryResult> Execute(TQuery query);
    }
}