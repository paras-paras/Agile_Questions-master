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
    public class ViewSubjectActivity : Activity
    {
        Button btnBack;
        ListView listSubject;
        DataManager manager;
        SubjectListAdapter adapter;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "View Subject" layout resource
            SetContentView(Resource.Layout.view_subject_layout);
            manager = new DataManager();
            btnBack = FindViewById<Button>(Resource.Id.btnBack);            
            listSubject = FindViewById<ListView>(Resource.Id.listSubject);

            btnBack.Click += BtnBack_Click;

            adapter = new SubjectListAdapter(this, manager.GetAllSubject());
            listSubject.Adapter = adapter;

        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(OperationActivity));
            Finish();
        }
    }
}