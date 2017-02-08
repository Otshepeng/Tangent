using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using SupportToolbar = Android.Support.V7.Widget.Toolbar;
using SupportFragment = Android.Support.V4.App.Fragment;
using Android.Support.V7.App;
using Android.Support.V4.Widget;
using System.Collections.Generic;
using DrawerLayout_V7_Tutorial.Model;
using DrawerLayout_V7_Tutorial.Adapter;
using SharedPreferences;
using Newtonsoft.Json;

namespace DrawerLayout_V7_Tutorial
{


	class HomeFragment : Android.Support.V4.App.Fragment
	{

        private UserAdapter ListAdapter;
        private Context context;
        private ProgressDialog progress;
        public HomeFragment()
		{

		}
		public static Android.Support.V4.App.Fragment newInstance(Context context)
		{
			HomeFragment busrouteFragment = new HomeFragment();
            busrouteFragment.context = context;
			return busrouteFragment;
		}
		public override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

		}
		public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
		{
			ViewGroup root = (ViewGroup)inflater.Inflate(Resource.Layout.homefragment, null);
            progress = ProgressDialog.Show(this, "", "Loading...");
            progress.SetProgressStyle(ProgressDialogStyle.Spinner);

            SecurityData security = SecurityData.init();
            ServiceHelper service = new ServiceHelper();

            var results = service.GET("http://userservice.staging.tangentmicroservices.com:80/api/v1/users/", security.token);
            List<UserClass> userList = JsonConvert.DeserializeObject<List<UserClass>>(results);
            Console.Write(userList.ToString());

            ListAdapter = new UserAdapter(this.Activity, userList);



            ListView listView = (ListView)root.FindViewById(Resource.Id.userListView);
            listView.SetAdapter(ListAdapter);
            listView.SetOnClickListener(listView_ItemClick);
            return root;
		}

        void listView_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            //Get our item from the list adapter
            var item = this.listAdapter.GetItemAtPosition(e.Position);

            //Make a toast with the item name just to show it was clicked
            Toast.MakeText(this, item.Name + " Clicked!", ToastLength.Short).Show();
        }
    }

}


