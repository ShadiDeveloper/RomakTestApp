using EFCoreProject.Infrastructure;
using EFCoreProject.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreProject.Repositories
{
    public interface IPersonRepository
    {
        Task<List<Person>> GetPersonsAsync();
        Task<List<Person>> GetPersonsAsync_Lambda();
        Task<List<Person>> GetPersonsAsync_Sql();
    }

    public class PersonRepository: IPersonRepository
    {
        private readonly EFCoreDbContext _dbContext;

        public PersonRepository(EFCoreDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public Task<List<Person>> GetPersonsAsync()
        {
            return _dbContext.Persons.ToListAsync();
        }

        public Task<List<Person>> GetPersonsAsync_Lambda()
        {
            return (from p in _dbContext.Persons select p).ToListAsync();
        }

        public async Task<List<Person>> GetPersonsAsync_Sql()
        {
            await _dbContext.Database.ExecuteSqlRawAsync("SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED;");
            string query = string.Format($"SELECT * FROM persons");
            return await _dbContext.Set<Person>().FromSqlRaw(query).ToListAsync();
        }
    }
}
