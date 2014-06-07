namespace PayRollSystem.Model
{
    public class PaymentClassification
    {
    }

    public class SalariedClassification : PaymentClassification
    {
        public SalariedClassification(double salary)
        {
            Salary = salary;
        }

        public double Salary { get; private set; }
    }
}
