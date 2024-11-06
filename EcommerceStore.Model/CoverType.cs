using System.ComponentModel.DataAnnotations;

namespace EcommerceStore.Model
{
    public class CoverType
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
