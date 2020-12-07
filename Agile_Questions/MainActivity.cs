using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using Agile_Questions.Data;
using System;
using Android.Content;

namespace Agile_Questions
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme")]
    public class MainActivity : Activity
    {
        Button btnLogin, btnRegister;
        EditText etUser, etPassword;
        DataManager manager;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            manager = new DataManager();
            etUser = FindViewById<EditText>(Resource.Id.etUserName);
            etPassword = FindViewById<EditText>(Resource.Id.etPassword);

            btnLogin = FindViewById<Button>(Resource.Id.btnLogin);
            btnRegister = FindViewById<Button>(Resource.Id.btnRegister);
            btnLogin.Click += Login_Click;
            btnRegister.Click += Register_Click;
        }

        private void Login_Click(object sender, EventArgs e)
        {
            string username = etUser.Text.Trim();
            string pass = etPassword.Text;
            string message = "";
            if (username.Length == 0 || pass.Length == 0)
            {
                message = "Please Fill All Boxes";
            }
            else
            {
                if (manager.CheckUser(username, pass))
                {
                    message = "Welcome " + username;
                    Intent intent = new Intent(this, typeof(OperationActivity));
                    intent.PutExtra("UserName", username);
                    StartActivity(intent);
                    Finish();
                }
                else
                {
                    message = "Invalid User Name and Password";
                }
            }
            Toast.MakeText(this, message, ToastLength.Long).Show();
        }

        private void Register_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(RegisterActivity));
            Finish();
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}