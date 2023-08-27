using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Plain_Old_Class_Object__POCO__Pattern
{
    public class clsStep
    {

        public enum StepFields
        {
            lngStepID
        }

        List<clsCollector> Collectors = new List<clsCollector>();

        //The primary key for the step record in the database. It is always a positive integer. Set here to -1 to indicate that it has not yet been initialized with valid data.
        long lngStepID = -1;



        public clsStep(DataRow dr)
        {

           long.TryParse(dr[StepFields.lngStepID.ToString()].ToString(), out long lngStepID);

           
            System.Data.DataTable dt = new System.Data.DataTable();
            clsSQLiteConn newSQLiteConn = new clsSQLiteConn();
            newSQLiteConn.PopulateADataTable(ref dt, "Collector");

            foreach(DataRow drNewCollector in dt.Rows )
            {
                clsCollector newCollector = new clsCollector(drNewCollector);
                Collectors.Add(newCollector);
            }
        }


    }
}
