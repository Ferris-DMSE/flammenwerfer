using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Data.Xml.Dom;
//using System.Xml;
using Windows.Storage;
using System.IO;
using Windows.Storage.Streams;

namespace Flammenwerfer
{
    class Query_Search
    {

        private List<string> studentsFoundInQuery;
        public List<string> StudentsFoundInQuery { get { return studentsFoundInQuery; } }

        public void Search(string sSearchParamater, string type)
        {
            //type is to determine which of the 3 standard XML searchable types for user searching is possible

            List<string> lFoundStudent = new List<string>();//this list will be used to send the found information to the next class
            lFoundStudent.Add(""); //used to be a placeholder for number of courses a student has on record
            string sArchiveSearch = "";//used to hold Searched Value found in the xml file
            string sArchiveUID = ""; //used to reference class data to match courses
            string sSearchedUID = ""; //store variable to searching UID variable
            bool bStudentFound = false;//will be set to true if student is found
            int iCourseCounter = 0;
            var rootpoint = Windows.ApplicationModel.Package.Current.InstalledLocation.Path;
            var spath = rootpoint + @"\UserData.xml";
            var xmlString = File.ReadAllText(spath);
            XmlDocument xmlArchive = new XmlDocument();
            xmlArchive.LoadXml(xmlString);//loads the precreated xml doc,takes the path string found in the XML_Creator class
            XmlNodeList XNList = xmlArchive.SelectNodes("/Students/Student");
            XmlNodeList XNListCourses = xmlArchive.SelectNodes("/Students/Student/Courses/Course");
            foreach (var Node in XNList)
            {
                sArchiveSearch = Node[type].InnerText;
                if (sArchiveSearch == sSearchParamater)
                {
                    bStudentFound = true;
                    lFoundStudent.Add(Node["SID"].InnerText);
                    sSearchedUID = Node["SID"].InnerText;
                    lFoundStudent.Add(Node["FName"].InnerText);
                    lFoundStudent.Add(Node["LName"].InnerText);
                    foreach (var xNode in XNListCourses)
                    {
                        sArchiveUID = xNode["UID"].InnerText;
                        if (sArchiveUID == sSearchedUID)
                        {
                            iCourseCounter++;
                            lFoundStudent.Add(xNode["CourseID"].InnerText);
                            lFoundStudent.Add(xNode["CourseNumber"].InnerText);
                            lFoundStudent.Add(xNode["CourseName"].InnerText);
                            lFoundStudent.Add(xNode["Credits"].InnerText);
                            lFoundStudent.Add(xNode["Year"].InnerText);
                            lFoundStudent.Add(xNode["Semester"].InnerText);
                            lFoundStudent.Add(xNode["CourseType"].InnerText);
                            lFoundStudent.Add(xNode["CourseGrade"].InnerText);
                        }
                        lFoundStudent[0] = Convert.ToString(iCourseCounter);
                    }
                }
            }
            //loads the precreated xml doc,takes the path string found in the XML_Creator class

            if (bStudentFound == true)
            {
                studentsFoundInQuery = lFoundStudent;
            }
        }

    }
}

/* using (XmlReader XReader = XmlReader.Create(new StringReader(xmlString)))
 {
     XReader.ReadStartElement("Students");
     while (!XReader.EOF)
     {
         sArchiveSearch = XReader.GetAttribute(type);
         if (sArchiveSearch == sSearchParamater)
         {
         }
     }
 }*/

/* using (var stream = await file.OpenStreamForReadAsync())
 {
     XDocument xmlArchive = XDocument.Load(spath);
     var StudentList = xmlArchive.Element("Students").Elements("SID");
     var StudentListIndex = StudentList.Count();
     var CourseList = xmlArchive.Element("Courses").Elements("CourseID");
     var CourseListIndex = CourseList.Count();



     foreach (var item in StudentList)
     {
         XName SearchParam = sSearchParamater;
         sArchiveSearch = xmlArchive.Element("Student").Attribute(type).Value.ToString();
         if (sArchiveSearch == sSearchParamater)//if the searched name equal and achieved name then sFoundStudent is filled with the the information from the archieve
         {
             bStudentFound = true;
             sSearchedUID = xmlArchive.Element("Student").Attribute("SID").Value.ToString();
             lFoundStudent.Add(sSearchedUID);
             lFoundStudent.Add(xmlArchive.Element("Student").Attribute("FName").Value.ToString());
             lFoundStudent.Add(xmlArchive.Element("Student").Attribute("LName").Value.ToString());
             foreach (var Item in CourseList)
             {
                 sArchiveUID = xmlArchive.Element("Course").Attribute("UID").Value.ToString();
                 if (sArchiveUID == sSearchedUID)
                 {
                     iCourseCounter++;
                     lFoundStudent.Add(xmlArchive.Element("Course").Attribute("CourseID").Value.ToString());
                     lFoundStudent.Add(xmlArchive.Element("Course").Attribute("CourseNumber").Value.ToString());
                     lFoundStudent.Add(xmlArchive.Element("Course").Attribute("CourseName").Value.ToString());
                     lFoundStudent.Add(xmlArchive.Element("Course").Attribute("Credits").Value.ToString());
                     lFoundStudent.Add(xmlArchive.Element("Course").Attribute("Year").Value.ToString());
                     lFoundStudent.Add(xmlArchive.Element("Course").Attribute("Semester").Value.ToString());
                     lFoundStudent.Add(xmlArchive.Element("Course").Attribute("CourseType").Value.ToString());
                     lFoundStudent.Add(xmlArchive.Element("Course").Attribute("CourseGrade").Value.ToString());
                 }
                 lFoundStudent[0] = Convert.ToString(iCourseCounter);
             }
         }
     }
 }*/
