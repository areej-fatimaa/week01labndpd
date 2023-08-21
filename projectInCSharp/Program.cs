using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace projectInCSharp
{
    class Program
    {
        const int userarrsize = 100;                                                           // costant array size
        static String[] users = new string[userarrsize]; // array for storing users of application
        static String[] password = new string[userarrsize];       // array for storing users password
        static String[] roles = new string[userarrsize];    // array for storing users roles                                                         
        static int usercount = 0;                                                                     // it will take a count users
        static int[] medicinestock = new int[userarrsize];                                                      // store the info of stock available in store
        static int[] medicineprice = new int[userarrsize];                                                     // store the medicines prices in store
        static String[] medicinename = new string[userarrsize];                                                      // store medicines names
        static int medicinecount = 0;                                                                 // take a count of medicines in store
        static void Main(string[] args)
        {
           ReadUsersfromFile();
            ReadInventoryDetailsFromFile();
            int checkADMS=0;    // will check options entered by admins
            int checkCMS=0;     // will check options entered by customer
            string checkrole; // will check role of users
            int choice = 0;       // will check login choices from login menu
            while (choice != 3) // loop for login
            {
                choice = LoginView();
                if (choice == 1) // choice 1 is for admin
                {
                    Console.Clear();
                    checkrole = SignIN();
                    if (checkrole == "admin" || checkrole == "Admin")
                    {
                        while (checkADMS != 5) // loop for checking admin options
                        {
                            Console.Clear();
                            checkADMS = AdminMainScreen();
                            if (checkADMS == 1)
                            {
                                Console.Clear();
                                CheckList();
                            }
                            else if (checkADMS == 2)
                            {
                                Console.Clear();
                                UpdateList();
                            }
                            else if (checkADMS == 3)
                            {
                                Console.Clear();
                                DeleteItems();
                            }

                            else if (checkADMS == 4)
                            {
                                Console.Clear();
                                CreateList();
                            }
                            Console.ReadKey();
                        }
                    }
                    else if (checkrole == "customer" || checkrole == "Customer")
                    {
                        checkCMS = 0;
                        while (checkCMS != 2) // loop for checking customer option
                        {
                            checkCMS = CustomerMainScreen();
                            if (checkCMS == 1)
                            {
                                Console.Clear();
                                ShowList();
                            }
                        }
                    }
                    else if(checkrole=="Nothing")
                    {
                        Console.WriteLine("You entered wrong informatin!!");
                    }
                }

                else if (choice == 2) // choice 2 is for signup
                {
                    bool isvalid = SignUP();
                    if (isvalid)
                    {

                        Console.WriteLine("SignedUp Successfully!");
                    }
                    if (isvalid== false)
                    {
                        Console.WriteLine("Try Again");
                    }
                }
                else if (choice == 3)
                {
                    Console.WriteLine("Wrong Input!");
                }
                Console.ReadKey();
                Console.Clear();
            }
        }
        static int LoginView()
        {
            Console.Clear();
        
        
            Console.WriteLine("Enter Choice");
            Console.WriteLine("1.sign in");
            Console.WriteLine("2.sign up");
            Console.WriteLine("Enter key: ");
            while (true)
            {
                string choice=  Console.ReadLine();
                int convertedChoice = Convert.ToInt32(choice);
                if (convertedChoice <= 2)
                {
                    return convertedChoice;
                }
                else
                {
                    Console.WriteLine("You entered an invalid input");
                }
            }

        }
        static string SignIN()
        {
            Console.WriteLine("Enter your name: ");
            string username = Console.ReadLine();    // will store name entered by user
            Console.WriteLine("Enter your password: ");
            string userpassword = Console.ReadLine();   // will store password entered by user
            string checkUser = CheckUsersInArray(username, userpassword);  // will check presence of user

            return checkUser;
        }
        static String CheckUsersInArray(string username, string userpassword)
        {
            int count = 0;
            int idx = 0;
            for (int i = 0; i < usercount; i++) // loop for identifying users
            {
                if (users[i] == username && password[i] == userpassword)
                {
                    //Console.ReadKey();
                    count++;
                    idx = i;
                    break;
                }
            }
            if(count>0)
            {
                return roles[idx];
            }
            else
            {
                return "Nothing";
            }

        }
        static Boolean SignUP()
        {
            string userName;
            int count = 0;
            bool isValiduserName;
               // to store role entered by user
            while (true)
            {
                Console.WriteLine("Enter name");
               userName = Console.ReadLine();  // to store name entered by user
                isValiduserName = ValidUserName(userName);

                if (isValiduserName)
                {
                    users[usercount] = userName; // will store username in array of users
                    count++;
                    break;
                }
            }
                Console.WriteLine("Enter Password");
                string userpassword= Console.ReadLine();  // to store password enteres by user
                password[usercount] = userpassword; // will store users password in aary of password
                Console.WriteLine("Enter role");
            string userrole= Console.ReadLine();
                
                    roles[usercount] = userrole; // will store roles  of users in array of roles
                 
            if (count == 1)
            {
                usercount++;
                StoreInFileUsers(userName, userpassword, userrole);
                return true;
            }
            else
            {
                return false;
            }

        }
        static Boolean ValidUserName(string userName)
        {
            bool ispresent = true;
            for (int i = 0; i < usercount; i++) // loop for checking presence of user
            {
                if (users[i] == userName)
                {
                    ispresent = false;
                    break;
                }
            }
            if (ispresent == false)
            {
                Console.WriteLine("user already present");
                return ispresent;
            }
            return ispresent;

        }
        static int AdminMainScreen()
        {
            int convertedKey;
            Console.WriteLine("**************Admin Main Screen******************");
            Console.WriteLine("1.Check list");
            Console.WriteLine("2.Update list");
            Console.WriteLine("3.Delete items");
            Console.WriteLine("4.Create list");
            Console.WriteLine(" Enter Choice");
            string  key= Console.ReadLine();
            convertedKey = Convert.ToInt32(key);
            return convertedKey;
            
        }
        static int CustomerMainScreen()
        {
            Console.WriteLine("***************CUSTOMER MAIN SCREEN**************");
            Console.WriteLine("1.Show List ");
            Console.WriteLine(" Enter Choice");
            string key = Console.ReadLine();
           int  convertedKey = Convert.ToInt32(key);
            return convertedKey;
        }
        static void ReadUsersfromFile()
        {
            string path = "D:\\oopweek01lab\\week01labndpd\\projectInCSharp\\users.txt";

            int x = 0;
            if (File.Exists(path))
            {
                StreamReader fileVariable = new StreamReader(path);
                string record;
                while ((record = fileVariable.ReadLine()) != null)
                {
                    users[x] = ParseData(record, 1);
                    password[x] = ParseData(record, 2);
                    roles[x] = ParseData(record, 3);
                    x++;
                    if (x > userarrsize)
                    {
                        break;
                    }
                }
                usercount = x;
                fileVariable.Close();
            }
            else
            {
                Console.WriteLine("Not Exists");
            }
        } 
        static string ParseData(string record, int feild)
        {
            int comma = 1;
            string item = "";
            for(int x=0;x<record.Length;x++)
            {
                if(record[x]==',')
                {
                    comma++;
                }
                else if(comma==feild)
                {
                    item = item + record[x];
                }
            }
            return item;
        }
        static void StoreInFileUsers(string userName,string userpassword,string userrole)
        {
            string path = "D:\\oopweek01lab\\week01labndpd\\projectInCSharp\\users.txt";
            StreamWriter file = new StreamWriter(path, true);
            file.WriteLine(userName + "," + userpassword + "," + userrole);
            file.Flush();
            file.Close();
        }
        static void CheckList()
        {
            Console.WriteLine("*****************LIST*******************");
            Console.WriteLine("\tMEDICINE NAME\t\tPRICE\t\t<<STOCK");

            for (int i = 0; i < medicinecount; i++) // loop tp print medicie names quantity and stock
            {
                Console.WriteLine("\t\t" + medicinename[i] + "\t\t" + medicineprice[i] + "\t\t"+  medicinestock[i]);
            }
        }
        static void UpdateList()
        {
            Console.WriteLine("********************UPDATE MENUE********************");
            bool ispresent;
            Console.WriteLine("enter medicine name");
            string mName= Console.ReadLine(); // to store name of medicine admin want to update in list

            ispresent = CheckMedicineInArray(mName);
            if (ispresent)
            {
                Console.WriteLine("Enter medicine price: ");
                string mPrice = Console.ReadLine();  // to store price of medicine admin want to update in list
                int convertedPrice = Convert.ToInt32(mPrice);

                Console.WriteLine("Enter stock you want to enter: ");
                string mStock = Console.ReadLine();// to store stock of medicine stock admin want to update in list
                int convertedStock = Convert.ToInt32(mStock);
         
                    medicinename[medicinecount] = mName; // will store new medicine name in list
                    medicineprice[medicinecount] = convertedPrice; // will store price of new medicine
                    medicinestock[medicinecount] = convertedStock; // will store stock of new medicine
                    medicinecount++;
                StoreInventoryInFileUpdate();
            }
        }
        static Boolean CheckMedicineInArray(string mName)
        {
            bool flag = true;
            for (int i = 0; i < medicinecount; i++)
            {
                if (medicinename[i] == mName)
                {
                    flag = false;
                    Console.WriteLine("Already Present");
                }
            }
            return flag;
        }
        static void DeleteItems()
        {
            Console.WriteLine("**************************DELETE ITEMS********************");
            int index = 0;
            index = CheckinArraytoDeleteitem();
            if (index != -1)
            {
                for (int i = index; i < medicinecount; i++) // loop to delete item and store other itens at that place
                {
                    medicinename[i] = medicinename[i + 1];
                    medicineprice[i] = medicineprice[i + 1];
                    medicinestock[i] = medicinestock[i + 1];
                }
                medicinecount--;
                StoreInventoryInFileUpdate();
            }
            else
            {
                Console.WriteLine("You entered wrong medicine name!");
            }
        }
        static int CheckinArraytoDeleteitem()
        {
            Console.WriteLine("enter medicine name you want to delete:");
            string mName=Console.ReadLine();// to store name of medicine admin wants to delete
            int index = -1;                         // to store array index where medicine name is found
            for (int i = 0; i < medicinecount; i++) // loop to check presence of medicine
            {
                if (medicinename[i] == mName)
                {
                    index = i;
                    Console.WriteLine("press any key to confirm deletion!!");
                    Console.ReadKey();
                }
            }
            return index;
        }
        static void CreateList()
        {
            Console.WriteLine("Enter number of items you want to add: ");
            string noOfItems= Console.ReadLine();
            int convertedNoOfItems = Convert.ToInt32(noOfItems);

                for (int i = 0; i < convertedNoOfItems; i++)
                {
                Console.WriteLine("Enter name of medicine: ");
                string mName= Console.ReadLine();
                    // check validation
                   bool ispresent = CheckMedicineInArray(mName);
                    if (ispresent)
                    {
                       
                        Console.WriteLine("Enter price of medicine: ");
                        string mPrice= Console.ReadLine();
                        int convertedPrice = Convert.ToInt32(mPrice);
                        
                        Console.WriteLine("Enter stock you want to enter: ");
                        string mStock = Console.ReadLine();
                        int convertedStock = Convert.ToInt32(mStock);
                        
                        // to store medicines in array
                            medicinename[medicinecount] = mName;
                            medicineprice[medicinecount] = convertedPrice;
                            medicinestock[medicinecount] = convertedStock;
                            medicinecount++;
                    StoreInventoryInFile(mName, convertedPrice, convertedStock);
                    }
                }
        }
        static void ShowList() // will show list to customer
        {
            Console.WriteLine("***********************LIST OF MEDICINES*********************");
            Console.WriteLine("\t\tMedicine Name\t\tPrice\t\t");
            for (int i = 0; i < medicinecount; i++)
            {
                Console.WriteLine("\t\t" + medicinename[i] + "\t\t" + medicineprice[i]);
            }
        }
        static void ReadInventoryDetailsFromFile()
        {

            string path = "D:\\oopweek01lab\\week01labndpd\\projectInCSharp\\inventoryDetails.txt";

            int x = 0;
            if (File.Exists(path))
            {
                StreamReader fileVariable = new StreamReader(path);

                string record;
                while ((record = fileVariable.ReadLine()) != null)
                {
                    medicinename[x] = ParseData(record, 1);
                    medicineprice[x] = Convert.ToInt32(ParseData(record, 2));
                    medicinestock[x] = Convert.ToInt32(ParseData(record, 3));
                    x++;
                    if (x > userarrsize)
                    {
                        break;
                    }
                }
                medicinecount = x;
                fileVariable.Close();
            }
            else
            {
                Console.WriteLine("Not Exists");
            }
        }
        static void StoreInventoryInFile(string medicinename,int medicineprice,int medicinestock)
        {
            string path = "D:\\oopweek01lab\\week01labndpd\\projectInCSharp\\inventoryDetails.txt";
            StreamWriter file = new StreamWriter(path, true);
            file.WriteLine(medicinename + "," + medicineprice + "," + medicinestock);
            file.Flush();
            file.Close();

        }
        static void StoreInventoryInFileUpdate()
        {
            string path = "D:\\oopweek01lab\\week01labndpd\\projectInCSharp\\inventoryDetails.txt";
            StreamWriter file = new StreamWriter(path);
            for(int i =0; i<medicinecount;i++)
            {
            file.WriteLine(medicinename[i] + "," + medicineprice[i] + "," + medicinestock[i]);
            }
            file.Flush();
            file.Close();

        }
    }
}
