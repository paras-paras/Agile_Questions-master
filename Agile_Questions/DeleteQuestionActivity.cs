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
    public class DeleteQuestionActivity : Activity
    {
        Button btnDelete, btnBack;
        EditText etQuestionID;
        DataManager manager;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "Delete Subject" layout resource
            SetContentView(Resource.Layout.delete_question_layout);
            manager = new DataManager();
            btnDelete = FindViewById<Button>(Resource.Id.btnDelete);
            btnBack = FindViewById<Button>(Resource.Id.btnBack);
            etQuestionID = FindViewById<EditText>(Resource.Id.etQuestionID);
            btnDelete.Click += BtnDelete_Click; ;
            btnBack.Click += BtnBack_Click;
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            string id = etQuestionID.Text.Trim();
            string message = "";
            try
            {
                int questionid = int.Parse(id);
                Questions question = manager.GetQuestion(questionid);
                if(question!=null)
                {
                    Android.Support.V7.App.AlertDialog.Builder winBuild = new Android.Support.V7.App.AlertDialog.Builder(this);
                    winBuild.SetTitle("Confirmation!!!");
                    winBuild.SetMessage("Are You Sure to Remove This Record with Text: " + question.QuestionText);
                    winBuild.SetPositiveButton("Delete Record", (c, v) =>
                    {
                        if (manager.DeleteQuestion(question))
                        {
                            message = "Question is Removed From Database";
                        }
                        else
                        {
                            message = "There is Problem in Delete the Question";
                        }
                        Toast.MakeText(this, message, ToastLength.Long).Show();
                    });
                    winBuild.SetNegativeButton("Close", (c, v) =>
                    {
                        winBuild.Dispose();
                    });
                    winBuild.Show();
                }
                else
                {
                    message = "There is no such Question ID with any Question";
                }
            }
            catch(Exception ex)
            {
                message = "Invalid Form of Question ID Given";
            }
            if (message.Length != 0)
            {
                Toast.MakeText(this, message, ToastLength.Long).Show();
            }
            
        }
        private void BtnBack_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(OperationActivity));
            Finish();
        }
    }
}