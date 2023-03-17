using Lahor.Core.Enumerations;
using Microsoft.AspNetCore.Http;

namespace Lahor.Core.Dto
{
    public class EmployeeInsertDto
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public IFormFile? File { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public Gender? Gender { get; set; }
        public string? ProfilePhoto { get; set; }
        public string? ProfilePhotoThumbnail { get; set; }
        public int? BirthPlaceId { get; set; }
        public string Jmbg { get; set; }
        public string Qualifications { get; set; }
        public int? PlaceOfResidenceId { get; set; }
        public MarriageStatus? MarriageStatus { get; set; }
        public string Nationality { get; set; }
        public string Citizenship { get; set; }
        public bool WorkExperience { get; set; }
        public string Address { get; set; }
        public string PostCode { get; set; }
        public string PhoneNumber { get; set; }
        public string Biography { get; set; }
        public Position Position { get; set; }
        public DrivingLicence DrivingLicence { get; set; }
        public DateTime DateOfEmployment { get; set; }
        public float Pay { get; set; }
    }
}
