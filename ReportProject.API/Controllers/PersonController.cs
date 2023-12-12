using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ReportProject.DataService.Repositories.Interfaces;
using ReportProject.Entities.Dtos.Requests;
using ReportProject.Entities.Models;
using System.Threading;

namespace ReportProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PersonController : BaseController
    {
        public PersonController(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        [HttpPost]
        public async Task<IActionResult> AddPerson([FromBody] PersonRequestDto person, CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid) return BadRequest();
            var result = _mapper.Map<Person>(person);
            await _unitOfWork.Persons.Add(result, cancellationToken);
            await _unitOfWork.CompleteAsync(cancellationToken);
            return Ok(result);
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var person = await _unitOfWork.Persons.All();
            return Ok(person);
        }

        [HttpPut]
        public async Task<IActionResult> UpdatePerson([FromBody] UpdatePersonDto person, CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid) return BadRequest();

            var result = _mapper.Map<Person>(person);
            var resultx =  await _unitOfWork.Persons.Update(result, cancellationToken);
            if(resultx) await _unitOfWork.CompleteAsync(cancellationToken);
            else return BadRequest("Kullanıcı Bulunamadı.");
            return NoContent();
        }

        [HttpDelete]
        [Route("{Id:Guid}")]
         public async Task<IActionResult> DeletePerson(Guid Id, CancellationToken cancellationToken)
        {
            var person = await _unitOfWork.Persons.GetById(Id);
            if (person == null) return NotFound("Kullanıcı Bulunamadı.");

            await _unitOfWork.Persons.Delete(Id, cancellationToken);
            await _unitOfWork.CompleteAsync(cancellationToken);
            return NoContent();
        }


    }
}
