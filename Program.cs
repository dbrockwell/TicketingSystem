using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace tickets
{
    class Program
    {
        static void Main(string[] args)
        {
            string file = "tickets.csv";
            string choiceMain;
            do 
            {
                Console.WriteLine("1) Read ticket information");
                Console.WriteLine("2) Add ticket infomation");
                Console.WriteLine("Enter any other key to exit");
                choiceMain = Console.ReadLine();

                if(choiceMain == "1")
                {
                    if(File.Exists(file))
                    {
                        StreamReader ticketRead = new StreamReader(file);
                        while (!ticketRead.EndOfStream)
                        {
                            Console.WriteLine(ticketRead.ReadLine());
                        }
                    }
                    else
                    {
                        Console.WriteLine("Ticket file does not exist");
                    }
                }

                else if (choiceMain == "2")
                {
                    StreamWriter ticketWrite = new StreamWriter(file);
                    for (int i = 0; i < 10; i++)
                    {
                        Console.WriteLine("Enter ticket information (Y/N)?");
                        string ticketEntryChoice = Console.ReadLine().ToUpper();
                        if (ticketEntryChoice != "Y") {break;}
                        Console.WriteLine("Enter Ticket ID");
                        String ticketID = Console.ReadLine();
                        Console.WriteLine("Enter Ticket Summary");
                        String summary = Console.ReadLine();
                        Console.WriteLine("Enter Ticket Status");
                        String status = Console.ReadLine();
                        Console.WriteLine("Enter Ticket Priority");
                        String priority = Console.ReadLine();
                        Console.WriteLine("Enter the Ticket Submitter");
                        String submitter = Console.ReadLine();
                        Console.WriteLine("Enter Person Assigned");
                        String assigned = Console.ReadLine();
                        List<string> people = new List<string>();
                        string watchChoice;
                        do
                        {
                            Console.WriteLine("Enter person watching (Y/N)?");
                            watchChoice = Console.ReadLine().ToUpper();
                            if (watchChoice != "Y") {break;}
                            Console.WriteLine("Enter the person that is watching");
                            people.Add(Console.ReadLine());
                        } while (watchChoice == "Y");
                        ticketWrite.Write("{0},{1},{2},{3},{4},{5},", ticketID, summary, status, priority, submitter, assigned);
                        string lastPerson = people.LastOrDefault();
                        foreach(string person in people)
                        {
                            if (person.Equals(lastPerson))
                            {
                                ticketWrite.Write(person + "\n");
                            }
                            else
                            {
                                ticketWrite.Write(person + "|");
                            }
                        }
                    }
                    ticketWrite.Close();
                }
            } while (choiceMain == "1" || choiceMain == "2");
        }
    }
}
