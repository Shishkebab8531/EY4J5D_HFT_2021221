using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace EY4J5D_HFT_2021221.Models
{
    [Table("Models")]
    public class Model
    {
        [Required]
        [MaxLength(50)]
        public string Model_Name { get; set; }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [ForeignKey("Brands")]
        public int Brand_Id { get; set; }
        [NotMapped]
        public virtual Brand Brand { get; set; }
        [NotMapped]
        [JsonIgnore]
        public virtual ICollection<Purchase> Purchases { get; set; }
    }
}
