using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Videotheek.Entities
{

    /// <summary>
    /// An entity class of our products
    /// </summary>
    [Table("Products")]
    public class Product : BaseEntity<int>
    {
        /// <summary>
        /// Overrides the id of the abstract class
        /// </summary>
        [Key]
        [Column("id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public override int Id { get; set; }

        /// <summary>
        /// Gets/sets the name of the product
        /// </summary>
        [Column("name")]
        [StringLength(255, ErrorMessage = "The name can maximum have 255 characters.")]
        [Required(ErrorMessage = "The name is required.")]
        public string Name { get; set; }

        /// <summary>
        /// Gets/sets the genre of the product
        /// </summary>
        [Column("genre")]
        public string Genre { get; set; }

        [Column("year")]
        public int Year { get; set; }

        /// <summary>
        /// Gets/sets the unit price of the product
        /// </summary>
        [Column("unit_price")]
        [Required(ErrorMessage = "Price is required")]
        [Range(0.00, 999999999, ErrorMessage = "Price must be greater than 0,00")]
        [DisplayName("Unit price (€)")]
        [DisplayFormat(DataFormatString = "{0:0,0}")]
        public decimal UnitPrice { get; set; }
        
        /// <summary>
        /// Gets/sets the reservation state of the product
        /// </summary>
        [Column("is_reserved")]
        [DisplayName("Is reserved?")]
        public bool IsReserved { get; set; }

        public override bool IsNew()
        {
            return this.Id == 0;
        }
    }
}
