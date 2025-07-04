using AutoMapper;
using MessManagementSystem.Shared.Models.RequestModels;
using MessManagementSystem.Shared.Models.ResponseModels;
using MessManagemetSystem.API.Entities;
using MessManagemetSystem.API.Identity;


namespace MessManagemetSystem.API.MApping
{
    public class MappingConfiguration : Profile
	{
		public MappingConfiguration()
		{
		
			CreateMap<RegistrationRequestModel, ApplicationUser>();
			CreateMap<ApplicationUser, UserResponseModel>();
			CreateMap<PermissionEntity, PermissionResponseModel>();
			CreateMap<MenuEntity, MenuResponseModel>();
			CreateMap<FeedbackEntity, FeedbackResponseModel>();

		}
	}
}
