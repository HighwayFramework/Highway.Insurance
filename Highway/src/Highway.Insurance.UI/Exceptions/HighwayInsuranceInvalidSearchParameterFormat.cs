﻿using System;

namespace Highway.Insurance.UI.Exceptions
{
    public class HighwayInsuranceInvalidSearchParameterFormat : Exception
    {
        public HighwayInsuranceInvalidSearchParameterFormat(string searchParameters)
            : base(string.Format("Search Parameter Format is not valid -> '{0}', should be like 'sKey1=sValue1;sKey2=sValue2;'.", searchParameters))
        { }
    }
}