using System;
using System.ComponentModel.DataAnnotations;

namespace Project.Api.Modules.Applicants.Models.Dto
{
    public class AbitDocumentDto
    {
        public int Id { get; set; }

        public int? DocumentCode { get; set; }

        public string? Discipline { get; set; }

        public string? Score { get; set; }

        public string? Status { get; set; }
    }
}