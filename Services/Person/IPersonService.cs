using Common.Utilities;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Services
{
    public interface IPersonService
    {
        Task<PersonDTO> Create(PersonDTO modelDto, CancellationToken cancellationToken);
        Task<bool> DeletePersonAsync(int id, CancellationToken cancellationToken);
        Task<PersonDTO> UpdatePersonAsync(int id, PersonDTO modelDto, CancellationToken cancellationToken);
        Task<List<PersonDTO>> GetAllAsync( CancellationToken cancellationToken);
        Task<PagedResult<PersonDTO>> GetAllAsync(int? page, int? pageSize, string orderBy, CancellationToken cancellationToken);
    }
}
