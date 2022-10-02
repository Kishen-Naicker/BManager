using System;
using System.Globalization;
using System.Windows.Controls;

namespace BudgetManager.Validator
{
    public class InputValidator : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            double number = 0;
            try
            {
                number = Convert.ToDouble(value.ToString());
            }
            catch (Exception)
            {
                return new ValidationResult(false, "Value must be numeric");
            }
            //if (number == 0)
            //{
            //    return new ValidationResult(false, "Value must be non-zero");
            //}
            return new ValidationResult(true, null);
        }
    }
}
