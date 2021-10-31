using FinalProjectCopy.Helper;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;


namespace FinalProject.Models
{
    public class Pharmacy
    {
        public string Name { get; }
        private List<Drug> drugs { get; }
        public int ID { get; }
        private static int _counter;

        public Pharmacy(string name)
        {
            drugs = new List<Drug>();
            Name = name;
            _counter++;
            ID = _counter;
        }
        public override string ToString()
        {
            return $"ID: {ID}  Name: {Name}";
        }
        public void AddDrug(Drug drug)
        {
            if (drug.Name.TrimEnd(' ').Length > 0 && drug.Price >= 0 && drug.Count >= 0 && drug.Type != null)
            {
                drugs.Add(drug);
            }
        }

        public bool InfoDrug(string name, string error)
        {
            var infolist = drugs.Find(x => x.Name == name);
            if (infolist.Count == 0)
                Helper.Print(error, ConsoleColor.Red);

            Console.WriteLine(infolist);

            return true;
        }
        public void ShowDrugItems(string error)
        {
            if (drugs.Count == 0)
            {
                Helper.Print(error, ConsoleColor.Red);
                return;
            }
            else
            {
                foreach (var item in drugs)
                {
                    Helper.Print(item.ToString(), ConsoleColor.Green);
                }
            }

        }

        public void SaleDrug(string name, int count, double price, string ErorName, string ErorCount, string ErorPrice, string report,
            string endprice, string end)
        {
            var infolist = drugs.Find(x => x.Name == name);
            double TotalPrice = infolist.Price * count;
            if (infolist == null)
            {
                Helper.Print(ErorName, ConsoleColor.Green);

            }
            else if (infolist.Count < count)
            {
                Helper.Print(ErorCount, ConsoleColor.Green);

            }
            else if (TotalPrice > price)
            {
                Helper.Print(ErorPrice, ConsoleColor.Green);

            }
            else
            {
                Console.WriteLine(infolist);
                double EndCount = infolist.Count - count;
                double EndPrice = price - (infolist.Price * count);
                Helper.Print(report, ConsoleColor.Green);
                Helper.Print($"Product: {infolist.Name}  Count: {count}  Price: {infolist.Price}  Total price: {TotalPrice}", ConsoleColor.Gray);
                Helper.Print(endprice + $": {price - infolist.Price}", ConsoleColor.Gray);
                Console.WriteLine(DateTime.Now);
                Helper.Print(end, ConsoleColor.DarkCyan);
                return;
            }
        }

        public void UpdateDrugCount(string drug, int newcount, string erors)
        {
            var infolist = drugs.Find(x => x.Name == drug);
            if (infolist == null)
            {
                Helper.Print(erors, ConsoleColor.Red);
                return;
            }

            infolist.Count = newcount;
        }

        public void UpdateDrugPrice(string drug, double newprice, string erors)
        {
            var infolist = drugs.Find(x => x.Name == drug);
            if (infolist == null)
            {
                Helper.Print(erors, ConsoleColor.Red);
                return;
            }


            infolist.Price = newprice;
        }
    }
}
