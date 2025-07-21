﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessManagementSystem.Shared.Models.ResponseModels
{
    public class StudentResponseModel
    {
		public int Id { get; set; }
		public string? FirstName { get; set; }

		public string? LastName { get; set; }

		public string? Email { get; set; }
        public string? MessNumber { get; set; }
        public string? BatchClass { get; set; }
        public double? Balance { get; set; }
        public double? SecurityFees { get; set; }
        public string Password { get; set; }
    }
}
