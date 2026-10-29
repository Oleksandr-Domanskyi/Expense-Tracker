using expense_tracker.Models;

namespace expense_tracker.Services;

public class UserExpenseServices(UserExpenseEntity userExpense)
{
    public UserExpenseEntity UserExpense { get; } = userExpense;

    public void GlobalExpense()
       => System.Console.WriteLine(String.Join("", UserExpense.userExpenses.Select(u => $"ID; {u.id}, Description: {u.Description}, Amount: {u.Amount}, Date: {u.Date}, \n")));

    public void AddExpense(string Description, int Amount) => UserExpense.CreateUserExpense(Description, Amount);
    public void DeleteExpense(int Id) => UserExpense.DeleteUserExpense(Id);
    public void TotalExpenses() => UserExpense.Total();



}
