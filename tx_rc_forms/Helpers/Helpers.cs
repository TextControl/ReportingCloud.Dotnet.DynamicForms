using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TXTextControl.ReportingCloud;

namespace tx_rc_forms
{
    public class Helpers
    {
        // removes all duplicate field names
        public static List<MergeField> RemoveDuplicates(List<MergeField> inputList)
        {
            Dictionary<string, int> uniqueStore = new Dictionary<string, int>();
            List<MergeField> finalList = new List<MergeField>();

            foreach (MergeField currValue in inputList)
            {
                if (!uniqueStore.ContainsKey(currValue.Name))
                {
                    uniqueStore.Add(currValue.Name, 0);
                    finalList.Add(currValue);
                }
            }
            return finalList;
        }
    }
}
