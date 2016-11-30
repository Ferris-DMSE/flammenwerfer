using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flammenwerfer
{
    class Query
    {
        Query_Search Search = new Query_Search();
        public void StartQuery(string sUserquery)//this seperates the command and then begins the proper search type
        {
            sUserquery.ToLower();
            string[] sQueryArray = sUserquery.Split(' ');//seperates sUserquery

            string sQueryType = sQueryArray[0];//seperates the search type


            string sQueried = " ";//used if sQueryArray[1] is left blank
            sQueried = sQueryArray[1];//seperates the searched name/id
            sQueried = sQueried.ToLower();

            Search.Search(sQueried, sQueryType);
        }
    }
}
