using System.Collections.Generic;
using System.Linq;

namespace BudgetManager.Expenses
{
    public class GeneralExpenses : Expense
    {
        public double groceries { get; set; }
        public double waterLights { get; set; }
        public double travel { get; set; }
        public double cellular { get; set; }
        public double otherExpense { get; set; }

        private List<double> generalExpenses = new List<double>();

        public GeneralExpenses(double Groceries, double WaterLights, double Travel, double Cellular, double OtherExpense)
        {
            this.groceries = Groceries;
            this.waterLights = WaterLights;
            this.travel = Travel;
            this.cellular = Cellular;
            this.otherExpense = OtherExpense;
        }

        public override double costCalculation()
        {
            generalExpenses.Add(groceries);
            generalExpenses.Add(waterLights);
            generalExpenses.Add(travel);
            generalExpenses.Add(cellular);
            generalExpenses.Add(otherExpense);

            return generalExpenses.Sum();
        }
    }
}
