using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EY4J5D_HFT_2021221.Models
{
    [Table("Car")]
    public class Car_Model
    {
        [NotMapped]
        public string Model_Name { get; set; }
        [Key]
        public int Id { get; set; }
        [ForeignKey("Car_Brand")]
        public int Brand_Id { get; set; }
        [NotMapped]
        public virtual ICollection<Purchase> Purchases { get; set; }
        public virtual Car_Brand Brand { get; set; }
    }
}
