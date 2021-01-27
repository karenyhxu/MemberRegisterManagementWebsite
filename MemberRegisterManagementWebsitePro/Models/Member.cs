using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MemberRegisterManagementWebsitePro.Models {
    public class Member {

        [Key]
        public int MemberId { get; set; }

        [Column(TypeName = "nvarchar(250)")]
        [Required(ErrorMessage = "This field is required")]
        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [Column(TypeName = "nvarchar(250)")]
        [Required(ErrorMessage = "This field is required")]
        [DisplayName("Last Name")]
        public string LastName { get; set; }

        [Column(TypeName = "varchar(100)")]
        public string Email { get; set; }

        [Column(TypeName = "varchar(100)")]
        public string PhoneNumber { get; set; }
    }
}
