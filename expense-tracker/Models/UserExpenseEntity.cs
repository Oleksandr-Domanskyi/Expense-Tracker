using System.ComponentModel.DataAnnotations;
using System.Data;

namespace expense_tracker.Models;

public class UserExpenseEntity
{
    public readonly int id;
    public List<UserExpenseEntity> userExpenses = [];

    public UserExpenseEntity()
    {
    }

    public UserExpenseEntity(int id, DateTime date, string description, decimal amount)
    {
        this.id = id;
        Date = date;
        Description = description;
        Amount = amount;
    }

    public int? Id { get; set; }

    public DateTime? Date { get; set; }

    public string? Description { get; set; }

    public decimal? Amount { get; set; }



    public void CreateUserExpense(string description, decimal amount)
    {
        int Id = userExpenses.Count == 0 ? 1 : userExpenses.Count + 1;
        var userExpense = new UserExpenseEntity(Id, DateTime.UtcNow, description, amount);

        userExpenses.Add(userExpense);

        System.Console.WriteLine($"Expense added successfully (ID: {Id})");

    }

    public void DeleteUserExpense(int id)
    {
        if (!userExpenses.Any(x => x.Id == Id))
            System.Console.WriteLine($"Expense (ID: {id} Not found!)");

        userExpenses.RemoveAt(id);
        UdpateExpenseList();

        System.Console.WriteLine("Expense deleted successfully");
    }

    public void Total(int month = 0)
    {
        decimal? total = 0;
        var Date = DateTime.Now;

        if (month == 0)
        {
            foreach (var expense in userExpenses)
            {
                total += expense.Amount;
            }
            System.Console.WriteLine($"Total expenses: ${total}");
        }
        else
        {
            var filteredUserExpense = userExpenses.Where(x => Date.AddMonths(-1 * month) <= x.Date && x.Date >= Date).ToList();
            foreach (var expense in filteredUserExpense)
            {
                total += expense.Amount;
            }
            System.Console.WriteLine($"Total expenses: ${total}");
        }

    }



    private void UdpateExpenseList()
    {
        for (int i = 0; i < userExpenses.Count; i++)
        {
            userExpenses[i].Id = i + 1;
        }
    }

}

