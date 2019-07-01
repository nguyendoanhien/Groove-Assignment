using System.ComponentModel.DataAnnotations;

namespace PersonalNotesAPI.Models
{
    public abstract class BaseModel
    {
      
        public int Id { get; set; }

        [Timestamp]
        public byte[] Timestamp { get; set; }
    }
}
