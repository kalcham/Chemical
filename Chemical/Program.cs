//imports
using System;
using System.Threading;
namespace ChemicalApp
{
    class Program
    {
        // global variables
        static string MostChemical = "";
        static string LeastChemical = "";
        static float MostEfficiency = -1;
        static float LeastEfficiency = 5001;
        // methods




        static string CheckName()
           
        {
            while (true)
            {
                //get name

                Console.WriteLine("Enter the name of the chemical your are going to test:\n");
                string chemicalName = Console.ReadLine();
                

                
                if (!chemicalName.Equals(""))
                {
                    //convert chemical name to capitalised name

                    chemicalName = string.Concat(chemicalName[0].ToString().ToUpper(), chemicalName.Substring(1).ToLower());

                    // displaying the chemical the user put in
                    Console.WriteLine($"You have entered {chemicalName} \n");

                    return chemicalName;


                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;

                    Console.WriteLine("!!!!!!!!!!Error: You must enter a name for the chemical name!!!!!!!!!!");

                    Console.ForegroundColor = ConsoleColor.White;
                }
            }

        }

        static void OneChemical()
        {
            
            //get name

            string chemicalName = CheckName();
            float sumEfficiency = 0;

            Console.WriteLine($"the {chemicalName} will be tested 5 times please wait for the {chemicalName} to be tested \n");

            for (int i = 0; i < 5; i++)
            {
                //generated a randomly number of initial live germs

                Random rangerm = new Random();
                int ranGermsNum = rangerm.Next(5000, 10000);

                //inform in between the chemcial and measured the germs


                //display the number of germs

                Console.WriteLine($"The number of germs are {ranGermsNum}");

                //After an amount of time. the number of live germs is again measured

                Random rannum = new Random();
                int ranGerms = rannum.Next(0, ranGermsNum);

                //determine the efficiency of the chemical

                float efficiency = (float)(ranGermsNum - ranGerms) / 2;

                Console.WriteLine("wait 2 seconds and then we will remeasure the germs");

                Thread.Sleep(2000);

                Console.WriteLine($"Number of germs remaning: {ranGerms}\n");

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
            //display the program Name
            Console.WriteLine(
            @"                                                                                     " + "\n" +
            @"   ██████╗██╗  ██╗███████╗███╗   ███╗██╗ ██████╗ █████╗ ██╗      █████╗ ██████╗ ██████╗" + "\n" +
            @"  ██╔════╝██║  ██║██╔════╝████╗ ████║██║██╔════╝██╔══██╗██║     ██╔══██╗██╔══██╗██╔══██╗" + "\n" +
            @"  ██║     ███████║█████╗  ██╔████╔██║██║██║     ███████║██║     ███████║██████╔╝██████╔╝" + "\n" +
            @"  ██║     ██╔══██║██╔══╝  ██║╚██╔╝██║██║██║     ██╔══██║██║     ██╔══██║██╔═══╝ ██╔═══╝ " + "\n" +
            @"  ╚██████╗██║  ██║███████╗██║ ╚═╝ ██║██║╚██████╗██║  ██║███████╗██║  ██║██║     ██║     " + "\n" +
            @"   ╚═════╝╚═╝  ╚═╝╚══════╝╚═╝     ╚═╝╚═╝ ╚═════╝╚═╝  ╚═╝╚══════╝╚═╝  ╚═╝╚═╝     ╚═╝   " + "\n");

            Console.WriteLine("Chemical app is here to help you test how efficent the selected chemical is against germs. \n");

            //loop until user types 'stop'

            string flagmain = "";
            while (!flagmain.Equals("XXX")) 
            {
                //call OneChemicals()

                OneChemical();


                bool flagCheck = true;
                while (flagCheck)
                {
                    Console.WriteLine("Press < ENTER > to test another chemical or type 'XXX or xxx' to quit\n");
                    flagmain = Console.ReadLine().ToUpper();

                    if (flagmain == "XXX" || flagmain == "")
                    {
                        flagCheck = false;
                    }
                    else 
                    {
                        Console.ForegroundColor = ConsoleColor.Red;

                        Console.WriteLine("Error: Please enter a correct choice ");

                        Console.ForegroundColor = ConsoleColor.White;
                    }

                }
            }
            //display the Most and Least efficiency chemicals

            Console.WriteLine($"The Most Efficient Chemical is {MostChemical} the Efficiency of the chemical was {MostEfficiency}\n" +
                $"The least Efficient Chemical is {LeastChemical} the Efficiency of the chemical was {LeastEfficiency}");
        }
    }
}

