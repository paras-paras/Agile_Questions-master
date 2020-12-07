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
    public class SubjectListAdapter : BaseAdapter<Subject>
    {
        private readonly Activity context;
        private readonly List<Subject> datas;

        public SubjectListAdapter(Activity context, List<Subject> datas)
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

        public override Subject this[int position]
        {
            get { return datas[position]; }
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var row = convertView;

            if (row == null)
            {
                row = LayoutInflater.From(context).Inflate(Resource.Layout.subject_row_layout, null, false);
            }

            TextView textSubject = row.FindViewById<TextView>(Resource.Id.textSubject);

            textSubject.Text = datas[position].SubjectName + " (" + datas[position].SubjectID + ")";

            return row;
        }
    }
}