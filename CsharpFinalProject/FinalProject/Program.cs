using FinalProject.Models;
using System;
using System.Collections.Generic;
using System.Threading;

namespace FinalProjectCopy.Models
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            List<Pharmacy> Pharmacys = new List<Pharmacy>();

            Console.WriteLine("Welcome Pharmacy system");
        #region Login access
        LoginAgain:
            Console.WriteLine("Input Login: ");
            string LoginName = Console.ReadLine();

            Console.WriteLine("Input Password:");
            string LoginPass = Console.ReadLine();
            Helper.Helper.Loading("Your data is checked");
            if (!Login(LoginName, LoginPass))
            {
                Console.Clear();
                Helper.Helper.Print("Incorrect input!", ConsoleColor.Red);
                goto LoginAgain;
            }
            Helper.Helper.Print("Login is successful", ConsoleColor.Green);
            Console.Clear();
        #endregion
        proses1:
            foreach (var item in GetProcces())
            {
                Helper.Helper.Print(item, ConsoleColor.DarkCyan);
            }
            Console.WriteLine("Choose the menu: ");
        proses:
            Procces Procces = (Procces)Helper.Helper.TryParse(Console.ReadLine(), "Incorrect input! \nPlease input again ");
            switch (Procces)
            {
                #region AddPharmacy
                case Procces.AddPharmacy:
                    Console.WriteLine("Input Pharmacy name: ");
                    string PharmacyName = Console.ReadLine();
                    var check = Pharmacys.Find(x => x.Name == PharmacyName);
                    if (check!=null)
                    {
                        Helper.Helper.Print("There is a pharmacy of the same name", ConsoleColor.Red);
                        goto case Procces.AddPharmacy;
                    }
                    Pharmacy pharmacy1 = new(PharmacyName);
                    Pharmacys.Add(pharmacy1);
                    Helper.Helper.Loading("Creating new pharmacy");
                    Console.Clear();
                    Helper.Helper.Print($"A new pharmacy called {pharmacy1} was created ", ConsoleColor.Cyan);
                    goto proses1;

                #endregion

                #region AddDrug
                case Procces.AddDrug:
                    if (Pharmacys.Count == 0)
                    {
                        Helper.Helper.Print("Pharmacy not found!", ConsoleColor.Red);
                        goto case Procces.AddPharmacy;
                    }

                    Helper.Helper.Print("Choose the Pharmacy: ", ConsoleColor.Gray);
                    foreach (var item in Pharmacys)
                    {
                        Console.WriteLine(item);
                    }
                    int PharmacyID = Helper.Helper.TryParse(Console.ReadLine(), "Please input correct number");
                    Pharmacy selectPharm = Pharmacys.Find(x => x.ID == PharmacyID);

                    Helper.Helper.Print("Input Drug name: ", ConsoleColor.Gray);
                    string DrugName = Console.ReadLine();

                    
                    Helper.Helper.Print("Input Drug Type: ", ConsoleColor.Gray);
                    DrugType selectDrugType = new(Console.ReadLine());

                    Helper.Helper.Print("Input Drug Price: ", ConsoleColor.Gray);
                    double Price = Helper.Helper.TryParse(Console.ReadLine(), "Incorrect input! \nPlease input again ");

                    Helper.Helper.Print("Input Drug Count: ", ConsoleColor.Gray);
                    int Count = Helper.Helper.TryParse(Console.ReadLine(), "Incorrect input! \nPlease input again ");

                    Drug NewDrug = new(DrugName, selectDrugType, Price, Count);
                    selectPharm.AddDrug(NewDrug);
                    Helper.Helper.Loading("Creating new drug");
                    Console.Clear();
                    Helper.Helper.Print($"A new drug called {DrugName} was created ", ConsoleColor.Cyan);
                    goto proses1;
                #endregion
                #region InfoDrug
                case Procces.InfoDrug:
                    if (Pharmacys.Count == 0)
                    {
                        Helper.Helper.Print("Pharmacy not found!", ConsoleColor.Red);
                        goto case Procces.AddPharmacy;
                    }

                    Helper.Helper.Print("Choose the Pharmacy: ", ConsoleColor.Gray);
                    foreach (var item in Pharmacys)
                    {
                        Console.WriteLine(item);
                    }
                    PharmacyID = Helper.Helper.TryParse(Console.ReadLine(), "Please input correct number");
                    selectPharm = Pharmacys.Find(x => x.ID == PharmacyID);
                    Helper.Helper.Print("Input drug name: ", ConsoleColor.Gray);
                    string findDrug = Console.ReadLine();
                    Helper.Helper.Loading("Creating Info drug");
                    selectPharm.InfoDrug(findDrug, "Not found drug!");
                    goto proses1;
                #endregion
                #region ShowDrugItems
                case Procces.ShowDrugItems:
                    if (Pharmacys.Count == 0)
                    {
                        Helper.Helper.Print("Pharmacy not found!", ConsoleColor.Red);
                        goto case Procces.AddPharmacy;
                    }

                    Helper.Helper.Print("Choose the Pharmacy: ", ConsoleColor.Gray);
                    foreach (var item in Pharmacys)
                    {
                        Console.WriteLine(item);
                    }
                    PharmacyID = Helper.Helper.TryParse(Console.ReadLine(), "Please input correct number");
                    selectPharm = Pharmacys.Find(x => x.ID == PharmacyID);
                    Helper.Helper.Loading("Creating Show drugs");
                    selectPharm.ShowDrugItems("Not found Drugs!");
                    goto proses1;
                #endregion
                #region SaleDrug
                case Procces.SaleDrug:
                    if (Pharmacys.Count == 0)
                    {
                        Helper.Helper.Print("Pharmacy not found!", ConsoleColor.Red);
                        goto case Procces.AddPharmacy;
                    }
                    
                    Helper.Helper.Print("Choose the Pharmacy: ", ConsoleColor.Gray);
                    foreach (var item in Pharmacys)
                    {
                        Console.WriteLine(item);
                    }
                    PharmacyID = Helper.Helper.TryParse(Console.ReadLine(), "Please input correct number");
                    selectPharm = Pharmacys.Find(x => x.ID == PharmacyID);
                    Helper.Helper.Print("Input you want drug name: ", ConsoleColor.Gray);
                    string SaleDrugName = Console.ReadLine();

                    Helper.Helper.Print("Input you want drug cont: ", ConsoleColor.Gray);
                    int SaleDrugCount = Helper.Helper.TryParse(Console.ReadLine(), "Please input correct number");

                    Helper.Helper.Print("Input you want drug price: ", ConsoleColor.Gray);
                    int SaleDrugPrice = Helper.Helper.TryParse(Console.ReadLine(), "Please input correct number");
                    Helper.Helper.Print("Reporting is prepared.. ", ConsoleColor.Green);
                    Console.Clear();
                    selectPharm.SaleDrug(SaleDrugName, SaleDrugCount, SaleDrugPrice, "Not found drug", "Enought drug count", "Enought drug price ",
                        "Sale Reporting", "Residual money", "Please take drugs and check \nThank you ");
                    Helper.Helper.Print("Do you want again? Yes/no", ConsoleColor.Green);
                    string ansewer = Console.ReadLine();
                    if (ansewer.ToLower() == "yes")
                    {
                        Console.Clear();
                        goto proses1;
                    }
                    break;
                #endregion
                #region Update
                case Procces.UpdateDrug:
                    if (Pharmacys.Count == 0)
                    {
                        Helper.Helper.Print("Pharmacy not found!", ConsoleColor.Red);
                        goto case Procces.AddPharmacy;
                    }

                    Helper.Helper.Print("Choose the Pharmacy: ", ConsoleColor.Gray);
                    foreach (var item in Pharmacys)
                    {
                        Console.WriteLine(item);
                    }
                    PharmacyID = Helper.Helper.TryParse(Console.ReadLine(), "Please input correct number");
                    selectPharm = Pharmacys.Find(x => x.ID == PharmacyID);
                    Helper.Helper.Print("Input drug name: ", ConsoleColor.Gray);
                    findDrug = Console.ReadLine();

                    Helper.Helper.Print("Choose the update data: ", ConsoleColor.DarkMagenta);
                    foreach (var item in GetUpdateDrug())
                    {
                        Console.WriteLine(item);
                    }
                    int checking = Helper.Helper.TryParse(Console.ReadLine(), "Incorrect input! \nPlease input again ");
                    if (checking == 1)
                    {
                        Helper.Helper.Print("Input new Price: ", ConsoleColor.Green);
                        double newprice = Helper.Helper.TryParse(Console.ReadLine(), "Please input correct number");
                        selectPharm.UpdateDrugPrice(findDrug, newprice, "Not find drug");
                    }
                    else if (checking == 2)
                    {
                        Helper.Helper.Print("Input new count: ", ConsoleColor.Green);
                        int newcount = Helper.Helper.TryParse(Console.ReadLine(), "Please input correct number");
                        selectPharm.UpdateDrugCount(findDrug, newcount, "Not find drug");
                    }
                    goto proses1;
                #endregion
                #region Exit and default
                case Procces.Exit:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Incorrect input! \nPlease input again ");
                    goto proses;
            }
            #endregion
        }
        static List<string> GetProcces()
        {
            List<string> Procces = new List<string>();
            foreach (var item in Enum.GetValues(typeof(Procces)))
            {
                Procces.Add($"{(int)item} - {item}");
            }
            return Procces;
        }
        static List<string> GetUpdateDrug()
        {
            List<string> UpdateDrug = new List<string>();

            foreach (var item in Enum.GetValues(typeof(UpdateDrug)))
            {
                UpdateDrug.Add($"{(int)item} - {item}");
            }

            return UpdateDrug;
        }
        static bool Login(string username, string password)
        {
            string existUsername = "Admin";
            string existPassword = "Admin123";
            if (username.ToLower().Equals(existUsername.ToLower()) &&
                password.ToLower().Equals(existPassword.ToLower()))
            {
                return true;
            }

            return false;
        }
        enum Procces
        {
            AddPharmacy = 1,
            AddDrug,
            InfoDrug,
            ShowDrugItems,
            SaleDrug,
            UpdateDrug,
            Exit
        }
        enum UpdateDrug
        {
            UpdatePrice = 1,
            UpdateCount

        }
    }
}