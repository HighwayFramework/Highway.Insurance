using System;

namespace Highway.Insurance.UI.Exceptions
{
    public class HighwayInsuranceInvalidTraversal : Exception
    {
        public HighwayInsuranceInvalidTraversal(string sMessage)
            : base(string.Format("You are trying to traverse to an element/control which is not present in the tree: {0}", sMessage))
        { }
    }
}