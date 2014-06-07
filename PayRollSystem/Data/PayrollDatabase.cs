using System.Collections;
using PayRollSystem.Model;

namespace PayRollSystem.Data
{
    public class PayrollDatabase
    {
        private static readonly Hashtable employees = new Hashtable();

        public static void AddEmployee(int id, Employee employee)
        {
            employees[id] = employee;
        }

        public static Employee GetEmployee(int empId)
        {
            return employees[empId] as Employee;
        }
    }
}
