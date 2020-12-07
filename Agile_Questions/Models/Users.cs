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
    public  class Users
    {
        [PrimaryKey, AutoIncrement]
        public int UserID { get; set; }

        [Unique]
        public string UserName { get; set; }

        public string  Password { get; set; }
    }
}