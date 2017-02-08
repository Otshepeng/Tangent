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
using DrawerLayout_V7_Tutorial.Model;

namespace DrawerLayout_V7_Tutorial.Adapter
{
    public class UserAdapter : BaseAdapter<UserClass>
    {
        List<UserClass> userList;
        Activity context;
        public UserAdapter(Activity context, List<UserClass> userList) : base()
        {
            this.context = context;
            this.userList = userList;
        }
        public override long GetItemId(int position)
        {
            return position;
        }
        public override UserClass this[int position]
        {
            get { return userList.ToArray()[position]; }
        }
        public override int Count
        {
            get { return userList.ToArray().Length; }
        }
        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View view = convertView; // re-use an existing view, if one is available
            if (view == null) // otherwise create a new one
                view = context.LayoutInflater.Inflate(Android.Resource.Layout.SimpleListItem1, null);
            view.FindViewById<TextView>(Android.Resource.Id.Text1).Text = userList.ToArray()[position].first_name + " " + userList.ToArray()[position].last_name;
            return view;
        }
    }
}