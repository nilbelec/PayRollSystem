namespace PayRollSystem.Model
{
    public class Employee
    {
        public Employee(int empId, string name, string address)
        {
            EmpId = empId;
            Name = name;
            Address = address;
        }

        public string Address { get; private set; }

        public int EmpId { get; private set; }

        public string Name { get; private set; }
        public PaymentClassification Classification { get; set; }
        public PaymentSchedule Schedule { get; set; }
        public PaymentMethod Method { get; set; }
    }
}
