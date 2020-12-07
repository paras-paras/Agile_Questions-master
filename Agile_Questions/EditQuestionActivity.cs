using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Agile_Questions.Adapter;
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
    public class EditQuestionActivity : Activity
    {
        Button btnFetch, btnBack, btnSave;
        EditText etQuestionID, etQuestionText, etOptionA, etOptionB, etOptionC, etOptionD;
        DataManager manager;
        Spinner spinnerSubject, spinnerOption;
        string[] options;
        SubjectListAdapter adapter;
        List<Subject> subjects;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "Edit Question" layout resource
            SetContentView(Resource.Layout.edit_question_layout);
            manager = new DataManager();
            btnSave = FindViewById<Button>(Resource.Id.btnSave);
            btnBack = FindViewById<Button>(Resource.Id.btnBack);
            btnFetch = FindViewById<Button>(Resource.Id.btnFetch);
            etQuestionID = FindViewById<EditText>(Resource.Id.etQuestionID);
            etQuestionText = FindViewById<EditText>(Resource.Id.etQuestionText);
            etOptionA = FindViewById<EditText>(Resource.Id.etOptionA);
            etOptionB = FindViewById<EditText>(Resource.Id.etOptionB);
            etOptionC = FindViewById<EditText>(Resource.Id.etOptionC);
            etOptionD = FindViewById<EditText>(Resource.Id.etOptionD);
            spinnerOption = FindViewById<Spinner>(Resource.Id.spinnerOption);
            spinnerSubject = FindViewById<Spinner>(Resource.Id.spinnerSubject);

            btnSave.Click += BtnSave_Click;
            btnBack.Click += BtnBack_Click;
            btnFetch.Click += BtnFetch_Click;

            subjects = manager.GetAllSubject();
            adapter = new SubjectListAdapter(this, subjects);
            spinnerSubject.Adapter = adapter;

            options = Resources.GetStringArray(Resource.Array.options);
            ArrayAdapter<string> adapter1 = new ArrayAdapter<string>(this, Resource.Layout.option_row_layout, Resource.Id.text, options);
            spinnerOption.Adapter = adapter1;
        }

        private void BtnFetch_Click(object sender, EventArgs e)
        {
            string id = etQuestionID.Text.Trim();
            string message = "";
            try
            {
                int questionid = int.Parse(id);
                Questions question = manager.GetQuestion(questionid);
                if (question != null)
                {
                    etQuestionText.Text = question.QuestionText;
                    etOptionA.Text = question.OptionA;
                    etOptionB.Text = question.OptionB;
                    etOptionC.Text = question.OptionC;
                    etOptionD.Text = question.OptionD;
                    int index = 0;
                    for(int i =0; i < subjects.Count(); i++)
                    {
                        if(subjects[i].SubjectID == question.SubjectID)
                        {
                            index = i;
                            break;
                        }
                    }
                    spinnerSubject.SetSelection(index);
                    index = 0;
                    for (int i = 0; i < options.Count(); i++)
                    {
                        if (options[i].Equals(question.Answer))
                        {
                            index = i;
                            break;
                        }
                    }
                    spinnerOption.SetSelection(index);
                }
                else
                {
                    message = "There is no such Question ID with any Question";
                }
            }
            catch (Exception ex)
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

        private void BtnSave_Click(object sender, EventArgs e)
        {
            string questionid = etQuestionID.Text.Trim();
            string questiontext = etQuestionText.Text.Trim();
            string optiona = etOptionA.Text.Trim();
            string optionb = etOptionB.Text.Trim();
            string optionc = etOptionC.Text.Trim();
            string optiond = etOptionD.Text.Trim();
            string answer = options[spinnerOption.SelectedItemPosition];
            Subject subject = subjects[spinnerSubject.SelectedItemPosition];
            string message = "";
            if (questiontext.Length == 0 || optiona.Length == 0 || optionb.Length == 0
                || optionc.Length == 0 || optiond.Length == 0 || questionid.Length == 0)
            {
                message = "Please Fill All Boxes";
            }
            else
            {
                try
                {
                    Questions question = new Questions();
                    question.QuestionID = int.Parse(questionid);
                    question.QuestionText = questiontext;
                    question.Answer = answer;
                    question.OptionA = optiona;
                    question.OptionB = optionb;
                    question.OptionC = optionc;
                    question.OptionD = optiond;
                    question.SubjectID = subject.SubjectID;
                    if (manager.UpdateQuestion(question))
                    {
                        message = "Question is Updated in System";
                    }
                    else
                    {
                        message = manager.Message;
                    }
                }
                catch(Exception ex)
                {
                    message = "Invalid Form of Question ID Given";
                }
            }
            Toast.MakeText(this, message, ToastLength.Long).Show();
        }
    }
}