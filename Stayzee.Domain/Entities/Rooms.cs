using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stayzee.Domain.Entities
{
    public class Rooms
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Required(ErrorMessage = "Room Id is required")]
        [DisplayName("Room Id")]
        public int RoomId { get; set; }
        [ForeignKey("Villa")]
        [Required(ErrorMessage = "Villa Id is required")]
        [DisplayName("Villa Id")]
        public int Villa_Id { get; set; }
        [Required(ErrorMessage ="Villa Name is required")]
        [DisplayName("Villa Name")]
        public string VillaName { get; set; }
        //Nevigation Property
        public Villa Villa { get; set; }
        [DisplayName("Specific Details")]
        public string? SpecificDetails { get; set; }
    }
}
