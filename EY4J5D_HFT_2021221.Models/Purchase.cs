using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EY4J5D_HFT_2021221.Models
{
    [Table("Purchases")]
    public class Purchase
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [ForeignKey("Car_Model")]
        public int Car_Id { get; set; }
        [NotMapped]
        DateTime purchase_date;
        [NotMapped]
        public int Price { get; set; }
        [NotMapped]
        public virtual Car_Model Model { get; set; }
    }
}
