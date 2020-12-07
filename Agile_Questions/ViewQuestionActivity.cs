using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Agile_Questions.Adapter;
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
    public class ViewQuestionActivity : Activity
    {
        Button btnBack;
        ListView listQuestion;
        DataManager manager;
        QuestionListAdapter adapter;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "View Question" layout resource
            SetContentView(Resource.Layout.view_question_layout);
            manager = new DataManager();
            btnBack = FindViewById<Button>(Resource.Id.btnBack);
            listQuestion = FindViewById<ListView>(Resource.Id.listQuestion);

            btnBack.Click += BtnBack_Click;

            adapter = new QuestionListAdapter(this, manager.GetAllQuestion());
            listQuestion.Adapter = adapter;
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(OperationActivity));
            Finish();
        }
    }
}