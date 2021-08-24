using Common.Utilities;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Domain;

namespace Services
{
    public interface IPersonService
    {
        Task<PersonDTO> Create(PersonDTO modelDto, CancellationToken cancellationToken);
        Task<bool> DeleteAsync(long id, CancellationToken cancellationToken);
        Task<PersonDTO> UpdateAsync(long id, PersonDTO modelDto, CancellationToken cancellationToken);
        Task<PagedResult<Person>> GetAllAsync(int? page, int? pageSize, string orderBy, CancellationToken cancellationToken);
        Task<List<PersonDTO>> GetAsync(CancellationToken cancellationToken);
    }
}
