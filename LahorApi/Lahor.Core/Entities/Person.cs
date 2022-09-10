using Lahor.Core.Entities.Base;
using Lahor.Core.Enumerations;

namespace Lahor.Core.Entities
{
    public class Person:BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Gender { get; set; }
        public string ProfilePhoto { get; set; }
        public string ProfilePhotoThumbnail { get; set; }
        public int? BirthPlaceId { get; set; }
        public City BirthPlace { get; set; }
        public string JMBG { get; set; }
        public string Qualifications { get; set; }
        public int? PlaceOfResidenceId { get; set; }
        public City PlaceOfResidence { get; set; }
        public int? MarriageStatusId { get; set; }
        public MarriageStatus MarriageStatus { get; set; }
        public string Nationality { get; set; }
        public string Citizenship { get; set; }
        public bool WorkExperience { get; set; }
        public string Biography { get; set; }
        public Position Position { get; set; }
        public DrivingLicence DrivingLicence { get; set; }
        public DateTime DateOfEmployment { get; set; }
        public float Pay { get; set; }
        public bool MembershipCard { get; set; }
        public int ApplicationUserId { get; set; }

    }
}
