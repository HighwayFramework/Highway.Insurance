using System;

namespace Highway.Insurance.UI.Exceptions
{
    public class HighwayInsuranceWrongPageExpectedException : Exception
    {
        public HighwayInsuranceWrongPageExpectedException(string sMessage) : base(sMessage) { }
    }
}