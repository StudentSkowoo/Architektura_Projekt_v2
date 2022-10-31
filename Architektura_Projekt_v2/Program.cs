using System.Data;
using System.Security.Cryptography;

namespace Architektura_Projekt_v2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Defining bytes array
            byte[] registers = new byte[8];
            string[] registerNames = { "AL", "AH", "BL", "BH", "CL", "CH", "DL", "DH" };

            //Prompt user for input:

            for (int j = 0; j < registers.Length; j++)
            {
                Console.WriteLine("Type in value of register " + registerNames[j]);
                try
                {
                    registers[j] = Byte.Parse(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("Value is not suitable for byte. Try again!");
                    j--;
                }
            }

            //Print out initial state

            Console.WriteLine("Initial state of registers is: ");
            for (int i = 0; i < registers.Length; i++)
            {
                Console.WriteLine(registerNames[i] + " is: " + registers[i]);
            }


            do //Working loop
            {
                //Prompt user for commands

                string commandString; //String value of command
                int command; //Int value for command - 0 = MOV, 1 = XCHG

                Console.WriteLine("Choose your command: (MOV or XCHG):");
                do
                {
                    commandString = Console.ReadLine().ToUpper();

                    if (commandString == "MOV")
                    {
                        command = 0;
                        break;
                    }
                    else if (commandString == "XCHG")
                    {
                        command = 1;
                        break;
                    }
                }
                while (true);

                //Prompt user to choose the register

                string sourceName; //Name of source register
                int source = -1; //Number of source register

                do //Prompt for source register name
                {
                    Console.WriteLine("Select source register:");

                    sourceName = Console.ReadLine().ToUpper();

                    for (int k = 0; k < registerNames.Length; k++) //Check if name comply with register name table
                    {
                        if (sourceName == registerNames[k]) //If sourceName is same as one if registers
                        {
                            source = k;
                        }
                    }

                    if (source >= 0 & source <= 7) // if TRUE, then assign the number and break the loop
                    {
                        break;
                    }
                }
                while (true);

                string targetName; //Name of target register
                int target = -1; //Number of target register

                do //Prompt user for target register
                {
                    Console.WriteLine("Choose target register:");

                    targetName = Console.ReadLine().ToUpper();

                    for (int l = 0; l < registerNames.Length; l++) //Check if name comply with register name table
                    {
                        if (targetName == registerNames[l]) //If targetName is same as one if registers
                        {
                            target = l;
                        }
                    }

                    if (target >= 0 & target <= 7) // if TRUE, then assign the number and break the loop
                    {
                        break;
                    }
                }
                while (true);

                // Operation


                //If command == 0 (MOV)
                if (command == 0)
                {
                    registers[target] = registers[source];
                }


                //If command == 1 (XCHG)
                byte temp; // temporary byte to store the data

                if (command == 1)
                {
                    temp = registers[target];
                    registers[target] = registers[source];
                    registers[source] = temp;
                }

                //Print output
                Console.WriteLine("Chosen command was " + commandString + " (" + command + "). Choosen register was: Source: " + registerNames[source] + " Target: " + registerNames[target]);
                for (int a = 0; a < registers.Length; a++)
                {
                    Console.WriteLine(registerNames[a] + " is: " + registers[a]);
                }

                //Ask for next operation:
                do
                {
                    Console.WriteLine("Do you want to continue the simulation?");
                    string cont = Console.ReadLine().ToUpper();

                    if (cont == "N" | cont == "NO") // Kill the program if N or NO
                    {
                        return;
                    }
                    else if (cont == "Y" | cont == "YES") // Repeat if Y or YES
                    {
                        break;
                    }
                }
                while (true);
            }
            while (true);        
        }
    }
}