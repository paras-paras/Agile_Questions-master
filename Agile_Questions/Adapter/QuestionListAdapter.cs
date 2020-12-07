using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Agile_Questions.Models;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace Agile_Questions.Adapter
{
    public class QuestionListAdapter : BaseAdapter<Questions>
    {
        private readonly Activity context;
        private readonly List<Questions> datas;

        public QuestionListAdapter(Activity context, List<Questions> datas)
        {
            this.datas = datas;
            this.context = context;
        }

        public override int Count
        {
            get { return datas.Count; }

        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override Questions this[int position]
        {
            get { return datas[position]; }
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var row = convertView;

            if (row == null)
            {
                row = LayoutInflater.From(context).Inflate(Resource.Layout.question_row_layout, null, false);
            }
            Questions question = datas[position];
            TextView textQuestionText = row.FindViewById<TextView>(Resource.Id.textQuestionText);
            TextView textOptionA = row.FindViewById<TextView>(Resource.Id.textOptionA);
            TextView textOptionB = row.FindViewById<TextView>(Resource.Id.textOptionB);
            TextView textOptionC = row.FindViewById<TextView>(Resource.Id.textOptionC);
            TextView textOptionD = row.FindViewById<TextView>(Resource.Id.textOptionD);
            TextView textAnswer = row.FindViewById<TextView>(Resource.Id.textAnswer);

            textQuestionText.Text = "ID(" + question.QuestionID + ") " + question.QuestionText;
            textOptionA.Text = "A) " + question.OptionA;
            textOptionB.Text = "B) " + question.OptionB;
            textOptionC.Text = "C) " + question.OptionC;
            textOptionD.Text = "D) " + question.OptionD;
            textAnswer.Text = "Answer) " + question.Answer;

            return row;
        }
    }
}