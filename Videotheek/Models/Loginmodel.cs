using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Videotheek.Models
{
    /// <summary>
    /// the login model for authentication
    /// </summary>
    public class Loginmodel
    {
        /// <summary>
        /// the email address or username given in by the user
        /// </summary>
        public string CredentialName { get; set; }

        /// <summary>
        /// the password given in by the user
        /// </summary>
        public string Password { get; set; }
    }
}
