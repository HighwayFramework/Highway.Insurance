using System;
using System.Collections.Generic;

namespace Highway.Insurance.UI.Exceptions
{
    public class HighwayInsuranceInvalidSearchKey : Exception
    {
        public HighwayInsuranceInvalidSearchKey(string sKey, string searchParameters, List<string> controlProperties)
            : base(string.Format("Search Pattern Key not supported -> '{0}' in '{1}'. Available Properties: {2}", sKey, searchParameters,
                string.Join(", ", controlProperties)))
        { }
    }
}