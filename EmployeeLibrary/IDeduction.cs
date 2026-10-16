namespace EmployeeLibrary
{
    public interface IDeduction
    {
        decimal IncomeTax();
        decimal Pension();
        decimal UnionDues();
        decimal Insurance();
    }
}

