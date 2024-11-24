using AenEnterprise.FrontEndMvc.Models.HumanResource;
using AenEnterprise.ServiceImplementations.Interface;
using AenEnterprise.ServiceImplementations.Messaging.HumanResource;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AenEnterprise.FrontEndMvc.Controllers
{
    [Route("api/Attendance")]
    [ApiController]
    public class AttendanceController : ControllerBase
    {
        private readonly IAttendanceService _attendanceService;
        private readonly ILogger<AttendanceController> _logger;

        public AttendanceController(IAttendanceService attendanceService, ILogger<AttendanceController> logger)
        {
            _attendanceService = attendanceService ?? throw new ArgumentNullException(nameof(attendanceService));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> CreateAttendance([FromBody] CreateAttendanceRequest request)
        {
            if (request == null)
            {
                _logger.LogWarning("CreateAttendance request is null.");
                return BadRequest("Request cannot be null.");
            }
            var response = await _attendanceService.CreateAttendanceAsync(request);
            _logger.LogInformation("Attendance created successfully with ID {AttendanceId}", response.AttendanceId);
            return CreatedAtAction(nameof(GetAttendanceById), new { id = response.AttendanceId }, response);
        }



        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAttendanceById(int id)
        {

            var attendance = await _attendanceService.GetAttendanceByIdAsync(id); // Assuming the method exists
            if (attendance == null)
            {
                _logger.LogWarning("Attendance not found with ID {AttendanceId}", id);
                return NotFound("Attendance record not found.");
            }
            _logger.LogInformation("Attendance retrieved successfully for ID {AttendanceId}", id);
            return Ok(attendance);
        }

        //[HttpPut("{id}")]
        //public async Task<IActionResult> UpdateAttendance(int id, [FromBody] UpdateAttendanceRequest request)
        //{
        //    if (request == null)
        //    {
        //        _logger.LogWarning("UpdateAttendance request is null.");
        //        return BadRequest("Request cannot be null.");
        //    }

        //    try
        //    {
        //        var updatedAttendance = await _attendanceService.UpdateAttendanceAsync(id, request); // Assuming this method exists
        //        if (updatedAttendance == null)
        //        {
        //            _logger.LogWarning("Attendance update failed for ID {AttendanceId}", id);
        //            return NotFound("Attendance record not found.");
        //        }

        //        _logger.LogInformation("Attendance updated successfully for ID {AttendanceId}", id);
        //        return Ok(updatedAttendance);
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError(ex, "Error occurred while updating attendance with ID {AttendanceId}", id);
        //        return StatusCode(500, "Internal server error");
        //    }
        //}

        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteAttendance(int id)
        //{
        //    try
        //    {
        //        var success = await _attendanceService.DeleteAttendanceAsync(id); // Assuming this method exists
        //        if (!success)
        //        {
        //            _logger.LogWarning("Attendance deletion failed for ID {AttendanceId}", id);
        //            return NotFound("Attendance record not found.");
        //        }

        //        _logger.LogInformation("Attendance deleted successfully for ID {AttendanceId}", id);
        //        return NoContent();
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError(ex, "Error occurred while deleting attendance with ID {AttendanceId}", id);
        //        return StatusCode(500, "Internal server error");
        //    }
        //}
    }
}
