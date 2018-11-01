using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace UI
{
    /// <summary>
    /// Логика взаимодействия для Change.xaml
    /// </summary>
    public partial class Change : Window
    {
        Student student = new Student();
      
       
        public Change(Student st)
        {
            InitializeComponent();
            Repository<Course> db1 = new Repository<Course>();
            Repository<Student> db = new Repository<Student>();
            student = db.Read(x => x.Surname == st.Surname);
            Title = student.Surname;
            Combo.ItemsSource = db1.ReadAll();
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            foreach(var i in student.Course)
            {
                if (i.Name == Combo.SelectedItem.ToString())
                {
                    MessageBox.Show("You already have this course");
                    return;
                }
            }
            Repository<Course> db1 = new Repository<Course>();
            Repository<Student> db = new Repository<Student>();
            student = db.ReadAll()[0];
            student.Course.Add(new Course() { Name = "asdasasd" });
            db.Update(student);
            MessageBox.Show("Added");
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Repository<Course> db1 = new Repository<Course>();
            Repository<Student> db = new Repository<Student>();
            foreach (var i in student.Course)
            {
                if (i.Name == Combo.SelectedItem.ToString())
                {
                    student.Course.Remove(i);                  
                    db.Update(student);
                }                                    
            }
        }
    }
}
