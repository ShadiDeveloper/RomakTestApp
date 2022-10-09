using CQRS.Application.Dtos;
using CQRS.Domain.IRepositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.Application.Commands.PersonCommands
{
    public class PersonCommand:IRequest<List<PersonDTO>>
    {
    }

    public class PersonCommandHandler : IRequestHandler<PersonCommand,List<PersonDTO>>
    {
        private readonly IPersonRepository _personRepository;

        public PersonCommandHandler(IPersonRepository personRepository)
        {
            this._personRepository = personRepository;
        }
        public async Task<List<PersonDTO>> Handle(PersonCommand request, CancellationToken cancellationToken)
        {
            var persons = await _personRepository.GetPersonsAsync();
            return persons.Select(p=>new PersonDTO
            {
                Id=p.Id,
                FullName=p.FullName
            }).ToList();
        }
    }
}
