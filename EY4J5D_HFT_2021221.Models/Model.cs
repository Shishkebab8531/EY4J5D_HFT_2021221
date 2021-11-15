using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EY4J5D_HFT_2021221.Models
{
    [Table("Car")]
    public class Model
    {
        [NotMapped]
        [Required]
        [MaxLength(50)]
        public string Model_Name { get; set; }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [ForeignKey("Car_Brand")]
        public int Brand_Id { get; set; }
        [NotMapped]
        public virtual ICollection<Purchase> Purchases { get; set; }
        public virtual Brand Brand { get; set; }
    }
}
