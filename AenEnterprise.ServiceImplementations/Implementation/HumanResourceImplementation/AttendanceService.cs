using AenEnterprise.DataAccess.RepositoryInterface.HumanResourceRepositoriesInterace;
using AenEnterprise.DataAccess.RepositoryInterface;
using AenEnterprise.DomainModel.HumanResources;
using AenEnterprise.ServiceImplementations.Interface;
using AenEnterprise.ServiceImplementations.Messaging.HumanResource;
using AutoMapper;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StackExchange.Redis;
using AenEnterprise.ServiceImplementations.ViewModel.HumanResource;
using AenEnterprise.ServiceImplementations.Mapping.Automappers;

namespace AenEnterprise.ServiceImplementations.Implementation.HumanResourceImplementation
{
    public class AttendanceService : BaseService, IAttendanceService
    {
        private readonly IAttendanceRepository _attendanceRepository;

        public AttendanceService(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            IDatabase redisDb,
            ILogger<AttendanceService> logger,
            RedisConnection redisConnection,
            IAttendanceRepository attendanceRepository)
            : base(unitOfWork, mapper,redisDb, redisConnection, logger)
        {
            _attendanceRepository = attendanceRepository;
        }

        public async Task<CreateAttendanceResponse> CreateAttendanceAsync(CreateAttendanceRequest request)
        {
            var attendance = new Attendance
            {
                Status = request.Status,
                CheckInTime = request.CheckInTime,
                CheckOutTime = request.CheckOutTime,
                LeaveTypeId = request.LeaveTypeId,
                Remarks = request.Remarks,
                EmployeeId = request.EmployeeId,
                PiecesProduced = request.PiecesProduced,
            };
              
            await _attendanceRepository.AddAsync(attendance);
            await _unitOfWork.SaveAsync();

            return new CreateAttendanceResponse
            {
                AttendanceId = attendance.Id
            };
        }

        public async Task<GetAttendanceResponse> GetAttendanceByIdAsync(int id)
        {
            GetAttendanceResponse response = new GetAttendanceResponse();

            var attendance = await _attendanceRepository.GetByIdAsync(id);
            if (attendance == null)
            {
                _logger.LogWarning("Attendance record not found with ID {AttendanceId}", id);
                return null;
            }

            response.Attendance=attendance.ConvertToView<Attendance,AttendanceView>(_mapper);
            return response;
        }

        //public async Task<AttendanceView> UpdateAttendanceAsync(int id, UpdateAttendanceRequest request)
        //{
        //    var attendance = await _attendanceRepository.GetByIdAsync(id);
        //    if (attendance == null)
        //    {
        //        _logger.LogWarning("Attendance record not found for update with ID {AttendanceId}", id);
        //        return null;
        //    }

        //    // Update attendance properties
        //    attendance.Status = request.Status;
        //    attendance.CheckInTime = request.CheckInTime;
        //    attendance.CheckOutTime = request.CheckOutTime;
        //    attendance.LeaveTypeId = request.LeaveTypeId;
        //    attendance.Remarks = request.Remarks;
        //    attendance.PiecesProduced = request.PiecesProduced;
        //    attendance.UpdatedAt = DateTime.Now;

        //    _attendanceRepository.Update(attendance);
        //    await _unitOfWork.SaveAsync();

        //    return _mapper.Map<AttendanceView>(attendance);
        //}

        //public async Task<bool> DeleteAttendanceAsync(int id)
        //{
        //    var attendance = await _attendanceRepository.GetByIdAsync(id);
        //    if (attendance == null)
        //    {
        //        _logger.LogWarning("Attendance record not found for deletion with ID {AttendanceId}", id);
        //        return false;
        //    }

        //    _attendanceRepository.Delete(attendance);
        //    await _unitOfWork.SaveAsync();

        //    _logger.LogInformation("Attendance record deleted with ID {AttendanceId}", id);
        //    return true;
        //}
    }
}
