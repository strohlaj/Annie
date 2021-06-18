
using System;

namespace Business.Entities
{
    public record Age(DateTime DateOfBirth, bool IsCurrentlyPremature = false)
    {
        public bool Is0To3MonthsOfAge => DateTime.Today < DateOfBirth.AddMonths(3) ;
        public bool Is3To6MonthsOfAge => DateTime.Today > DateOfBirth.AddMonths(3) && DateTime.Today < DateOfBirth.AddMonths(6);
        public bool Is6To12MonthsOfAge => DateTime.Today > DateOfBirth.AddMonths(6) && DateTime.Today < DateOfBirth.AddMonths(12);
        public bool Is1To3YearsOfAge => DateTime.Today > DateOfBirth.AddYears(1) && DateTime.Today < DateOfBirth.AddYears(3);
        public bool Is3To6YearsOfAge => DateTime.Today > DateOfBirth.AddYears(3) && DateTime.Today < DateOfBirth.AddYears(6);
        public bool Is6To12YearsOfAge => DateTime.Today > DateOfBirth.AddYears(6) && DateTime.Today < DateOfBirth.AddYears(12);
        public bool IsGreaterThan12YearsOfAge => DateTime.Today > DateOfBirth.AddYears(12);

    }
}
