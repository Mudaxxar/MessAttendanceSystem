using FluentValidation;

namespace MessManagementSystem.Shared.Models
{
	public class PaginationParams
	{

		private const int MaxPageSize = 100;

		public int _pageNumber { get; set; } = 1;
		public string? Search { get; set; } = string.Empty;
		public string? SortOrder { get; set; } = "Desc";
		public string? SortBy { get; set; } = "Id";
		private int _pageSize = 10;

		public int PageSize
		{
			get => _pageSize;
			set => _pageSize = (value > MaxPageSize) ? MaxPageSize : value;
		}

		public int PageNumber
		{
			get => _pageNumber;
			set => _pageNumber =  value;
		}


	}
	public class ParamValidations : AbstractValidator<PaginationParams>
	{
		public ParamValidations()
		{
			RuleFor(p => p.PageNumber).NotEqual(0).NotEmpty().WithMessage("PageNumber should be greater than 0");
			RuleFor(p => p.PageSize).NotEqual(0);
		}
	}
}
