using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EY4J5D_HFT_2021221.Models
{
    [Table("Car_Brand")]
    public class Brand
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [NotMapped]
        [Required]
        [MaxLength(50)]
        public string BrandName { get; set; }

        [NotMapped]
        public virtual ICollection<Model> Models { get; set; }
    }
}
