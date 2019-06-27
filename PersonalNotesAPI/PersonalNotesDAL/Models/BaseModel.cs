using System.ComponentModel.DataAnnotations;

namespace PersonalNotesDAL.Models
{
    public abstract class BaseModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public byte[] Timestamp { get; set; }
    }
}
