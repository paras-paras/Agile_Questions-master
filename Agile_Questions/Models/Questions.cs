using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SQLite;

namespace Agile_Questions.Models
{
    public class Questions
    {
        [PrimaryKey,AutoIncrement]
        public int QuestionID { get; set; }

        public int SubjectID { get; set; }

        public string QuestionText { get; set; }

        public string OptionA { get; set; }

        public string OptionB { get; set; }

        public string OptionC { get; set; }

        public string OptionD { get; set; }

        public string Answer { get; set; }
    }
}