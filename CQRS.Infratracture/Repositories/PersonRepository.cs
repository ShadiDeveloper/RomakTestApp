using CQRS.Domain.IRepositories;
using CQRS.Domain.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.Infrastructure.Repositories
{
    public class PersonRepository: IPersonRepository
    {
        private readonly CqrsDbContext _dbContext;

        public PersonRepository(CqrsDbContext dbContext)
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
