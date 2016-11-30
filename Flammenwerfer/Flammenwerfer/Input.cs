using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Flammenwerfer
{
    #region Input Parsing System

    class CommandInput
    {
            /*setup of required materials*/
        #region Variable Declaration
        /*Variables used in Input logic. calls out required strings and classes to connect logic together*/
        string sRegexParser; //Regular Expression Placeholder string
        string sParsedInCommand = ""; //Parsed string file to hand off for query
        string sInputCommand = ""; //Input String
        string sCommand = ""; //Command string to compare
        List<string> sSeperatedCMD = new List<string>(); // split string 
        XML_Creator creation = new XML_Creator(); //Callout to XML User Creation
        Query query = new Query(); // initiating callout for user search
        Output display = new Output(); //Visual display logic class callout

        #endregion
            /*entry point of system*/
        #region Input Handler

        public void InputReader()
        { //Entry point of Input, sets up logic structure of input system
            Console.Clear();
            sSeperatedCMD.Clear(); //ensures command entry is cleared out before new commands are entered
            sInputCommand = display.ReadInfoDisplay("<action> *(<Search Type> <Search Data>)* \n *Only needed if searching \n \n ex. 'get fname John' returns query using first name John\n ex. 'get lname Smith' returns query using last name Smith\n ex. 'get sid 3-61-206' returns query using student ID \n ex. 'set' starts user creation menu \n \n ENTER COMMAND: "); //takes in command to match prompt
            InputLayoutParser(); //Parses the layout text for passthrough to the query
            CommandParser(); //Parses the command into testable logic
            ParseGetSetTest(); //Actual command test logic
        }

        #endregion
            /*Comparison system to match to proper action command*/
        #region Testing Methods
        /*Start action command comparison test*/
        private void ParseGetSetTest()
        { //tests for command parsing setup
            switch (sCommand)
            {
                case "get": //if 'get' command is matched, go to query system
                    QueryParsing(); //Parses the query command and paramater into the passthrough string
                    query.StartQuery(sParsedInCommand);
                    break;

                case "set": //if 'set' command is matched, go to user creation
                    creation.instantiator();
                    break;

                default: //if all other commands fail, flag as unmatched
                    ResetWrongValue();
                    break;
            }
        }

        private void ResetWrongValue()
        { //Action flagged for when command entered does not match given types
            display.DumbInfoDisplay("Invalid entry \n Press any key to continue... \n");
            InputReader();
        }
        /*End action command comparison test*/
        #endregion
            /*Parsing systems to format text into easily testable formats*/
        #region regex methods

        /*Seperate input command string into editable chunks*/
        private void InputLayoutParser()
        { //Input string partially parsed out to be sorted by other parsing systems
            string[] stemparray = sInputCommand.Split(' ');
            foreach (string i in stemparray)
            {
                sSeperatedCMD.Add(i);
            }
            for (int i = 0; i < 2; i++) { sSeperatedCMD.Add(""); }
        }
        /*Start of action command checking parser*/
        private void CommandParser()
        {/*Regular Expressions testing of inputted action command*/
            MatchCollection mCommandGet = Regex.Matches(sSeperatedCMD[0], "(?i)^g", RegexOptions.Singleline);
            MatchCollection mCommandSet = Regex.Matches(sSeperatedCMD[0], "(?i)^s", RegexOptions.Singleline);
            CommandMatchTest(mCommandGet, mCommandSet);
        }

        private void CommandMatchTest(MatchCollection mCommandGet, MatchCollection mCommandSet)
        { //Match testing from command regular expressions testing
            sCommand = "Fail";
            foreach (Match m in mCommandGet)
            {
                sCommand = "get";
            }
            foreach (Match m in mCommandSet)
            {
                sCommand = "set";
            }
        }
        /*end of action command checking parser*/

        /* start of Parsing for Query command passthrough */
        private void QueryParsing() 
        { /*Regular Expressions testing of inputted Query command*/
            MatchCollection mSIDTypeParse = Regex.Matches(sSeperatedCMD[1], "(?i)id", RegexOptions.Singleline);
            MatchCollection mFNTypeParse = Regex.Matches(sSeperatedCMD[1], "(?i)^f.+?n.+|(?i)f", RegexOptions.Singleline);
            MatchCollection mLNTypeParse = Regex.Matches(sSeperatedCMD[1], "(?i)^l.+?n.+|(?i)l", RegexOptions.Singleline);
            RegexMatchTest(mSIDTypeParse, mFNTypeParse, mLNTypeParse);
            ParseMerger();
        }

        private void RegexMatchTest(MatchCollection mSIDTypeParse, MatchCollection mFNTypeParse, MatchCollection mLNTypeParse)
        { //Match testing from query regular expressions testing
            sRegexParser = "failed";
            foreach (Match m in mSIDTypeParse)
            {
                sRegexParser = "sid";
            }
            foreach (Match m in mFNTypeParse)
            {
                sRegexParser = "fname";
            }
            foreach (Match m in mLNTypeParse)
            {
                sRegexParser = ("lname");
            }
        }

        private void ParseMerger() 
        { //Parsing merger for query. layed out as: [Matched search type] [search paramater]
            sParsedInCommand = sRegexParser + " " + sSeperatedCMD[2];
            Console.WriteLine(sParsedInCommand);
        }
        /*End of Query command passthrough parsing*/
        #endregion
    }

    class XMLPATH
    {
        public string Path = "../../UserData.xml";
    }
}

#endregion

