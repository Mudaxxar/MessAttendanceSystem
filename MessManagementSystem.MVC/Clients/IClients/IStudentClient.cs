using MessManagementSystem.Shared.Models;
using MessManagementSystem.Shared.Models.RequestModels;
using MessManagementSystem.Shared.Models.ResponseModels;

namespace MessManagementSystem.MVC.Clients.IClients
{
	public interface IStudentClient
	{
		Task<StudentResponseModel> GetStudent(int Id);
		Task<ApiResponse<string>> MarkAttendance(AttendanceRequestModel input);
		Task<ApiResponse<string>> CreateFeedback(FeedbackRequestModel input);
		Task<ApiResponse<List<FeedbackResponseModel>>> GetFeedbacks();
	}
}
