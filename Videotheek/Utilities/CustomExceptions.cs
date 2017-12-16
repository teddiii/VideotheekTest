using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Videotheek.Utilities
{
    /// <summary>
    /// Custom exception for when the user is not found (in login)
    /// </summary>
    public class UserNotFoundException : Exception
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public UserNotFoundException() : base("User is not found.") { }

        /// <summary>
        /// Custom exception
        /// </summary>
        /// <param name="name"></param>
        public UserNotFoundException(string name) : base($"User with as user name or email address '{name}' is not found") { }
    }
}
