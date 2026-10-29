
using expense_tracker.Models;
using expense_tracker.Services;


var myExpense = new UserExpenseServices(new UserExpenseEntity());
bool isActive = true;

while (isActive)
{
    Console.WriteLine(
        "\nChoose operation: Global, Total, Add Expense, Delete Expense, Exit"
    );

    string? operation = Console.ReadLine()?.Trim();

    switch (operation?.ToLowerInvariant())
    {
        case "global":
            myExpense.GlobalExpense();
            break;

        case "total":
            System.Console.WriteLine("Month number: ");
            if (!int.TryParse(Console.ReadLine(), out int monthNumber) || monthNumber <= 0)
            {
                Console.WriteLine("Invalid amount.");
                break;
            }

            myExpense.TotalExpenses();
            break;

        case "add expense":
            Console.Write("Description: ");
            string? description = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(description))
            {
                Console.WriteLine("Description cannot be empty.");
                break;
            }

            Console.Write("Amount: ");

            if (!int.TryParse(Console.ReadLine(), out int amount)
                || amount <= 0)
            {
                Console.WriteLine("Invalid amount.");
                break;
            }

            myExpense.AddExpense(description, amount);
            break;

        case "delete expense":
            Console.Write("Write Id: ");

            if (!int.TryParse(Console.ReadLine(), out int id) || id <= 0)
            {
                Console.WriteLine("Invalid Id.");
                break;
            }
            myExpense.DeleteExpense(id);
            break;

        case "exit":
            isActive = false;
            break;

        default:
            Console.WriteLine("Unknown operation. Try again.");
            break;
    }
}

Console.WriteLine("Expense Tracker closed.");
