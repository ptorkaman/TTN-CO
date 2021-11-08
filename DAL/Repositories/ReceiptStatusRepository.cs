using Domain;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DAL.Models;

namespace Repository
{
    public class ReceiptStatusRepository : Repository<ReceiptStatus>, IReceiptStatusRepository
    {


        public ReceiptStatusRepository(TTNContext dbContext) : base(dbContext)
        {

        }    

        

        ReceiptStatus IReceiptStatusRepository.GetByCode(int code, CancellationToken cancellationToken)
        {
            return  Table.Where(x => x.IsActive && x.Code == code).FirstOrDefault();
        }
    }
}
