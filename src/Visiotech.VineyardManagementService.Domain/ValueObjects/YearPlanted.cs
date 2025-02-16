namespace Visiotech.VineyardManagementService.Domain.ValueObjects
{
    public sealed record YearPlanted
    {
        public YearPlanted(int value)
        {
            if (!ValidateYear(value))
                throw new ArgumentException(
                    "Invalid year. Year mast be between 1900 and {currentYear}.", 
                    DateTime.UtcNow.Year.ToString());

            Value = value;
        }

        public int Value { get; private set; }

        private static bool ValidateYear(int year)
        {
            int currentYear = DateTime.UtcNow.Year;
            return year < 1900 || year > currentYear;
        }
    }
}
