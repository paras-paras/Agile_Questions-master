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
    public class AddSubjectActivity : Activity
    {
        Button btnSave, btnBack;
        EditText etSubjectName;
        DataManager manager;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "Add Subject" layout resource
            SetContentView(Resource.Layout.add_subject_layout);
            manager = new DataManager();
            btnSave = FindViewById<Button>(Resource.Id.btnSave);
            btnBack = FindViewById<Button>(Resource.Id.btnBack);
            etSubjectName = FindViewById<EditText>(Resource.Id.etSubjectName);
            btnSave.Click += BtnSave_Click;
            btnBack.Click += BtnBack_Click;
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(OperationActivity));
            Finish();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            string subjectname = etSubjectName.Text.Trim();
            string message = "";
            if (subjectname.Length == 0 )
            {
                message = "Please Fill All Boxes";
            }
            else 
            {
                Subject subject = new Subject();
                subject.SubjectName = subjectname;
                if (manager.AddNewSubject(subject))
                {
                    message = "New Subject is Saved in System";
                }
                else
                {
                    message = manager.Message;
                }
            }
            Toast.MakeText(this, message, ToastLength.Long).Show();
        }
    }
}