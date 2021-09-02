using System;
using System.Threading;
using System.Threading.Tasks;
using DAL.Models;
using Domain;
using Repository;


namespace DAL.Contracts
{
    public interface IPersonRepository : IRepository<Person>
    {
        Task<Person> GetByCode(Guid code,  CancellationToken cancellationToken);
    }
}