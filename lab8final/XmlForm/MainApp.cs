using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using System.IO;

namespace XmlForm
{
    public partial class MainApp : Form
    {
        public MainApp()
        {
            InitializeComponent();
        }

        private void showToolStripMenuItem_Click(object sender, EventArgs e)
        {
            label1.Text = Procedures.GetInfo();
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string name, zachetka, subject, mark, course, group;
                int temp;
                Add f2 = new Add();
                if (f2.ShowDialog() == DialogResult.OK)
                {
                    name = f2.name;
                    zachetka = f2.zachetka;
                    group = f2.group;
                    mark = f2.mark;
                    course = f2.course;
                    subject = f2.subject;
                    temp = Int32.Parse(mark);
                    if (name == "" ||zachetka == "" || group == "" || course == "" || subject == "" || temp > 10||temp<1)
                    {
                        MessageBox.Show("Wrong input! Null values are not allowed! Mark should be between 1 and 10");
                    }
                    else
                    {
                        Procedures.Add(name, group, course, zachetka, mark, subject);
                    }
                }
                label1.Text = Procedures.GetInfo();
            }
            catch(FormatException)
            {
                MessageBox.Show("Wrong input! Mark is digit!");
            }
        }

        private void removeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string mark, zachetka, subject;
            Remove f3 = new Remove();
            if (f3.ShowDialog() == DialogResult.OK)
            {
                zachetka = f3.zachetka;
                mark = f3.mark;
                subject = f3.subject;
                if (zachetka=="" ||mark =="" ||subject=="")
                {
                    MessageBox.Show("You have to fill all fields!");
                }
                else
                Procedures.Remove(zachetka, subject, mark);
            }
            label1.Text = Procedures.GetInfo();
        }

        private void Search_Click(object sender, EventArgs e)
        {
            string val;
            ToolStripMenuItem b = (ToolStripMenuItem)sender;
            subj s = new subj();
            if(s.ShowDialog()==DialogResult.OK)
            {
                val = s.val;
                if (val == "")
                {
                    MessageBox.Show("You didn't fill the field!");
                }
                else
                {
                    switch (b.Text)
                    {
                        case "subject":
                            label1.Text = Procedures.SearchSubject(val);
                            break;
                        case "mark":
                            label1.Text = Procedures.SearchMark(val);
                            break;
                        case "name":
                            label1.Text = Procedures.SearchName(val);
                            break;
                        case "zachetka":
                            label1.Text = Procedures.SearchZachetka(val);
                            break;
                        case "group":
                            label1.Text = Procedures.SearchGroup(val);
                            break;
                        case "course":
                            label1.Text = Procedures.SearchCourse(val);
                            break;
                        default:
                            break;
                    }
                }
            }
        }

        private void Average_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem b = (ToolStripMenuItem)sender;
            switch(b.Text)
            {
                case "Subject":
                    label1.Text = Procedures.AVGSubj();
                    break;
                case "Course":
                    label1.Text = Procedures.AVGCourse();
                    break;
                case "Group":
                    label1.Text = Procedures.AVGGroup();
                    break;
            }
        }
    }
   public class Procedures
    {
        public static void Remove(string zachetka, string subject, string mark)
        {
            XDocument xdoc = XDocument.Load("students.xml");
            XElement root = xdoc.Element("students");
            foreach (XElement temp in root.Elements("student").ToList())
                if (temp.Element("zachetka").Value == zachetka && temp.Element("subject").Value == subject && temp.Element("mark").Value == mark)
                {
                    temp.Remove();
                }
            xdoc.Save("students.xml");
        }
        public static void Add(string name, string group, string course, string zachetka, string mark, string subject)
        {
            XDocument xdoc = XDocument.Load("students.xml");
            XElement root = xdoc.Element("students");
            root.Add(new XElement("student",
                             new XAttribute("name", name),
                             new XElement("subject", subject),
                             new XElement("mark", mark),
                             new XElement("zachetka", zachetka),
                             new XElement("Course", course),
                             new XElement("group", group)));
            xdoc.Save("students.xml");
        }
        public static string GetInfo()
        {
            string text="";
            XDocument xdoc = XDocument.Load("students.xml");
            var items = from xe in xdoc.Element("students").Elements("student")
                        select new Student
                        {
                            Name = xe.Attribute("name").Value,
                            Mark = xe.Element("mark").Value,
                            Group = xe.Element("group").Value,
                            Zachetka = xe.Element("zachetka").Value,
                            Subject = xe.Element("subject").Value,
                            Course = xe.Element("Course").Value
                        };

            foreach (var item in items)
            {
                text = text + $"Student: {item.Name} on course: {item.Course} from group: {item.Group} got {item.Mark} for {item.Subject} in his zachetka: {item.Zachetka}\n";
            }
            return text;
        }

        public static string SearchName(string p_name)
        {
            string text = "";
            XDocument xdoc = XDocument.Load("students.xml");
            var items = from xe in xdoc.Element("students").Elements("student")
                        where xe.Attribute("name").Value== p_name
                        select new Student
                        {
                            Name = xe.Attribute("name").Value,
                            Mark = xe.Element("mark").Value,
                            Group = xe.Element("group").Value,
                            Zachetka = xe.Element("zachetka").Value,
                            Subject = xe.Element("subject").Value,
                            Course = xe.Element("Course").Value
                        };

            foreach (var item in items)
            {
                text = text + $"Student: {item.Name} on course: {item.Course} from group: {item.Group} got {item.Mark} for {item.Subject} in his zachetka: {item.Zachetka}\n";
            }
            return text;
        }

        public static string SearchZachetka(string p_zach)
        {
            string text = "";
            XDocument xdoc = XDocument.Load("students.xml");
            var items = from xe in xdoc.Element("students").Elements("student")
                        where xe.Element("zachetka").Value == p_zach
                        select new Student
                        {
                            Name = xe.Attribute("name").Value,
                            Mark = xe.Element("mark").Value,
                            Group = xe.Element("group").Value,
                            Zachetka = xe.Element("zachetka").Value,
                            Subject = xe.Element("subject").Value,
                            Course = xe.Element("Course").Value
                        };

            foreach (var item in items)
            {
                text = text + $"Student: {item.Name} on course: {item.Course} from group: {item.Group} got {item.Mark} for {item.Subject} in his zachetka: {item.Zachetka}\n";
            }
            return text;
        }
        public static string SearchGroup(string p_group)
        {
            string text = "";
            XDocument xdoc = XDocument.Load("students.xml");
            var items = from xe in xdoc.Element("students").Elements("student")
                        where xe.Element("group").Value == p_group
                        select new Student
                        {
                            Name = xe.Attribute("name").Value,
                            Mark = xe.Element("mark").Value,
                            Group = xe.Element("group").Value,
                            Zachetka = xe.Element("zachetka").Value,
                            Subject = xe.Element("subject").Value,
                            Course = xe.Element("Course").Value
                        };

            foreach (var item in items)
            {
                text = text + $"Student: {item.Name} on course: {item.Course} from group: {item.Group} got {item.Mark} for {item.Subject} in his zachetka: {item.Zachetka}\n";
            }
            return text;
        }
        public static string SearchMark(string p_mark)
        {
            string text = "";
            XDocument xdoc = XDocument.Load("students.xml");
            var items = from xe in xdoc.Element("students").Elements("student")
                        where xe.Element("mark").Value == p_mark
                        select new Student
                        {
                            Name = xe.Attribute("name").Value,
                            Mark = xe.Element("mark").Value,
                            Group = xe.Element("group").Value,
                            Zachetka = xe.Element("zachetka").Value,
                            Subject = xe.Element("subject").Value,
                            Course = xe.Element("Course").Value
                        };

            foreach (var item in items)
            {
                text = text + $"Student: {item.Name} on course: {item.Course} from group: {item.Group} got {item.Mark} for {item.Subject} in his zachetka: {item.Zachetka}\n";
            }
            return text;
        }
        public static string SearchCourse(string p_course)
        {
            string text = "";
            XDocument xdoc = XDocument.Load("students.xml");
            var items = from xe in xdoc.Element("students").Elements("student")
                        where xe.Element("Course").Value == p_course
                        select new Student
                        {
                            Name = xe.Attribute("name").Value,
                            Mark = xe.Element("mark").Value,
                            Group = xe.Element("group").Value,
                            Zachetka = xe.Element("zachetka").Value,
                            Subject = xe.Element("subject").Value,
                            Course = xe.Element("Course").Value
                        };

            foreach (var item in items)
            {
                text = text + $"Student: {item.Name} on course: {item.Course} from group: {item.Group} got {item.Mark} for {item.Subject} in his zachetka: {item.Zachetka}\n";
            }
            return text;
        }
        public static string SearchSubject(string p_subject)
        {
            string text = "";
            XDocument xdoc = XDocument.Load("students.xml");
            var items = from xe in xdoc.Element("students").Elements("student")
                        where xe.Element("subject").Value == p_subject
                        select new Student
                        {
                            Name = xe.Attribute("name").Value,
                            Mark = xe.Element("mark").Value,
                            Group = xe.Element("group").Value,
                            Zachetka = xe.Element("zachetka").Value,
                            Subject = xe.Element("subject").Value,
                            Course = xe.Element("Course").Value
                        };

            foreach (var item in items)
            {
                text = text + $"Student: {item.Name} on course: {item.Course} from group: {item.Group} got {item.Mark} for {item.Subject} in his zachetka: {item.Zachetka}\n";
            }
            return text;
        }
        public static string AVGSubj()
        {
            string text="";
            XDocument xdoc = XDocument.Load("students.xml");
            var items = from xe in xdoc.Element("students").Elements("student")
                        select new
                        {
                            Mark = Int32.Parse(xe.Element("mark").Value),
                            Subject = xe.Element("subject").Value,
                        };
            var res = from temp in items
                      group temp by temp.Subject into g
                      select new
                      {
                          name = g.Key,
                          avg = g.Average(x => x.Mark)
                      };
            foreach (var item in res)
            {
                text = text + $"{item.name} : {item.avg} \n";
            }
            return text;
        }
        public static string AVGGroup()
        {
            string text = "";
            XDocument xdoc = XDocument.Load("students.xml");
            var items = from xe in xdoc.Element("students").Elements("student")
                        select new
                        {
                            Mark = Int32.Parse(xe.Element("mark").Value),
                            Group = xe.Element("group").Value,
                        };
            var res = from temp in items
                      group temp by temp.Group into g
                      select new
                      {
                          name = g.Key,
                          avg = g.Average(x => x.Mark)
                      };
            foreach (var item in res)
            {
                text = text + $"{item.name} : {item.avg} \n";
            }
            return text;
        }
        public static string AVGCourse()
        {
            string text = "";
            XDocument xdoc = XDocument.Load("students.xml");
            var items = from xe in xdoc.Element("students").Elements("student")
                        select new
                        {
                            Mark = Int32.Parse(xe.Element("mark").Value),
                            Course = xe.Element("Course").Value,
                        };
            var res = from temp in items
                      group temp by temp.Course into g
                      select new
                      {
                          name = g.Key,
                          avg = g.Average(x => x.Mark)
                      };
            foreach (var item in res)
            {
                text = text + $"{item.name} : {item.avg} \n";
            }
            return text;
        }
        public static string Test(string Name,string Zachetka,string Mark,string Subject,string Course,string Group)
        {
            string text;
                text = $"Student: {Name} on course: {Course} from group: {Group} got {Mark} for {Subject} in his zachetka: {Zachetka}";
            return text;
        }
        public static bool TestDecimal(string str)
        {
            bool res = true;
            int test;
            try
            {
                test = Int32.Parse(str);
            }
            catch(FormatException)
            {
                res = false;
            }
            return res;
        }
        public static bool TestCondition(string name,string course,string zachetka,string group,string mark,string subject)
        {
            bool res = true;
            int temp = Int32.Parse(mark);
            if (name == "" || zachetka == "" || group == "" || course == "" || subject == "" || temp > 10 || temp < 1)
            {
                res = false;
            }
            return res;
        }
    }
    class Student
    {
        public string Name { get; set; }
        public string Mark { get; set; }
        public string Group { get; set; }
        public string Zachetka { get; set; }
        public string Subject { get; set; }
        public string Course { get; set; }
    }
}
