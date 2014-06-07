using FluentAssertions;
using NUnit.Framework;
using PayRollSystem.Data;
using PayRollSystem.Logic;
using PayRollSystem.Model;

namespace PayRollSystem.Tests
{
    class AddSalariedEmployeeTests
    {
        [Test]
        public void ShouldStoreEmployeeWithValidValues()
        {
            const int empId = 1;
            var t = new AddSalariedEmployee(empId, "Juan", "Address", 1000.00);
            t.Execute();

            var employee = PayrollDatabase.GetEmployee(empId);
            employee.Name.Should().Be("Juan");

            var pc = employee.Classification;
            pc.Should().BeOfType<SalariedClassification>();
            var spc = pc as SalariedClassification;
            spc.Salary.Should().Be(1000.00);

            var ps = employee.Schedule;
            ps.Should().BeOfType<MonthlySchedule>();

            var pm = employee.Method;
            pm.Should().BeOfType<HoldMethod>();
        }
    }
}
