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
using SharedPreferences;
using Newtonsoft.Json;

namespace DrawerLayout_V7_Tutorial
{
    [Activity(Label = "UpdateDelete")]
    public class UpdateDelete : Activity
    {
        private UserClass userDetails;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.DeleteUpdateView);

            try
            {
                userDetails = JsonConvert.DeserializeObject <UserClass>( Intent.GetStringExtra("user"));

                EditText name = (EditText)FindViewById(Resource.Id.Name);
                name.Text = userDetails.first_name;

                EditText surname = (EditText)FindViewById(Resource.Id.Surname);
                surname.Text = userDetails.last_name;

                EditText email = (EditText)FindViewById(Resource.Id.email);
                email.Text = userDetails.email;

                EditText username = (EditText)FindViewById(Resource.Id.username);
                surname.Text = userDetails.username;

            }
            catch (Exception ex)
            {

            }


            Button deleteButton = (Button)FindViewById(Resource.Id.deleteBtn);
            deleteButton.Click += deleteClicked;

            Button udpateButton  = (Button)FindViewById(Resource.Id.updateBtn);
            udpateButton.Click += updateClicked;
        }

        private void updateClicked(object sender, EventArgs e)
        {
            userDetails.first_name = ((EditText)FindViewById(Resource.Id.Name)).Text;
            userDetails.last_name = ((EditText)FindViewById(Resource.Id.Surname)).Text;
            userDetails.email = ((EditText)FindViewById(Resource.Id.email)).Text;
            userDetails.username = ((EditText)FindViewById(Resource.Id.username)).Text;

            
        }

        private void deleteClicked(object sender, EventArgs e)
        {
            ProgressDialog progress = ProgressDialog.Show(this, "", "Loading...");
            progress.SetProgressStyle(ProgressDialogStyle.Spinner);

            SecurityData security = SecurityData.init();
            ServiceHelper service = new ServiceHelper();

            var results = service.DELETE("http://userservice.staging.tangentmicroservices.com:80/api/v1/users/\"" + userDetails.id + "/\"", security.token);
            if (string.IsNullOrEmpty(results))
            {
                Toast.MakeText(this, userDetails.first_name + " Delete passed!", ToastLength.Short).Show();
                Finish();
            } else
            {
                Toast.MakeText(this, userDetails.first_name + " Delete failed!", ToastLength.Short).Show();
            }
            progress.Dismiss();
        }
    }
}