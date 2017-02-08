using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace SharedPreferences
{
    public class SecurityData
    {
        private static SecurityData staticSecurity;
        public static SecurityData init()
        {
            if (staticSecurity == null)
            {
                staticSecurity = new SecurityData();
            }

            return staticSecurity;
        }

        string tokenString { get; set; }

    }
}