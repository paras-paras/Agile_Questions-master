using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Agile_Questions.Data;
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
    public class OperationActivity : Activity
    {
        Button btnAddNewSubject, btnViewSubject, btnEditSubject, btnDeleteSubject;
        Button btnAddNewQuestion, btnViewQuestion, btnEditQuestion, btnDeleteQuestion;


        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "operation" layout resource
            SetContentView(Resource.Layout.operation_layout);
            btnAddNewSubject = FindViewById<Button>(Resource.Id.btnAddNewSubject);
            btnViewSubject = FindViewById<Button>(Resource.Id.btnViewSubject);
            btnEditSubject = FindViewById<Button>(Resource.Id.btnEditSubject);
            btnDeleteSubject = FindViewById<Button>(Resource.Id.btnDeleteSubject);

            btnAddNewQuestion = FindViewById<Button>(Resource.Id.btnAddNewQuestion);
            btnViewQuestion = FindViewById<Button>(Resource.Id.btnViewQuestion);
            btnEditQuestion = FindViewById<Button>(Resource.Id.btnEditQuestion);
            btnDeleteQuestion = FindViewById<Button>(Resource.Id.btnDeleteQuestion);

            btnAddNewSubject.Click += BtnAddNewSubject_Click;
            btnViewSubject.Click += BtnViewSubject_Click;
            btnEditSubject.Click += BtnEditSubject_Click;
            btnDeleteSubject.Click += BtnDeleteSubject_Click;

            btnAddNewQuestion.Click += BtnAddNewQuestion_Click;
            btnViewQuestion.Click += BtnViewQuestion_Click;
            btnEditQuestion.Click += BtnEditQuestion_Click;
            btnDeleteQuestion.Click += BtnDeleteQuestion_Click;
        }

        private void BtnDeleteQuestion_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(DeleteQuestionActivity));
            Finish();
        }

        private void BtnEditQuestion_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(EditQuestionActivity));
            Finish();
        }

        private void BtnViewQuestion_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(ViewQuestionActivity));
            Finish();
        }

        private void BtnAddNewQuestion_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(AddQuestionActivity));
            Finish();
        }

        private void BtnDeleteSubject_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(DeleteSubjectActivity));
            Finish();
        }

        private void BtnEditSubject_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(EditSubjectActivity));
            Finish();
        }

        private void BtnViewSubject_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(ViewSubjectActivity));
            Finish();
        }

        private void BtnAddNewSubject_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(AddSubjectActivity));
            Finish();
        }
    }
}