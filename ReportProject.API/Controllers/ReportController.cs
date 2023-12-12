using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ReportProject.DataService.Repositories.Interfaces;
using ReportProject.Entities.Dtos.Requests;
using ReportProject.Entities.Models;

namespace ReportProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]

    public class ReportController : BaseController
    {
        public ReportController(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }


        [HttpPost]
        public async Task<IActionResult> AddReport([FromBody] ReportRequestDto report,CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid) return BadRequest();
            var result = _mapper.Map<Report>(report);
            await _unitOfWork.Reports.Add(result, cancellationToken);
            await _unitOfWork.CompleteAsync(cancellationToken);
            return Ok(result);
        }

        [HttpDelete]
        [Route("{ReportId:Guid}")]
        public async Task<IActionResult> DeleteReport(Guid ReportId,CancellationToken cancellationToken)
        {
            var person = await _unitOfWork.Reports.GetById(ReportId);
            if (person == null) return NotFound("Rapor Bulunamadı.");

            await _unitOfWork.Reports.Delete(ReportId, cancellationToken);
            await _unitOfWork.CompleteAsync(cancellationToken);
            return NoContent();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateReport ([FromBody] UpdateReportDto _report, CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid) return BadRequest();

            var report = _mapper.Map<Report>(_report);
            var result = await _unitOfWork.Reports.Update(report, cancellationToken);
            if (result) await _unitOfWork.CompleteAsync(cancellationToken);
            else return BadRequest("Kullanıcı Bulunamadı.");

            return NoContent();
        }
    }
}
