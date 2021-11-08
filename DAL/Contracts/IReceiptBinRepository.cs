using Domain;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;


namespace Repository
{
    public interface IReceiptBinRepository : IRepository<ReceiptBin>
    {
        Task<List<ReceiptBin>> GetByReceiptBinId(int id, CancellationToken cancellationToken);
    }
}