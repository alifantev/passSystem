

using PassSystem.Tools;

namespace PassSystem.Services.EmployeePass
{
    internal static class EmployeePassValidator
    {
        private const int _minLengthPeriodInDays = 1;
        internal static Result<bool> Validate(Domain.EmployeePasses.EmployeePass pass)
        {
            if (pass.ValidTo < pass.ValidAt) return Result<bool>.Failed("Дата окончания меньше даты начала действия пропуска");
            if ((pass.ValidTo - pass.ValidAt).TotalDays < _minLengthPeriodInDays) 
                return Result<bool>.Failed($"Минимальный период действия пропуска {_minLengthPeriodInDays} дней");
            
            return Result<bool>.Success(true);
        }
    }
}
