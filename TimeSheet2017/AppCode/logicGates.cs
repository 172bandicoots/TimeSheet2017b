using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TimeSheet2017.AppCode
{
    public class logicGates
    {
        //logical OR operation test method
        public bool orGate(bool a, bool b)
        {
            if(a || b) { return true; }
            return false;
        }

        //logical AND operation test method
        public bool andGate(bool a, bool b)
        {
            if (a && b) { return true; }
            return false;
        }

        //logical NOT operation test method
        public bool notGate(bool a)
        {
            if (!a) { return true; }
            return false;
        }
    }
}