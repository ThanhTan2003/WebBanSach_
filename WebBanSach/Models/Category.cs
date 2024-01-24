using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebBanSach.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        //[Required]
        [DisplayName("Name")]
        [Required(ErrorMessage = "Tên thể loại không hợp lệ!")]
        public string Name { get; set; }

        //[Required]
        [DisplayName("DisplayOrder")]
        [Required(ErrorMessage = "Dislay Order không hợp lệ!")]
        public string DisplayOrder { get; set; }


        public DateTime CreateDateTime { get; set; } = DateTime.Now;
    }
}
