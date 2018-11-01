using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WCF.Utils;

namespace WCF
{
    
    public class Service1 : IStudent, ISubject, IMark
    {
        public void AddMark(int mark, Student student, Subject sub)
        {
            try
            {
                Mark _mark = new Mark();
                using (Model1 db = new Model1())
                {
                    db.Students.Attach(student);
                    db.Subjects.Attach(sub);
                    _mark.student = student;
                    _mark.subject = sub;
                    db.Marks.Add(_mark);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Logger.Log(ex.Message);
            }
        }

        public List<Mark> GetMark()
        {
            List<Mark> marks = new List<Mark>();
            using (Model1 db = new Model1())
            {
                marks = db.Marks.Include("student").Include("subject").ToList();
            }
            return marks;
        }

        public void AddStudent(Student student)
        {
            try
            {
                using (Model1 db = new Model1())
                {
                    db.Students.Add(student);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Logger.Log(ex.Message);
            }
           
        }

        public List<Student> GetStudent()
        {
            List<Student> student = new List<Student>();
            using (Model1 db = new Model1())
            {
                student = db.Students.ToList();

            }
            return student;
        }

        public void AddSubject(Subject subject)
        {
            try
            {
                using (Model1 db = new Model1())
                {
                    db.Subjects.Add(subject);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Logger.Log(ex.Message);
            }
        }

        public List<Subject> GetSubject()
        {
            List<Subject> subject = null;
            try
            {
                using (Model1 db = new Model1())
                {
                    subject = db.Subjects.ToList();
                }
                foreach (var i in subject)
                {
                    Logger.Log($"Got Subject: {i.Name}");
                    
                    foreach (var s in i.marks)
                    {
                        Logger.Log(s.mark.ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Log(ex.Message);
            }
            return subject;
        }

        public List<Mark> GetMarkByStudent(Student st, Subject sub)
        {
            using (Model1 db = new Model1())
            {
                var marks = db.Marks.Include("student").Include("subject").ToList();
                var result = marks.Where(x => (x.student.Name == st.Name && x.subject.Name == sub.Name)).ToList();
                return result;
            }
            
        }
    }
}
