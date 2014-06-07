using PayRollSystem.Data;
using PayRollSystem.Model;

namespace PayRollSystem.Logic
{
    public interface Transaction
    {
        void Execute();
    }

    public class AddSalariedEmployee : AddEmployeeTransaction
    {
        private readonly double salary;

        public AddSalariedEmployee(int empId, string name, string address, double salary) 
            : base(empId, name, address)
        {
            this.salary = salary;
        }

        protected override PaymentClassification MakeClassification()
        {
            return new SalariedClassification(salary);
        }

        protected override PaymentSchedule MakeSchedule()
        {
            return new MonthlySchedule();
        }
    }

    public abstract class AddEmployeeTransaction : Transaction
    {
        private readonly int empId;
        private readonly string name;
        private readonly string address;

        public AddEmployeeTransaction(int empId, string name, string address)
        {
            this.empId = empId;
            this.name = name;
            this.address = address;
        }

        protected abstract PaymentClassification MakeClassification();
        protected abstract PaymentSchedule MakeSchedule();

        public void Execute()
        {
            var pc = MakeClassification();
            var ps = MakeSchedule();
            var pm = new HoldMethod();

            var e = new Employee(empId, name, address) {Classification = pc, Schedule = ps, Method = pm};
            PayrollDatabase.AddEmployee(empId, e);
        }
    }
}
