
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.DAO
{
    public class Dao
    {
        public Dao() { }
        private readonly context _context;

        public Dao(context context)
        {
            _context = context;
        }

        public virtual Employee GetFirstEmployee10Y()
        {
            var employe = _context.Employee?.FirstOrDefault(e => e.Age == 10);
            if (employe != null)
                return employe;
            else return new Employee();
        }
        public Employee AddEmployee(string name, string firstname)
        {
            var newEmp = _context.Employee.Add(new Employee { Nom = name, Prenom= firstname});
            _context.SaveChanges();
            return newEmp;
        }

        public bool UpdateEmployee(string nom, string nouveauNom)
        {
            var updateEmp = _context.Employee?.FirstOrDefault(e => e.Nom == nom);
            if (updateEmp != null)
            {
                updateEmp.Nom = nouveauNom;
                _context.SaveChanges();
                return true;
            }
            return false;
        }
    }
}

