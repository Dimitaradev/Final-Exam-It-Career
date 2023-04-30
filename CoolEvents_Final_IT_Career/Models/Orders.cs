using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CoolEvents_Final_IT_Career.Models
{
    public class Orders
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]

        public int EventId { get; set; }

        public virtual Events Event { get; set; }
        [Required]

        public string UserId { get; set; }
        public virtual Users User { get; set; }
    }
}
