using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using SupportToolbar = Android.Support.V7.Widget.Toolbar;
using Android.Support.V7.App;
using Android.Support.V4.Widget;
using System.Collections.Generic;
using Android.Views.InputMethods;
using Java.Lang;


namespace DrawerLayout_V7_Tutorial
{
    [Activity(Label = "Tangent Solution", MainLauncher = true, Icon = "@drawable/icon")]
    class MainActivity1: Activity
    {
        RelativeLayout mRelativeLayout;

        EditText username;
        EditText password;
        Button mButton;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
            SetContentView(Resource.Layout.Main);


            username = (EditText)FindViewById(Resource.Id.txtUserName);
            password = (EditText)FindViewById(Resource.Id.txtPassword);
            mRelativeLayout = FindViewById<RelativeLayout>(Resource.Id.mainView);

            mButton = FindViewById<Button>(Resource.Id.btnLogin);


            mButton.Click += mButton_Click;
            mRelativeLayout.Click += mRelativeLayout_Click;


        }

        private bool ValidateLogin()
        {
            bool valid = true;

            string user = username.Text;
            string passwd = password.Text;

            if (string.IsNullOrEmpty(user))
            {
                username.Error = "Enter a valid user";
                valid = false;
            }
            else
            {
                username.Error = null;
            }

            if (string.IsNullOrEmpty(passwd))
            {
                password.Error = "Enter your password";
                valid = false;
            }
            else
            {
                password.Error = null;
            }

            return valid;
        }

        void mButton_Click(object sender, EventArgs e)
        {
            if (!ValidateLogin())
            {
                OnLoginFailed();
                return;
            }
            Intent intent = new Intent(this, typeof(MainActivity));
            this.StartActivity(intent);
            this.Finish();
        }

        private void OnLoginFailed()
        {
            mButton.Enabled = true;
        }
        void mRelativeLayout_Click(object sender, EventArgs e)
        {
            InputMethodManager inputManager = (InputMethodManager)this.GetSystemService(Activity.InputMethodService);
            inputManager.HideSoftInputFromWindow(this.CurrentFocus.WindowToken, HideSoftInputFlags.None);
        }
    }
}