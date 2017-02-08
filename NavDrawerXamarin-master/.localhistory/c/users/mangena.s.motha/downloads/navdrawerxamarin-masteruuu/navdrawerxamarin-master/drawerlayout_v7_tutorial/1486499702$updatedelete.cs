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
        public UpdateDelete(UserClass userDetails)
        {
            this.userDetails = userDetails;
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.DeleteUpdateView);

            EditText name =(EditText) FindViewById(Resource.Id.Name);
            name.SetText(userDetails.first_name);

            EditText surname = (EditText)FindViewById(Resource.Id.Surname);
            surname.SetText(userDetails.last_name);

            EditText email = (EditText)FindViewById(Resource.Id.email);
            email.SetText(userDetails.email);

            EditText username = (EditText)FindViewById(Resource.Id.username);
            surname.SetText(userDetails.username);


        }
    }
}