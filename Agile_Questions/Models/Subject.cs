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
    public class Subject
    {
        [PrimaryKey,AutoIncrement]
        public int SubjectID { get; set; }

        [Unique]
        public string SubjectName { get; set; }
    }
}