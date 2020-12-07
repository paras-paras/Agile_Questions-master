using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Agile_Questions.Models;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SQLite;

namespace Agile_Questions.Data
{
    public class DataManager
    {
        private SQLiteConnection conn;

        public string Message { get; set; }

        public DataManager()
        {
            string path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            conn = new SQLiteConnection(Path.Combine(path, "questionbanks.db"));
            if (!CheckUserTableExists())
            {
                conn.CreateTable<Users>();
                conn.CreateTable<Subject>();
                conn.CreateTable<Questions>();
            }

        }

        public bool AddNewUser(Users user)
        {
            try
            {
                conn.Insert(user);
                return true;
            }
            catch (Exception ex)
            {
                Message = ex.Message;
                return false;
            }
        }

        public bool AddNewSubject(Subject subject)
        {
            try
            {
                conn.Insert(subject);
                return true;
            }
            catch (Exception ex)
            {
                Message = ex.Message;
                return false;
            }
        }

        public bool UpdateSubject(Subject subject)
        {
            try
            {
                conn.Update(subject);
                return true;
            }
            catch (Exception ex)
            {
                Message = ex.Message;
                return false;
            }
        }

        public bool UpdateQuestion(Questions question)
        {
            try
            {
                conn.Update(question);
                return true;
            }
            catch (Exception ex)
            {
                Message = ex.Message;
                return false;
            }
        }

        public bool AddNewQuestion(Questions question)
        {
            try
            {
                conn.Insert(question);
                return true;
            }
            catch (Exception ex)
            {
                Message = ex.Message;
                return false;
            }
        }

        //Check existing User
        public bool CheckUser(string username, string password)
        {
            List<Users> users = conn.Query<Users>("Select * from Users");
            for (int i = 0; i < users.Count; i++)
            {
                if (users[i].UserName.Equals(username) && users[i].Password.Equals(password))
                {
                    return true;
                }

            }
            return false;
        }

        public List<Subject> GetAllSubject()
        {
            List<Subject> subjects = conn.Query<Subject>("Select * from Subject");
            return subjects;
        }

        public List<Questions> GetAllQuestion()
        {
            List<Questions> questions = conn.Query<Questions>("Select * from Questions");
            return questions;
        }

        public Questions GetQuestion(int questionid)
        {
            List<Questions> questions = GetAllQuestion();
            Questions question = null;
            foreach( Questions quest in questions)
            {
                if(quest.QuestionID == questionid)
                {
                    question = quest;
                    break;
                }
            }
            return question;
        }

        public Subject GetSubject(int subjectid)
        {
            List<Subject> subjects = GetAllSubject();
            Subject subject = null;
            foreach (Subject sub in subjects)
            {
                if (sub.SubjectID == subjectid)
                {
                    subject = sub;
                    break;
                }
            }
            return subject;
        }

        public bool DeleteQuestion(Questions question)
        {
            try
            {
                conn.Delete(question);
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        public bool CheckSubjectQuestion(int subjectid)
        {
            List<Questions> questions = GetAllQuestion();
            foreach(Questions question in questions)
            {
                if( question.SubjectID == subjectid)
                {
                    return true;
                }
            }
            return false;
        }
        public bool DeleteSubject(Subject subject)
        {
            try
            {
                conn.Delete(subject);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        private bool CheckUserTableExists()
        {
            try
            {
                conn.Get<Users>(1);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}