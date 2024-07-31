using App.Application.DTOs.PersonDTOs;
using App.Application.Profiles;
using App.Application.UnitOfWorks;
using App.Domain.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace UnifOfWork.Controllers
{
    public class PersonsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public PersonsController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] PersonCreateDTO createDTO)
        {
            Person person = _mapper.Map<Person>(createDTO);
            await _unitOfWork.RepositoryPerson.InsertAsync(person);
            await _unitOfWork.CommitAsync();
            return Ok(person);

        }


    }
}
