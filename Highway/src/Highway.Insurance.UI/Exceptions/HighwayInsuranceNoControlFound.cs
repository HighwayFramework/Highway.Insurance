using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Highway.Insurance.UI.Exceptions
{
    public class HighwayInsuranceNoControlFound : Exception
    {
        public HighwayInsuranceNoControlFound(string message) : base(message)
        {

        }
    }
}
