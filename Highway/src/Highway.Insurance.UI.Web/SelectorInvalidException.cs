using System;

namespace Highway.Insurance.UI.Web
{
    public class SelectorInvalidException : Exception
    {
        public SelectorInvalidException(string selector) : base(string.Format("Selector {0} does not return any elements",selector))
        {
           
        }
    }
}