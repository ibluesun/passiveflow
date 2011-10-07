using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using PassiveFlow;

namespace SampleCycle
{
    class Program
    {
        static void Main(string[] args)
        {

            // Let us emulate a car gear box.


            Console.WriteLine("Gear Box Flow");
            Flow gbox = GearBox.Neutral; //this way you set the current 
            gbox.StepChanged += new EventHandler<StepEventArgs>(gbox_StepChanged);


            gbox++;
            gbox++;
            gbox++;
            gbox++;
            gbox--;
            gbox--;
            gbox--;
            gbox--;
            gbox += 2;
            gbox--;
            gbox--;
            gbox++;
            gbox++;

            gbox.StepTo(GearBox.ReverseShift);

            gbox += 4;
            gbox--;
            gbox--;
            gbox--;
            gbox--;



            Console.WriteLine();

            Console.WriteLine("Customer Steps in Food Order:");

            Flow order = FoodOrder.CustomerCall;

            Step[] customerSteps = order.GetStepsOfType(typeof(HungryCustomer));

            foreach (Step s in customerSteps)
            {
                Console.WriteLine("\t"+ s.Name);
            }


            Flow DynamicFlow = new Flow();

            Step f = DynamicFlow.Add("B1", 20);
            f.Value = "This is bad";
            f=DynamicFlow.Add("B2", 30);
            f=DynamicFlow.Add("B3", 40);
            f=DynamicFlow.Add("B4", 50);
            f=DynamicFlow.Add("F1", 80);
            f=DynamicFlow.Add("F2", 90);
            f.Value = 90;

            Console.WriteLine(DynamicFlow);
            DynamicFlow.StepLast();
            Console.WriteLine(DynamicFlow);

            Flow df = DynamicFlow.CurrentStep;

            Console.WriteLine(df);

        }

        static void gbox_StepChanged(object sender, StepEventArgs e)
        {
            Console.WriteLine("\t"+ e.StepAction);

        }

    }
}
