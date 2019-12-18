using System;  
using System.Collections.Generic;  
using System.Linq;  
using System.Threading.Tasks;  
using Microsoft.AspNetCore.Mvc;  
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;
  
namespace program.Pages  
{  
    public class RidershipByYearModel : PageModel  
    {  
        public List<int> Year { get; set; }
        public List<int> NumRiders { get; set; }
        public Exception EX { get; set; }
  
        public void OnGet()  
        {
          Year = new List<int>();
          NumRiders = new List<int>();
          
          EX = null;
          
          Year.Add(2001);
          Year.Add(2002);
          Year.Add(2003);
          Year.Add(2004);
          Year.Add(2005);
          Year.Add(2006);
          Year.Add(2007);
          Year.Add(2008);
          Year.Add(2009);
          Year.Add(2010);
          Year.Add(2011);
          Year.Add(2012);
          Year.Add(2013);
          Year.Add(2014);
          Year.Add(2015);
          Year.Add(2016);
          Year.Add(2017);
          Year.Add(2018);
          try
          {
            string sql = string.Format(@"
SELECT  YEAR(TheDate) AS TheMonth, Sum(DailyTotal) AS NumRiders
FROM Riderships
GROUP BY Year(TheDate)
ORDER BY Year(TheDate);
");
          
            DataSet ds = DataAccessTier.DB.ExecuteNonScalarQuery(sql);

            foreach (DataRow row in ds.Tables[0].Rows)
            {
              int numriders = Convert.ToInt32(row["NumRiders"]);

              NumRiders.Add(numriders);
            }
		      }
		      catch(Exception ex)
		      {
            EX = ex;
		      }
		      finally
		      { 
            // nothing at the moment
          } 
        }  
        
    }//class
}//namespace