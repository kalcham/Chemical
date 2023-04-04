//imports
using System;
using System.Threading;
namespace Chemical
{
    class Program
    {
        // global variables
        static string MostChemical = "";
        static string LeastChemical = "";
        static float MostEfficiency = -1;
        static float LeastEfficiency = 5001;
        // methods

        static void OneChemical()
        {
            //Enter and store chemicals that being test
            Console.WriteLine("Enter the Chemical name:\n");
            string chemicalName = Console.ReadLine();

            float sumEfficiency = 0;

            for (int i = 0; i < 5; i++)
            {
                //generated a randomly number of initial live germs
                Random rangerm = new Random();
                int ranGermsNum = rangerm.Next(5000, 10000);
                //inform in between the chemcial and measured the germs
                Console.WriteLine("wait 2sec and then we will remeasured the germs\n");

                Thread.Sleep(2000);

                //display the number of germs
                Console.WriteLine($"The number of germs are {ranGermsNum}");

                //After an amount of time. the number of live germs is again measured
                Random rannum = new Random();
                int ranGerms = rannum.Next(0, ranGermsNum);

                //determine the efficiency of the chemical

                float efficiency = (float)(ranGermsNum - ranGerms) / 2;

                Console.WriteLine($"Number of germs left: {ranGerms}");

                sumEfficiency += efficiency;

            }

            //calculate final efficiency

            float finalEfficiency = sumEfficiency / 5;

            //display the chemical and the final efficiency
            Console.WriteLine($"Chemical {chemicalName} has an efficiency rating of {finalEfficiency}");

            if (finalEfficiency > MostEfficiency)
            {
                MostEfficiency = finalEfficiency;
                MostChemical = chemicalName;
            }
            if (finalEfficiency < LeastEfficiency)
            {
                LeastEfficiency = finalEfficiency;
                LeastChemical = chemicalName;
            }

        }

        //main process
        static void Main(string[] args)
        {
            //loop until user types 'stop'
            string flagmain = "";
            while (!flagmain.Equals("XXX")) 
            {
                //call OneChemicals()
                OneChemical();

                Console.WriteLine("Press < ENTER > to add another or type 'XXX' to quit\n");
                flagmain = Console.ReadLine();
            }
            //display the Most and Least efficiency chemicals
            Console.WriteLine($"The Most Efficiency Chemicals is call {MostChemical} the Efficiency of the chemical was {MostEfficiency}\n" +
                $"The least Efficiency Chemicals is call {LeastChemical} the Efficiency of the chemical was {LeastEfficiency}");
        }
    }
}

