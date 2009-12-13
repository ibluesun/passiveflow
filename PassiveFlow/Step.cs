using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PassiveFlow
{
    public struct Step
    {
        /// <summary>
        /// Name of the step.
        /// </summary>
        public string Name; 

        /// <summary>
        /// Types associated to this step.
        /// </summary>
        public Type[] AssociatedTypes;

        /// <summary>
        /// Step Id
        /// </summary>
        public int Id;


        /// <summary>
        /// Indicates if this stage should be skipped during 
        /// </summary>
        public bool Skip;

        /// <summary>
        /// Describe the step
        /// </summary>
        public string Description_1;

        /// <summary>
        /// Describe the stage
        /// </summary>
        public string Description_2;


        /// <summary>
        /// The host type of this step
        /// </summary>
        public readonly Type FlowHostType;


        /// <summary>
        /// The actions of this step.
        /// Used when the step be an active step in the host.
        /// </summary>
        public StepAction[] AttachedActions;

        public Step(Type flowHostType)
        {

            FlowHostType = flowHostType;

            Name = "";
            AssociatedTypes = null;
            Id = 0;
            Skip = false;

            AttachedActions = null;
            Description_1 = ""; Description_2 = "";

        }

        public override string ToString()
        {
            return Name;
        }


        /// <summary>
        /// Get the id of the step.
        /// </summary>
        /// <param name="fi"></param>
        /// <returns></returns>
        public static implicit operator int(Step fi)
        {
            return fi.Id;
        }

        

        /// <summary>
        /// Get the name of the step.
        /// </summary>
        /// <param name="fi"></param>
        /// <returns></returns>
        public static implicit operator string(Step fi)
        {
            return fi.Name;
        }

        /// <summary>
        /// Get the index of this step in the host type.
        /// </summary>
        public int StepIndex
        {
            get
            {
                Flow Parent = (Flow)this.FlowHostType.Assembly.CreateInstance(this.FlowHostType.FullName);
                Parent.ReSetToStep(this.Id);
                return Parent.CurrentStepIndex;
            }
        }


        /// <summary>
        /// get the enclosing class and return new instance from it
        /// pointing to this item
        /// </summary>
        /// <param name="fi"></param>
        /// <returns></returns>
        public static implicit operator Flow(Step fi)
        {
            Flow Parent = (Flow)fi.FlowHostType.Assembly.CreateInstance(fi.FlowHostType.FullName);
            Parent.ReSetToStep(fi.Id);
            return Parent;
        }
    }

}
