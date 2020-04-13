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
    public partial class Remove : Form
    {
        private string Zachetka;
        private string Subject;
        private string Mark;
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
        public string zachetka
        {
            get { return Zachetka; }
            set { Zachetka = value; }
        }
        public Remove()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            zachetka = textBoxZach.Text;
            subject = textBoxSubject.Text;
            mark = textBoxMark.Text;
        }
    }
}
