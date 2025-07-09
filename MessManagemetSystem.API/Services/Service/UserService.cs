using MessManagementSystem.Shared.Models;
using MessManagementSystem.Shared.Models.RequestModels;
using MessManagementSystem.Shared.Models.ResponseModels;
using MessManagemetSystem.API.Entities;
using MessManagemetSystem.API.Identity;
using MessManagemetSystem.API.Repository.GenericRepository;
using MessManagemetSystem.API.Services.IService;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MessManagemetSystem.API.Services.Service
{
    public class UserService : IUserService
	{

		private UserManager<ApplicationUser> _userManger;
		private RoleManager<UserRoles> _roleManager;
		private IConfiguration _configuration;
		private readonly IPermissionService _permissionService;
		private readonly IUnitOfWork _unitOfWork;
		public UserService(UserManager<ApplicationUser> userManager,
			IConfiguration configuration
			, IPermissionService permissionService
            , RoleManager<UserRoles> roleManager
			, IUnitOfWork unitOfWork
            )
		{
			_userManger = userManager;
			_configuration = configuration;
			_permissionService = permissionService;
			_roleManager = roleManager;
			_unitOfWork = unitOfWork;


        }

		public async Task<UserManagerResponse> RegisterUserAsync(RegistrationRequestModel model)
		{
			if (model == null)
				throw new NullReferenceException("Reigster Model is null");

			if (model.Password != model.ConfirmPassword)
				return new UserManagerResponse
				{
					Message = "Confirm password doesn't match the password",
					IsSuccess = false,
				};

			var existing = await _userManger.Users.FirstOrDefaultAsync(x => x.MessNumber == model.MessNumber);
			if (existing != null)
			{
				return new UserManagerResponse
				{
                    Message = "Mess number Already in use",
                    IsSuccess = false,
                };
			}
            var identityUser = new ApplicationUser
			{
				Email = model.Email,
				UserName = model.Email,
				FirstName = model.FirstName,
				//LastName = model.LastName,
				SecurityStamp = Guid.NewGuid().ToString(),
				RoleId = model.RoleId,
				Active = true,
				MessNumber = model.MessNumber,
				BatchClass = model.BatchClass,
				Balance = model.Balance,
				DecodedPassword = model.Password,
				
			};

			var result = await _userManger.CreateAsync(identityUser, model.Password);

			if (result.Succeeded)
			{
				if (model.Balance > 0)
				{

					var accountRepo = _unitOfWork.GetRepository<AccountsEntity>();
					// Create an account for the user
					var account = await accountRepo.AddAsync(new AccountsEntity
					{
						ApplicationUserId = identityUser.Id,
						Credit = Convert.ToDecimal(model.Balance),
						Balance = Convert.ToDecimal(model.Balance),
					});
					await accountRepo.AddAsync(account);
					await _unitOfWork.CommitAsync();
				}
				// Assign user to role
				var role = await _roleManager.FindByIdAsync(model.RoleId.ToString());
				if (role != null)
				{
					var roleResult = await _userManger.AddToRoleAsync(identityUser, role.Name);
					if (!roleResult.Succeeded)
					{
						return new UserManagerResponse
						{
							Message = "User created but failed to assign role",
							IsSuccess = false,
							Errors = roleResult.Errors.Select(e => e.Description)
						};
					}
				}
				else
				{
					return new UserManagerResponse
					{
						Message = "Invalid Role ID",
						IsSuccess = false
					};
				}
                    //Email confirmation
                    var confirmEmailToken = await _userManger.GenerateEmailConfirmationTokenAsync(identityUser);

				var encodedEmailToken = Encoding.UTF8.GetBytes(confirmEmailToken);
				var validEmailToken = WebEncoders.Base64UrlEncode(encodedEmailToken);

				string url = $"{_configuration["AppUrl"]}/api/account/confirmemail?userid={identityUser.Id}&token={validEmailToken}";

				//await _mailService.SendEmailAsync(identityUser.Email, "Confirm your email", $"<h1>Welcome to Auth Demo</h1>" +
				//    $"<p>Please confirm your email by <a href='{url}'>Clicking here</a></p>");


				return new UserManagerResponse
				{
					Message = "User created successfully!",
					IsSuccess = true,
					Token = validEmailToken,
					UserId = identityUser.Id
				};
			}

			return new UserManagerResponse
			{
				Message = $"{"User did not create"}-{result.Errors.Select(e => e.Description)}",
				IsSuccess = false,
				Errors = result.Errors.Select(e => e.Description)
			};

		}

		public async Task<UserManagerResponse> LoginUserAsync(LoginRequestModel model)
		{
			var user = await _userManger.FindByEmailAsync(model.Email);

			if (user == null)
			{
				return new UserManagerResponse
				{
					Message = "There is no user with that Email address",
					IsSuccess = false,
				};
			}

			// Check if the user is active
			if (!user.Active.GetValueOrDefault())
			{
				return new UserManagerResponse
				{
					Message = "User is not active.",
					IsSuccess = false,
				};
			}

			var result = await _userManger.CheckPasswordAsync(user, model.Password);

			if (!result)
				return new UserManagerResponse
				{
					Message = "Invalid password",
					IsSuccess = false,
				};
            var roles = await _userManger.GetRolesAsync(user); // This is the fix
            var roleName = roles.FirstOrDefault();
            var authClaims = new List<Claim>
				{
					new Claim("UserId", user.Id.ToString()),
					new Claim(ClaimTypes.NameIdentifier, user.UserName),
					new Claim(ClaimTypes.Email, user.Email),
					new Claim(CustomClaims.AdminId, user.RoleId.ToString()),
                    //new Claim(ClaimTypes.Role, roleName), // e.g., "Admin" or "Student"
					new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
				};

			// Getting Permissions
			HashSet<string> permissions = await _permissionService.GetPermissionsAsync(user.Id);
			foreach (var permission in permissions)
			{
				authClaims.Add(new(CustomClaims.Permissions, permission));
			}
			var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT-Authentication:Secret"]));
			var token = new JwtSecurityToken(
				issuer: _configuration["JWT-Authentication:ValidIssuer"],
				audience: _configuration["JWT-Authentication:ValidAudience"],
				claims: authClaims,
				expires: DateTime.Now.AddDays(1),
				signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256));
			string tokenAsString = new JwtSecurityTokenHandler().WriteToken(token);

			return new UserManagerResponse
			{
				Message = "Login Successfully",
				Token = tokenAsString,
				IsSuccess = true,
				ExpireDate = token.ValidTo,
                RoleId = user.RoleId,
				
			};
		}

		public async Task<UserManagerResponse> ConfirmEmailAsync(string userId, string token)
		{
			var user = await _userManger.FindByIdAsync(userId);
			if (user == null)
				return new UserManagerResponse
				{
					IsSuccess = false,
					Message = "User not found"
				};

			var decodedToken = WebEncoders.Base64UrlDecode(token);
			string normalToken = Encoding.UTF8.GetString(decodedToken);

			var result = await _userManger.ConfirmEmailAsync(user, normalToken);

			if (result.Succeeded)
				return new UserManagerResponse
				{
					Message = "Email confirmed successfully!",
					IsSuccess = true,
				};

			return new UserManagerResponse
			{
				IsSuccess = false,
				Message = "Email did not confirm",
				Errors = result.Errors.Select(e => e.Description)
			};
		}
		[HttpPost("ForgetPassword")]
		public async Task<UserManagerResponse> ForgetPasswordAsync(string email)
		{
			var user = await _userManger.FindByEmailAsync(email);
			if (user == null)
				return new UserManagerResponse
				{
					IsSuccess = false,
					Message = "No user associated with email",
				};

			var token = await _userManger.GeneratePasswordResetTokenAsync(user);
			var encodedToken = Encoding.UTF8.GetBytes(token);
			var validToken = WebEncoders.Base64UrlEncode(encodedToken);

			string url = $"{_configuration["AppUrl"]}/ResetPassword?email={email}&token={validToken}";

			//await _mailService.SendEmailAsync(email, "Reset Password", "<h1>Follow the instructions to reset your password</h1>" +
			//   $"<p>To reset your password <a href='{url}'>Click here</a></p>");

			return new UserManagerResponse
			{
				IsSuccess = true,
				Token = validToken,
				Message = "Reset password URL has been sent to the email successfully!",
			};
		}

		public async Task<UserManagerResponse> ResetPasswordAsync(ResetPasswordRequestModel model)
		{
			var user = await _userManger.FindByEmailAsync(model.Email);
			if (user == null)
				return new UserManagerResponse
				{
					IsSuccess = false,
					Message = "No user associated with email",
				};

			if (model.NewPassword != model.ConfirmPassword)
				return new UserManagerResponse
				{
					IsSuccess = false,
					Message = "Password doesn't match its confirmation",
				};

			var decodedToken = WebEncoders.Base64UrlDecode(model.Token);
			string normalToken = Encoding.UTF8.GetString(decodedToken);

			var result = await _userManger.ResetPasswordAsync(user, normalToken, model.NewPassword);

			if (result.Succeeded)
				return new UserManagerResponse
				{
					Message = "Password has been reset successfully!",
					IsSuccess = true,
				};

			return new UserManagerResponse
			{
				Message = "Something went wrong",
				IsSuccess = false,
				Errors = result.Errors.Select(e => e.Description),
			};
		}


		public async Task<PaginatedResponseModel<UserResponseModel>> GetUsers(PaginationParams paginationParams)
		{
			var query = _userManger.Users.AsQueryable();
			if (!string.IsNullOrEmpty(paginationParams.Search))
			{
				string searchTerm = paginationParams.Search.ToLower();
				query = query.Where(u =>
					u.FirstName.ToLower().Contains(searchTerm) ||
					u.BatchClass.ToLower().Contains(searchTerm) ||
					u.Email.ToLower().Contains(searchTerm) ||
					u.MessNumber.ToLower().Contains(searchTerm) ||
					u.Role.Name.ToLower().Contains(searchTerm));
			}
			var result = await query
				.Select(u => new UserResponseModel
				{
					Id = u.Id,
					FirstName = u.FirstName,
					LastName = u.LastName,
					Email = u.Email,
					Role = u.Role.Name,
					Active = u.Active,
					MessNumber = u.MessNumber,
					Balance = u.Balance,
					BatchClass = u.BatchClass
					
				})
				.ToListAsync();

			var totalRecords = result.Count();

			return new PaginatedResponseModel<UserResponseModel>
			{
				TotalRecords = totalRecords,
				Records = result,
				PaginationParam = paginationParams
			};
		}

		public async Task<UserManagerResponse> UserStatus(int id)
		{
			var user = await _userManger.FindByIdAsync(id.ToString());
			if (user == null)
			{
				return new UserManagerResponse
				{
					IsSuccess = false,
					Message = "User not found",
				};
			}

			user.Active = !user.Active;

			var result = await _userManger.UpdateAsync(user);

			if (result.Succeeded)
			{
				return new UserManagerResponse
				{
					IsSuccess = true,
					Message = "Status updated successfully",
				};
			}
			else
			{
				return new UserManagerResponse
				{
					IsSuccess = false,
					Message = "Failed to updated status",
					Errors = result.Errors.Select(e => e.Description),
				};
			}
		}

		public async Task<double> UsersCount()
		{
			var count = await _userManger.Users
				.Where(x => x.RoleId == 2).CountAsync();
			return count;
		}

		public async Task<UserResponseModel> GetUser(string email)
		{
			var result =  await _userManger.Users
				.Where(x => x.Email == email).FirstOrDefaultAsync();
			return new UserResponseModel
			{
				Id = result.Id,
				FirstName = result.FirstName,
				LastName = result.LastName,
				Email = result.Email,
				Role = result?.Role?.Name,
				Active = result.Active,
				MessNumber = result.MessNumber,
				Balance = (double)result.Balance,
				BatchClass = result.BatchClass
			};
		}

        public async Task<UserManagerResponse> UpdateAttendance(AttendanceRequestModel input)
        {
            var user = await _userManger.FindByIdAsync(input.userId);
            if (user == null)
            {
                return new UserManagerResponse
                {
                    IsSuccess = false,
                    Message = "User not found",
                };
            }

			user.LastStatusChange = DateTime.Today;
			user.Status = input.Status;
            var result = await _userManger.UpdateAsync(user);

            if (result.Succeeded)
            {
                return new UserManagerResponse
                {
                    IsSuccess = true,
                    Message = "Status updated successfully",
                };
            }
            else
            {
                return new UserManagerResponse
                {
                    IsSuccess = false,
                    Message = "Failed to updated status",
                    Errors = result.Errors.Select(e => e.Description),
                };
            }
        }
    }
}
