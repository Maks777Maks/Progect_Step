using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using UI.ServiceReference1;


namespace UI
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    /// 
    
    public partial class MainWindow : Window
    {
        ObservableCollection<Student> students = new ObservableCollection<Student>();
        ObservableCollection<Subject> subjects = new ObservableCollection<Subject>();
        ObservableCollection<Mark> marks = new ObservableCollection<Mark>();
        ServiceReference1.StudentClient studclient = new StudentClient();
        ServiceReference1.MarkClient marklient = new MarkClient();
        ServiceReference1.SubjectClient subclient = new SubjectClient();

        public MainWindow()
        {
            InitializeComponent();
            getSubjects();
            getStudent();
            Listbox.ItemsSource = marks;
            Combstud.ItemsSource = students;
            Combsubject.ItemsSource = subjects;
        }

        public async void getSubjects()
        {           
                     
            var a = await subclient.GetSubjectAsync();            
            foreach(var i in a)
            {
                subjects.Add(i);
            }
            SubjectCombobox.ItemsSource = subjects;
        }

        //public async void getMarks()
        //{
        //    ServiceReference1.MarkClient marklient = new MarkClient();
        //    var a = await marklient.GetMarkAsync();
        //    foreach (var i in a)
        //    {
        //        marks.Add(i);
        //    }
        //}

        public void SelectMarks(Student st, Subject sub)
        {
           
            marks = new ObservableCollection<Mark>();
            
            foreach(var i in marklient.GetMarkByStudent(st,sub))
            {
                marks.Add(i);
            }
            
        }

        public async void getStudent()
        {           
            var a = await studclient.GetStudentAsync();
            foreach (var i in a)
            {
                students.Add(i);
            }
            StudentCombobox.ItemsSource = students;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(SubjectCombobox.SelectedIndex==-1|| StudentCombobox.SelectedIndex == -1) { return; }

            SelectMarks(StudentCombobox.SelectedItem as Student, SubjectCombobox.SelectedItem as Subject);
            Listbox.ItemsSource = marks;           
        }

        private void Add_stud(object sender, RoutedEventArgs e)
        {
            if(name.Text=="" || surname.Text == "") { return; }

            Student st = new Student();
            st.Name = name.Text;
            st.Surname = surname.Text;
            studclient.AddStudent(st);
            name.Text = "";
            surname.Text = "";
        }

        private void Add_Sub(object sender, RoutedEventArgs e)
        {
            if (subject.Text == "") { return; }

            Subject sub = new Subject();
            sub.Name = subject.Text;
            sub.time = (Convert.ToDateTime(subjectTime.Text));
            subclient.AddSubject(sub);
            subject.Text = "";
        }
    }
}
