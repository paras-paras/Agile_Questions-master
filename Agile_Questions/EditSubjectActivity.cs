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
    public class EditSubjectActivity : Activity
    {
        Button btnFetch, btnBack,btnUpdate;
        EditText etSubjectID,etSubjectName;
        DataManager manager;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "Edit Subject" layout resource
            SetContentView(Resource.Layout.edit_subject_layout);
            manager = new DataManager();
            btnFetch = FindViewById<Button>(Resource.Id.btnFetch);
            btnBack = FindViewById<Button>(Resource.Id.btnBack);
            btnUpdate = FindViewById<Button>(Resource.Id.btnUpdate);
            etSubjectID = FindViewById<EditText>(Resource.Id.etSubjectID);
            etSubjectName = FindViewById<EditText>(Resource.Id.etSubjectName);
            btnFetch.Click += BtnFetch_Click;
            btnBack.Click += BtnBack_Click;
            btnUpdate.Click += BtnUpdate_Click;
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            string subjectname = etSubjectName.Text.Trim();
            string id = etSubjectID.Text.Trim();
            string message = "";
            if (subjectname.Length == 0 || id.Length == 0)
            {
                message = "Please Fill All Boxes";
            }
            else
            {
                try
                {
                    Subject subject = new Subject();
                    subject.SubjectID = int.Parse(id);
                    subject.SubjectName = subjectname;
                    if (manager.UpdateSubject(subject))
                    {
                        message = " Subject Details is Saved in System";
                    }
                    else
                    {
                        message = manager.Message;
                    }
                }
                catch(Exception ex)
                {
                    message = "Invalid Form of Subject ID Given";
                }
            }
            Toast.MakeText(this, message, ToastLength.Long).Show();
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(OperationActivity));
            Finish();
        }

        private void BtnFetch_Click(object sender, EventArgs e)
        {
            string id = etSubjectID.Text.Trim();
            string message = "";
            try
            {
                int subjectid = int.Parse(id);
                Subject subject = manager.GetSubject(subjectid);
                if (subject != null)
                {
                    message = "Subject Record Fetched Successfully";
                    etSubjectName.Text = subject.SubjectName;
                }
                else
                {
                    message = "There is no such Subject Details For Given Subject ID";
                }
            }
            catch (Exception ex)
            {
                message = "Invalid Form of Subject ID Given";
            }
            if (message.Length != 0)
            {
                Toast.MakeText(this, message, ToastLength.Long).Show();
            }
        }
    }
}