using System.ComponentModel.DataAnnotations;

namespace BlacksmithWorkshopDatabaseImplement.Models
{
    public class ManufactureComponent
    {
        public int Id { get; set; }
        [Required]
        public int ManufactureId { get; set; }
        [Required]
        public int ComponentId { get; set; }
        [Required]
        public int Count { get; set; }
        public virtual Component Component { get; set; } = new();
        public virtual Manufacture Manufacture { get; set; } = new();
    }
}
