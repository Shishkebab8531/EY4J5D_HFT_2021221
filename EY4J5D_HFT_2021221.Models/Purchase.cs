using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace EY4J5D_HFT_2021221.Models
{
    [Table("Purchases")]
    public class Purchase
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [ForeignKey("Models")]
        public int Model_Id { get; set; }
        public DateTime Purchase_Date { get; set; }
        [Required]
        public int Price { get; set; }
        [NotMapped]
        [JsonIgnore]
        public virtual Model Model { get; set; }
    }
}
