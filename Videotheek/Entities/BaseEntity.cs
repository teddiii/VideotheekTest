using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Videotheek.Entities
{
    /// <summary>
    /// This is the generic base entity for 
    /// all our entities in the database
    /// </summary>
    /// <typeparam name="T">The type of the ID</typeparam>
    public abstract class BaseEntity<T>
    {
        /// <summary>
        /// Gets/sets the unique Id of our entity
        /// </summary>
        public abstract T Id { get; set; }

        /// <summary>
        /// Gets/sets the moment when the entity is created
        /// </summary>
        [Column("created_at")]
        [Required]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Gets/sets the moment when the entity is modified
        /// </summary>
        [Column("modified_at")]
        [Required]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime ModifiedAt { get; set; }

        /// <summary>
        /// Gets/sets the moment when the entity is deleted
        /// </summary>
        [Column("deleted_at")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? DeletedAt { get; set; }

        /// <summary>
        /// Checks if the object is new
        /// </summary>
        /// <returns></returns>
        public abstract bool IsNew();

        /// <summary>
        /// Default constructor
        /// </summary>
        public BaseEntity()
        {
            CreatedAt = ModifiedAt = DateTime.Now;
        }
    }
}