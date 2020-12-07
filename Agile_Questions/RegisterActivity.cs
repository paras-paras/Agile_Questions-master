using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Agile_Questions.Data;
using Agile_Questions.Models;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;

namespace Agile_Questions
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme")]
    public class RegisterActivity : Activity
    {
        Button btnCreate;
        EditText etUser, etPass, etConfirm;
        DataManager manager;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "register" layout resource
            SetContentView(Resource.Layout.register_layout);
            manager = new DataManager();
            etUser = FindViewById<EditText>(Resource.Id.etUserName);
            etPass = FindViewById<EditText>(Resource.Id.etPassword);
            etConfirm = FindViewById<EditText>(Resource.Id.etConfirm);
            btnCreate = FindViewById<Button>(Resource.Id.btnCreate);
            btnCreate.Click += Create_Click;
        }

        private void Create_Click(object sender, EventArgs e)
        {
            string username = etUser.Text.Trim();
            string pass = etPass.Text;
            string cpass = etConfirm.Text;
            string message = "";
            if (username.Length == 0 || pass.Length == 0 || cpass.Length == 0)
            {
                message = "Please Fill All Boxes";
            }
            else if (pass.Equals(cpass))
            {
                Users user = new Users();
                user.UserName = username;
                user.Password = pass;
                if (manager.AddNewUser(user))
                {
                    message = "New User is Created";
                    Intent intent = new Intent(this, typeof(OperationActivity));                    
                    StartActivity(intent);
                    Finish();
                }
                else
                {
                    message = "There is Some Error in Creating in User";
                    message = manager.Message;
                }
            }
            else
            {
                message = "Confirm Password must be match with Password";
            }
            Toast.MakeText(this, message, ToastLength.Long).Show();
        }
    }
}