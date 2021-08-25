using Domain;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;


namespace Repository
{
    public interface IReceiptDetailRepository : IRepository<ReceiptDetail>
    {
        Task<List<ReceiptDetail>> GetByReceiptId(long id, CancellationToken cancellationToken);
    }
}