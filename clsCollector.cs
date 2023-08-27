using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plain_Old_Class_Object__POCO__Pattern
{
    internal class clsCollector
    {

        string strCollectorType = "";
        string strDescription = "";
        //The collector ID is the primary key for the database. It is always a positive integer value. Assigned here intitally as -1 to indicate that it has not been correctly initialized with data from the database.
        long lngCollectorID = -1;

        /// <summary>
        /// Listing of the fields in this class -- should match the fields in the Step table of the database.
        /// </summary>
        public enum CollectorFields
        {
            strCollectorType,
            strDescription,
            lngCollectorID
        }

        /// <summary>
        /// Listing of the possible collector types.
        /// </summary>
        public enum CollectorTypes
        {
            Text,
            Numeric,
            Category,
            Linked,
            PassFail
        }

        /// <summary>
        /// Get a datarow from the Collector table in the database and pass into this constructor to instantiate a Collector object.
        /// </summary>
        /// <param name="dr">dr must contain columns as given in the Enum CollectorFields</param>
        public clsCollector(DataRow dr)
        {
            //Parse the type, description, and ID from the datarow that was passed into the constructor and use to set those fields in this object.
            strCollectorType = dr[CollectorFields.strCollectorType.ToString()].ToString();
            strDescription = dr[CollectorFields.strDescription.ToString()].ToString();
            long.TryParse(dr[CollectorFields.lngCollectorID.ToString()].ToString(), out long lngCollector);
        }




    }
}
