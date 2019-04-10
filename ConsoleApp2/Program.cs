using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp2.DAO;

namespace ConsoleApp2
{
    public static class Program
    {
        static void Main(string[] args)
        {
            {
                var dao = new Dao(new context());
                var employe = dao.GetFirstEmployee10Y();
                Console.WriteLine(employe.Nom);
                var newEmployee = dao.AddEmployee("Smith", "John");
                Console.WriteLine("Bienvenue à " + newEmployee.Prenom + " dans la compagnie!");
            }
        }
    }
}
