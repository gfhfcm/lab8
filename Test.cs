using Microsoft.VisualStudio.TestTools.UnitTesting;
using XmlForm;
using System;

namespace XmlTest
{
    [TestClass]
    public class Test
    {
        [TestMethod]
        public void Output()
        {
            string name = "Korfoo";
            string zachetka = "12";
            string group = "1";
            string mark = "4";
            string course = "2";
            string subject = "maths";
            var result = XmlForm.Procedures.Test(name,zachetka,mark,subject,course,group);
            string expected = $"Student: {name} on course: {course} from group: {group} got {mark} for {subject} in his zachetka: {zachetka}";
            Assert.AreEqual(expected, result, "WrongAnswer");
        }
        [TestMethod]
        public void NullOutput()
        {
            string name = "Korfoo";
            string zachetka = "";
            string group = "";
            string mark = "";
            string course="";
            string subject = "maths";
            var result = XmlForm.Procedures.Test(name, zachetka, mark, subject, course, group);
            string expected = $"Student: {name} on course: {course} from group: {group} got {mark} for {subject} in his zachetka: {zachetka}";
            Assert.AreEqual(expected, result, "WrongAnswer");
        }
        [TestMethod]
        public void DecimalCheck1()
        {
            string str = "";
            bool expected = false;
            var result = XmlForm.Procedures.TestDecimal(str);
            Assert.AreEqual(expected, result, "WrongAnswer");
        }
        [TestMethod]
        public void DecimalCheck2()
        {
            string str = "ab";
            bool expected = false;
            var result = XmlForm.Procedures.TestDecimal(str);
            Assert.AreEqual(expected, result, "WrongAnswer");
        }
        [TestMethod]
        public void DecimalCheck3()
        {
            string str = "   ";
            bool expected = false;
            var result = XmlForm.Procedures.TestDecimal(str);
            Assert.AreEqual(expected, result, "WrongAnswer");
        }
        [TestMethod]
        public void DecimalCheck4()
        {
            string str = "4";
            bool expected = true;
            var result = XmlForm.Procedures.TestDecimal(str);
            Assert.AreEqual(expected, result, "WrongAnswer");
        }
        [TestMethod]
        public void DecimalCheck5()
        {
            string str = "4";
            bool expected = true;
            var result = XmlForm.Procedures.TestDecimal(str);
            Assert.AreEqual(expected, result, "WrongAnswer");
        }
        [TestMethod]
        public void DecimalCheck6()
        {
            string str = "99999999999999999999999999999999999999999999999999999999999999999999999999999";
            Assert.ThrowsException<OverflowException>(() => { XmlForm.Procedures.TestDecimal(str); });
        }
        [TestMethod]
        public void ConditionCheck1()
        {
            string name = "";
            string zachetka = "f";
            string group = "f";
            string mark = "3";
            string course = "f";
            string subject = "maths";
            bool expected = false;
            var result = XmlForm.Procedures.TestCondition(name, course, zachetka, group, mark, subject);
            Assert.AreEqual(expected, result, "Wrong answer");
        }
        [TestMethod]
        public void ConditionCheck2()
        {
            string name = "Korfoo";
            string zachetka = "";
            string group = "f";
            string mark = "3";
            string course = "f";
            string subject = "maths";
            bool expected = false;
            var result = XmlForm.Procedures.TestCondition(name, course, zachetka, group, mark, subject);
            Assert.AreEqual(expected, result, "Wrong answer");
        }
        [TestMethod]
        public void ConditionCheck3()
        {
            string name = "Korfoo";
            string zachetka = "f";
            string group = "";
            string mark = "3";
            string course = "f";
            string subject = "maths";
            bool expected = false;
            var result = XmlForm.Procedures.TestCondition(name, course, zachetka, group, mark, subject);
            Assert.AreEqual(expected, result, "Wrong answer");
        }
        [TestMethod]
        public void ConditionCheck4()
        {
            string name = "Korfoo";
            string zachetka = "f";
            string group = "f";
            string mark = "3";
            string course = "f";
            string subject = "";
            bool expected = false;
            var result = XmlForm.Procedures.TestCondition(name, course, zachetka, group, mark, subject);
            Assert.AreEqual(expected, result, "Wrong answer");
        }
        [TestMethod]
        public void ConditionCheck5()
        {
            string name = "Korfoo";
            string zachetka = "f";
            string group = "f";
            string mark = "0";
            string course = "f";
            string subject = "maths";
            bool expected = false;
            var result = XmlForm.Procedures.TestCondition(name, course, zachetka, group, mark, subject);
            Assert.AreEqual(expected, result, "Wrong answer");
        }
        [TestMethod]
        public void ConditionCheck6()
        {
            string name = "Korfoo";
            string zachetka = "f";
            string group = "f";
            string mark = "11";
            string course = "g";
            string subject = "maths";
            bool expected = false;
            var result = XmlForm.Procedures.TestCondition(name, course, zachetka, group, mark, subject);
            Assert.AreEqual(expected, result, "Wrong answer");
        }
        [TestMethod]
        public void ConditionCheck7()
        {
            string name = "Korfoo";
            string zachetka = "g";
            string group = "g";
            string mark = "4";
            string course = "f";
            string subject = "maths";
            bool expected = true;
            var result = XmlForm.Procedures.TestCondition(name, course, zachetka, group, mark, subject);
            Assert.AreEqual(expected, result, "Wrong answer");
        }
        [TestMethod]
        public void ConditionCheck8()
        {
            string name = "Korfoo";
            string zachetka = "f";
            string group = "f";
            string mark = "11";
            string course = "f";
            string subject = "maths";
            bool expected = false;
            var result = XmlForm.Procedures.TestCondition(name, course, zachetka, group, mark, subject);
            Assert.AreEqual(expected, result, "Wrong answer");
        }
    }
}
