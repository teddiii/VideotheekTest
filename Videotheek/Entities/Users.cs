using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Videotheek.Entities
{
    /// <summary>
    /// This is the user class for the authentication of the application
    /// </summary>
    [Table("Users")]
    public class Users : BaseEntity<Guid>
    {
        /// <summary>
        /// This checks if the model is new
        /// </summary>
        /// <returns></returns>
        public override bool IsNew()
        {
            return Id == Guid.Empty;
        }

        /// <summary>
        /// the id of the user
        /// </summary>
        [Column("user_id")]
        public override Guid Id { get; set; }

        /// <summary>
        /// first name of the user
        /// </summary>
        [Required]
        [Column("first name")]
        [StringLength(255)]
        [Display(Name = "First name")]
        public string Firstname { get; set; }

        /// <summary>
        /// last name of the user
        /// </summary>
        [Required]
        [Column("last name")]
        [StringLength(255)]
        [Display(Name = "Last name")]
        public string Lastname { get; set; }

        /// <summary>
        /// returns the full name of the user
        /// </summary>
        public string Fullname
        {
            get
            {
                return Firstname + " " + Lastname;
            }
        }

        /// <summary>
        /// the is the unique user name of the user
        /// </summary>
        [Column("user_name")]
        [StringLength(50, MinimumLength = 5)]
        [Required]
        [Display(Name = "User name")]
        [Index(IsUnique = true)]
        public string Username { get; set; }

        /// <summary>
        /// This holds the encrypted password
        /// </summary>
        [Required]
        [Column("encrypted_pwd")]
        [StringLength(255)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        /// <summary>
        /// the salt key for the encryption of the password
        /// </summary>
        [Column("pwd_salt")]
        [StringLength(255)]
        public string Salt { get; set; }

        /// <summary>
        /// the email address of the user
        /// </summary>
        [Required]
        [Column("email")]
        [StringLength(255)]
        [DataType(DataType.EmailAddress)]
        [Index(IsUnique = true)]
        public string Email { get; set; }
    }
}
