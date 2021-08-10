using Domain;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;


namespace Repository
{
    public interface IReceiptRepository : IRepository<Receipt>
    {
        Task<List<Receipt>> GetByReceiptId(int id, CancellationToken cancellationToken);
    }
}