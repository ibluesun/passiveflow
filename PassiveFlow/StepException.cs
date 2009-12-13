using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PassiveFlow
{
    [Serializable]
    public class StepException : Exception
    {
        public StepException()
            :base()
        {
        }

        public StepException(string message)
            : base(message)
        {
        }
    }
}
