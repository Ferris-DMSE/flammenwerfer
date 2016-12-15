using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using Windows.Data.Xml.Dom;
using System.Xml.Linq;
//using Windows.Data.Xml.Xsl;
using System.Xml;
using Windows.Storage;
using System.IO;
using Windows.Storage.Streams;
using Flammenwerfer_UWP;

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
            string sSearchedStudent = "";
            int index = 0;
            int studentOffset = 0;
            int caseOffset = 0;
            string sSearchedUID = ""; //store variable to searching UID variable
            bool bStudentFound = false;//will be set to true if student is found
            int iCourseCounter = 0;
            var rootpoint = Windows.ApplicationModel.Package.Current.InstalledLocation.Path;
            var spath = rootpoint + @"\UserData.xml";
            //string xmlString = "<Root><Students><Student><SID>3-61-206</SID><FName>John</FName><LName>Smith</LName></Student><Student><SID>1-22-424</SID><FName>Jake</FName><LName>Johnson</LName></Student><Student><SID>1-61-397</SID><FName>Samantha</FName><LName>Robertson</LName></Student><Student><SID>123</SID><FName>Rick</FName><LName>Baker</LName></Student></Students><Courses><Course><UID>3-61-206</UID><CourseID>9380</CourseID><CourseNumber>MA-230</CourseNumber><CourseName>Calculus 2</CourseName><Credits>5</Credits><Year>2016</Year><Semester>spring</Semester><CourseType>general education</CourseType><CourseGrade>C-</CourseGrade></Course><Course><UID>3-61-206</UID><CourseID>7382</CourseID><CourseNumber>EN-315</CourseNumber><CourseName>Advanced English Composition</CourseName><Credits>3</Credits><Year>2015</Year><Semester>Fall</Semester><CourseType>General Education</CourseType><CourseGrade>D+</CourseGrade></Course><Course><UID>123</UID><CourseID>3139</CourseID><CourseNumber>ALC-120</CourseNumber><CourseName>Basic Alchemy</CourseName><Credits>3</Credits><Year>2016</Year><Semester>Fall</Semester><CourseType>Core</CourseType><CourseGrade>A</CourseGrade></Course><Course><UID>1-61-397</UID><CourseID>3139</CourseID><CourseNumber>ALC-120</CourseNumber><CourseName>Basic Alchemy</CourseName><Credits>8</Credits><Year>2016</Year><Semester>Fall</Semester><CourseType>Core</CourseType><CourseGrade>B-</CourseGrade></Course><Course><UID>1-61-397</UID><CourseID>7644</CourseID><CourseNumber>DBM-315</CourseNumber><CourseName>Advanced Blood Magic</CourseName><Credits>6</Credits><Year>2016</Year><Semester>Fall</Semester><CourseType>General Education</CourseType><CourseGrade>A+</CourseGrade></Course><Course><UID>1-22-424</UID><CourseID>9975</CourseID><CourseNumber>ALC-120</CourseNumber><CourseName>Basic Alchemy</CourseName><Credits>8</Credits><Year>2016</Year><Semester>Fall</Semester><CourseType>Core</CourseType><CourseGrade>B-</CourseGrade></Course><Course><UID>1-22-424</UID><CourseID>9266</CourseID><CourseNumber>EN-315</CourseNumber><CourseName>Advanced English Composition</CourseName><Credits>3</Credits><Year>2015</Year><Semester>Fall</Semester><CourseType>General Education</CourseType><CourseGrade>D+</CourseGrade></Course></Courses></Root>";//File.ReadAllText(spath);
            XDocument xmlArchive = XDocument.Load(spath);
            //xmlArchive.LoadXml(xmlString);//loads the precreated xml doc,takes the path string found in the XML_Creator class
            var XNList =
                from node in xmlArchive.Nodes()
                select node;
            var nodes = from node in xmlArchive.DescendantNodes()
                        select node;
            var TypeElement = new XElement(type, sSearchParamater);
            List<string> SIDList = xmlArchive.Elements("Students")
                                                          .Elements("Student")
                                                          .Descendants("SID")
                                                          .Select(x => (string)x)
                                                          .ToList();
            List<string> FNameList = xmlArchive.Elements("Students")
                                               .Elements("Student")
                                               .Descendants("FName")
                                               .Select(x => (string)x)
                                               .ToList();
            List<string> LNameList = xmlArchive.Elements("Students")
                                               .Elements("Student")
                                               .Descendants("LName")
                                               .Select(x => (string)x)
                                               .ToList();
            List<string> SearchList = xmlArchive.Elements("Students")
                                               .Elements("Student")
                                               .Descendants(type)
                                               .Select(x => (string)x)
                                               .ToList();
            List<string> UIDList = xmlArchive.Elements("Students")
                                              .Elements("Student")
                                              .Elements("Courses")
                                              .Elements("Course")
                                              .Descendants("UID")
                                              .Select(x => (string)x)
                                              .ToList();
            List<string> CIDList = xmlArchive.Elements("Students")
                                              .Elements("Student")
                                              .Elements("Courses")
                                              .Elements("Course")
                                              .Descendants("CourseID")
                                              .Select(x => (string)x)
                                              .ToList();
            List<string> CNumList = xmlArchive.Elements("Students")
                                              .Elements("Student")
                                              .Elements("Courses")
                                              .Elements("Course")
                                              .Descendants("CourseNumber")
                                              .Select(x => (string)x)
                                              .ToList();
            List<string> CNameList = xmlArchive.Elements("Students")
                                              .Elements("Student")
                                              .Elements("Courses")
                                              .Elements("Course")
                                              .Descendants("CourseName")
                                              .Select(x => (string)x)
                                              .ToList();
            List<string> CreditsList = xmlArchive.Elements("Students")
                                              .Elements("Student")
                                              .Elements("Courses")
                                              .Elements("Course")
                                              .Descendants("Credits")
                                              .Select(x => (string)x)
                                              .ToList();
            List<string> YearList = xmlArchive.Elements("Students")
                                              .Elements("Student")
                                              .Elements("Courses")
                                              .Elements("Course")
                                              .Descendants("Year")
                                              .Select(x => (string)x)
                                              .ToList();
            List<string> SemList = xmlArchive.Elements("Students")
                                              .Elements("Student")
                                              .Elements("Courses")
                                              .Elements("Course")
                                              .Descendants("Semester")
                                              .Select(x => (string)x)
                                              .ToList();
            List<string> CTList = xmlArchive.Elements("Students")
                                              .Elements("Student")
                                              .Elements("Courses")
                                              .Elements("Course")
                                              .Descendants("CourseType")
                                              .Select(x => (string)x)
                                              .ToList();
            List<string> CGList = xmlArchive.Elements("Students")
                                              .Elements("Student")
                                              .Elements("Courses")
                                              .Elements("Course")
                                              .Descendants("CourseGrade")
                                              .Select(x => (string)x)
                                              .ToList();
            foreach (var item in SearchList)
            {
                var node = item.ToLower();
                sSearchParamater = sSearchParamater.ToLower();
                if (node == sSearchParamater)
                {
                    bStudentFound = true;
                    sSearchedUID = SIDList[index];
                    lFoundStudent.Add(SIDList[index]);
                    lFoundStudent.Add(FNameList[index]);
                    lFoundStudent.Add(LNameList[index]);
                    int CourseIndex = 0;
                    foreach (var cItem in UIDList)
                    {
                        if (cItem == sSearchedUID)
                        {
                            lFoundStudent.Add(CIDList[CourseIndex]);
                            lFoundStudent.Add(CNumList[CourseIndex]);
                            lFoundStudent.Add(CNameList[CourseIndex]);
                            lFoundStudent.Add(CreditsList[CourseIndex]);
                            lFoundStudent.Add(YearList[CourseIndex]);
                            lFoundStudent.Add(SemList[CourseIndex]);
                            lFoundStudent.Add(CTList[CourseIndex]);
                            lFoundStudent.Add(CGList[CourseIndex]);
                        }
                        CourseIndex++;
                    }
                    //break;
                }
                index++;
            }


            //loads the precreated xml doc,takes the path string found in the XML_Creator class
            if (bStudentFound == true)
            {
                studentsFoundInQuery = lFoundStudent;
            }
        }
    }
}
