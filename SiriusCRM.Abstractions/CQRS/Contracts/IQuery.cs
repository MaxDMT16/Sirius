namespace SiriusCRM.Abstractions.CQRS.Contracts
{
    public interface IQuery<TQueryResult>
        where TQueryResult : IQueryResult
    {
        
    }
}