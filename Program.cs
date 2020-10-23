using ConsoleApp3;
using System;
using System.Dynamic;
using System.IO;
using System.IO.Enumeration;
using System.Linq.Expressions;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Text;


namespace ConsoleApp3
{   
    public class Fileop
    {   /// <summary>
        /// GLobally stores the file location
         /// </summary>
        public static string fileName;

        /// <summary>
        /// user input for file name
        /// </summary>
        /// <returns>returns file location</returns>
        public string Userinput()
        {
            String loc, fullPath, ext;
            Console.WriteLine("Enter The File Name");
            String filename = Console.ReadLine();

            try
            {

                String ufilename = filename;
                loc = Directory.GetCurrentDirectory();              //getcurrentdirectory
                fullPath = Path.Combine(loc, ufilename);            //combine user input filname and directory
                ext = Path.GetExtension(fullPath);

                if ((string.IsNullOrEmpty(ufilename)) || (ext != ".txt"))       //check filename is not empty and ext is not .txt
                {
                    do
                    {

                        Console.WriteLine("Invalid! Input Your Filename");
                        ufilename = Console.ReadLine();
                        loc = Directory.GetCurrentDirectory();
                        fullPath = Path.Combine(loc, ufilename);

                        ext = Path.GetExtension(fullPath);

                        if (ext == ".txt")
                        {
                            break;                                                                          //loop untill the ext=".txt"

                        }

                    } while (string.IsNullOrEmpty(ufilename) || (ext != " "));


                    Fileop.fileName = fullPath;
                    return Fileop.fileName;
                }
                else
                {
                    loc = Directory.GetCurrentDirectory();
                    fullPath = Path.Combine(loc, ufilename);

                    Fileop.fileName = @fullPath;
                    return Fileop.fileName;
                }
            }
            catch
            {
                Console.WriteLine("Error Try Again");
                return "";
            }

        }
        /// <summary>
        /// Creates a file in the given file location
        /// </summary>
        /// <param name="fileName">location of the file</param>
        public void Create(String fileName)
        {
            try
            {
                //   Google return statement. And make this code look cleaner


                if (File.Exists(fileName))
                {
                    Console.WriteLine("Filename Already Exists");
                    return;
                }

                try
                {

                    FileStream fs = File.Create(fileName);                              //file create function 
                    Console.WriteLine("Creating A File...");
                    Console.WriteLine("File Created");
                    Console.WriteLine("Your File Is Created In This Location:" + fileName);

                    fs.Close();
                }
                catch
                {
                    Console.WriteLine("Invalid file Name");
                    fileName = Userinput();

                    if (Fileop.fileName == "")
                    {
                        Console.WriteLine("Error try again");
                    }
                    Create(Fileop.fileName);

                }


            }
            catch
            {
                Console.WriteLine("Error Try Again");

            }
        }
        /// <summary>
        /// Write a file content
        /// </summary>
        /// <param name="fullPath"> location of the file</param>
        public void Write(string fullPath)
        {
            try
            {
                if (File.Exists(fullPath))
                {
                    Console.WriteLine("Enter The Input");
                    string input = Console.ReadLine();

                    using (StreamWriter sw = File.CreateText(fullPath))                 //file write function
                    {
                        sw.WriteLine(input);
                    }

                    Console.WriteLine("Input Completed");

                }
                else
                {
                    Console.WriteLine("File Doesnt Exist\n");

                    Console.WriteLine("Do You Want To Create a File (Y/N)");
                    String NY = Console.ReadLine();
                    if ((NY == "Y") || (NY == "y"))
                    {

                        Fileop.fileName = Userinput();                              //takeing user input and creating the file
                        Create(Fileop.fileName);
                    }
                    else
                        Console.WriteLine("File Not Created");
                }
            }

            catch
            {
                Console.WriteLine("Error Try Again");
            }

        }
        /// <summary>
        /// Append the file
        /// </summary>
        /// <param name="fullPath"> location of the file</param>
        public void Append(String fullPath)
        {
            try
            {
                if (File.Exists(fullPath))
                {
                    Console.WriteLine("Enter The Input To Be Added");
                    string input = Console.ReadLine();

                    using (StreamWriter sw = File.AppendText(fullPath))                         //file append function
                    {
                        sw.WriteLine(input);
                    }

                    Console.WriteLine("Append Completed");

                }
                else
                {
                    Console.WriteLine("File Doesnt Exist");

                    Console.WriteLine("Do You Want To Create A File (Y/N)");
                    String NY = Console.ReadLine();
                    if ((NY == "Y") || (NY == "y"))
                    {

                        Fileop.fileName = Userinput();                                      //taking the user input and creating the file
                        Create(Fileop.fileName);
                    }
                    else
                        Console.WriteLine("File Not Created");


                }

            }
            catch
            {
                Console.WriteLine("Error Try Again");
            }

        }

        /// <summary>
        /// Reading a file
        /// </summary>
        /// <param name="path">Path of the file</param>
        public void Read(String path)
        {
            try
            {


                if (File.Exists(path))
                {
                    using (StreamReader sr = File.OpenText(path))                   //read function
                    {
                        string s = "";
                        Console.WriteLine("\nThe File Contents Are:\n ");
                        while ((s = sr.ReadLine()) != null)
                        {
                            Console.WriteLine(s);
                        }
                    }
                }
                else
                {
                    Console.WriteLine("File Doesnt Exist");
                }
            }
            catch
            {
                Console.WriteLine("Error Try Again");
            }
        }

        /// <summary>
        /// Delete a file from the given location
        /// </summary>
        /// <param name="fileName">Location of the file</param>
        public void Delete(String fileName)
        {
            try
            {

                String path = fileName;
                Console.WriteLine("Are You Sure? Y/N");
                String yn = Console.ReadLine();
                if ((yn == "Y") || (yn == "y"))
                {
                    Console.WriteLine("Deleting File....");
                    File.Delete(path);                                                                 //delete a file
                    Console.WriteLine("Deleted File");
                }
                else
                    Console.WriteLine("File Not Deleted");
            }
            catch
            {
                Console.WriteLine("Error Try Again");
            }

        }
        /// <summary>
        /// clear te content of the file
        /// </summary>
        /// <param name="fileName">location of the file</param>
        public void Clear(String fileName)
        {
            String path = fileName;
            Console.WriteLine("Are You Sure ? Y/N");
            String yn = Console.ReadLine();
            if ((yn == "Y") || (yn == "y"))
            {
                Console.WriteLine("Clearing File....");
                File.WriteAllText(path, string.Empty);
                Console.WriteLine("File Cleared");
            }
            else
                Console.WriteLine("File Not Cleared");

        }
    }
    class Program
    {
        static void Main(string[] args)
        {

            Fileop file = new Fileop();


            int choice;

            while (true)    //loop the menu for fileoperation
            {

                Console.WriteLine("\n********File Operations********\nPress 1 For Create a File \nPress 2 For Input Content To The File\nPress 3 To Append The File\nPress 4 To Read The File\nPress 5 To Clear Content Of The File\nPress 6 For Delete\nPress 9 To Exit\n********Enter Your Choice******\n");               //  Combine these 3 lines in to one
                String c = Console.ReadLine();

                bool parseSuccess = int.TryParse(c, out choice);        //to check for valid choice (int only)
                if (parseSuccess)
                {
                    choice = int.Parse(c);

                }

                Console.WriteLine("Your Choice Is " + choice);
                try
                {


                    switch (choice)                                             //menuoptions
                    {


                        case 1:
                           
                            Fileop.fileName = file.Userinput();
                            if (Fileop.fileName == "")
                            {
                                Console.WriteLine("Error try again");
                            }
                            file.Create(Fileop.fileName);


                            break;
                        case 2:

                            file.Write(Fileop.fileName);
                            break;
                        case 3:
                            file.Append(Fileop.fileName);
                            break;
                        case 4:
                            file.Read(Fileop.fileName);
                            break;
                        case 5:
                            if (File.Exists(Fileop.fileName))
                            {
                                file.Clear(Fileop.fileName);
                            }
                            else
                            {
                                Console.WriteLine("File Doesnt Exist");

                            }

                            break;

                        case 6:

                            if (File.Exists(Fileop.fileName))
                            {
                                file.Delete(Fileop.fileName);
                            }
                            else
                            {
                                Console.WriteLine("File Doesnt Exist");

                            }

                            break;

                        case 9:
                            Environment.Exit(0);                                            //exit(0)
                            break;
                        default:
                            Console.WriteLine("Invalid Choice");
                            break;

                    }


                }

                catch (Exception e)
                {
                    Console.WriteLine("Invalid Choice");
                    Console.WriteLine(e);


                }



            }
        }

    }
}
