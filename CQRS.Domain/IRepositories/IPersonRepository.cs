using CQRS.Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.Domain.IRepositories
{
    public interface IPersonRepository
    {
        Task<List<Person>> GetPersonsAsync();
        Task<List<Person>> GetPersonsAsync_Lambda();
        Task<List<Person>> GetPersonsAsync_Sql();
    }
}
