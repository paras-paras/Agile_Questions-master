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
    public class DeleteSubjectActivity : Activity
    {
        Button btnDelete, btnBack;
        EditText etSubjectID;
        DataManager manager;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "Delete Subject" layout resource
            SetContentView(Resource.Layout.delete_subject_layout);
            manager = new DataManager();
            btnDelete = FindViewById<Button>(Resource.Id.btnDelete);
            btnBack = FindViewById<Button>(Resource.Id.btnBack);
            etSubjectID = FindViewById<EditText>(Resource.Id.etSubjectID);
            btnDelete.Click += BtnDelete_Click; ;
            btnBack.Click += BtnBack_Click;
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(OperationActivity));
            Finish();
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            string id = etSubjectID.Text.Trim();
            string message = "";
            try
            {
                int subjectid = int.Parse(id);
                Subject subject = manager.GetSubject(subjectid);
                if (subject != null)
                {
                    if (manager.CheckSubjectQuestion(subject.SubjectID))
                    {
                        Android.Support.V7.App.AlertDialog.Builder winBuild = new Android.Support.V7.App.AlertDialog.Builder(this);
                        winBuild.SetTitle("Message!!!");
                        winBuild.SetMessage("There are some Question associated with Given Subject ID. So Deletion not Possible");
                        winBuild.SetNegativeButton("Close", (c, v) =>
                        {
                            winBuild.Dispose();
                        });
                        winBuild.Show();
                    }
                    else
                    {
                        Android.Support.V7.App.AlertDialog.Builder winBuild = new Android.Support.V7.App.AlertDialog.Builder(this);
                        winBuild.SetTitle("Confirmation!!!");
                        winBuild.SetMessage("Are You Sure to Remove This Record with Text: " + subject.SubjectName);
                        winBuild.SetPositiveButton("Delete Record", (c, v) =>
                        {
                            if (manager.DeleteSubject(subject))
                            {
                                message = "Subject is Removed From Database";
                            }
                            else
                            {
                                message = "There is Problem in Delete the Subject";
                            }
                            Toast.MakeText(this, message, ToastLength.Long).Show();
                        });
                        winBuild.SetNegativeButton("Exit", (c, v) =>
                        {
                            winBuild.Dispose();
                        });
                        winBuild.Show();
                    }
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