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

namespace DrawerLayout_V7_Tutorial
{
    [Activity(Label = "UpdateDelete")]
    public class UpdateDelete : Activity
    {
        private UserClass userDetails;
        public UpdateDelete()
        {

        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.DeleteUpdateView);


        }
    }
}