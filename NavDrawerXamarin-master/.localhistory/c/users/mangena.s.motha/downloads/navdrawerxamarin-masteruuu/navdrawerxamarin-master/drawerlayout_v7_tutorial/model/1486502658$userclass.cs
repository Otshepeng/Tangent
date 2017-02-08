using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Java.Lang;

namespace DrawerLayout_V7_Tutorial.Model
{
  public class UserClass:IParcelable
    {
        public string id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string username { get; set; }
        public string email { get; set; }
        public bool is_staff { get; set; }
        public bool is_superuser { get; set; }

        public IntPtr Handle
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public int DescribeContents()
        {
            throw new NotImplementedException();
        }

        public void WriteToParcel(Parcel dest, [GeneratedEnum] ParcelableWriteFlags flags)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}