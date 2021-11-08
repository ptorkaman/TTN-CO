using Domain;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;


namespace Repository
{
    public interface IReceiptStatusRepository : IRepository<ReceiptStatus>
    {
        ReceiptStatus GetByCode(int code, CancellationToken cancellationToken);
    }
}