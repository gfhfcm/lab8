using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace XmlForm
{
    public partial class Add : Form
    {
        private string Name;
        private string Group;
        private string Zachetka;
        private string Subject;
        private string Mark;
        private string Course;
        public string name
        {
            get { return Name; }
            set { Name = value; }
        }
        public string subject
        {
            get { return Subject; }
            set { Subject = value; }
        }
        public string mark
        {
            get { return Mark; }
            set { Mark = value; }
        }
        public string course
        {
            get { return Course; }
            set { Course = value; }
        }
        public string zachetka
        {
            get { return Zachetka; }
            set { Zachetka = value; }
        }
        public string group
        {
            get { return Group; }
            set { Group = value; }
        }
        public Add()
        {
            InitializeComponent();
        }

        private void DoneButton_Click(object sender, EventArgs e)
        {
            name = textBoxName.Text;
            group = textBoxGroup.Text;
            zachetka = textBoxZach.Text;
            subject = textBoxSubject.Text;
            mark = textBoxMark.Text;
            course = textBoxCourse.Text;
            int temp = Int32.Parse(mark); 
        }
    }
}
