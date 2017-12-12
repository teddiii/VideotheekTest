using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Videotheek.ERP.Extensions
{
    public static class ControlExtensions
    {
        public static void SetCursorOnEnd(this PasswordBox passwordBox)
        {
            int start = passwordBox.Password.Length;
            int length = 0;
            passwordBox.SetSelection(start, length);
        }

        public static void SetSelection(this PasswordBox passwordBox, int start, int length)
        {
            passwordBox.GetType().GetMethod("Select", BindingFlags.Instance | BindingFlags.NonPublic).Invoke(passwordBox, new object[] { start, length });
        }
    }
}
