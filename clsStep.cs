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
        /// <summary>
        /// Listing of the fields in this class -- should match the fields in the Step table of the database.
        /// </summary>
        public enum StepFields
        {
            lngStepID
        }

        /// <summary>
        /// List of collector objects that belong to an instance of this class.
        /// </summary>
        List<clsCollector> Collectors = new List<clsCollector>();

        /// <summary>
        /// The primary key for the step record in the database. It is always a positive integer. Set here to -1 to indicate that it has not yet been initialized with valid data.
        /// </summary>
        long lngStepID = -1;


        /// <summary>
        /// Constructor for the step object. Get datarow from the Step table in the db and pass into this constructor.
        /// </summary>
        /// <param name="dr">The datarow dr must have fields as listed in the StepFileds enum.</param>
        public clsStep(DataRow dr)
        {
            //Parse the Step ID (long) from the datarow that was passed into the constructor.
           long.TryParse(dr[StepFields.lngStepID.ToString()].ToString(), out long lngStepID);

            //Use the Step ID to find collecotrs that belong to this step.
            System.Data.DataTable dt = new System.Data.DataTable();
            clsSQLiteConn newSQLiteConn = new clsSQLiteConn();
            newSQLiteConn.PopulateADataTable(ref dt, "Collector");

            //Instantiate a list of collectors that belong to this step.
            foreach(DataRow drNewCollector in dt.Rows )
            {
                clsCollector newCollector = new clsCollector(drNewCollector);
                Collectors.Add(newCollector);
            }
        }

        /// <summary>
        /// Get all collectors that belong to this step that are of the specified type.
        /// </summary>
        /// <param name="CollectorType">Collector types are enumerated in the clsCollector.CollectorTpes enum.</param>
        /// <returns></returns>
        public List<clsCollector> FilterCollectorsByType(string CollectorType)
        {
            var MatchingCollectors = from collector in Collectors
                                     where collector.strCollectorType == CollectorType
                                     select collector;
            return MatchingCollectors.ToList();
        }


    }
}
