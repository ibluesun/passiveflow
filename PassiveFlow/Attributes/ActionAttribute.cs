using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PassiveFlow.Attributes
{
    public abstract class ActionAttribute : Attribute
    {
        public readonly int ActionID;
        public readonly string ActionText;
        public readonly int RelativeIndex;
        public readonly int StageStatusID;

        public readonly string TargetStepName;

        public ActionAttribute(int actionId, string actionText, int relativeIndex, int statusId = 0)
        {
            ActionID = actionId;
            ActionText = actionText;
            RelativeIndex = relativeIndex;
            StageStatusID = statusId;
        }

        public ActionAttribute(int actionId, string actionText, string targetStepName, int statusId = 0)
        {
            ActionID = actionId;
            ActionText = actionText;
            TargetStepName = targetStepName;
            StageStatusID = statusId;
        }
    }
}
