using DebtorsLab3.Models;

namespace DebtorsLab3.Services;

public static class DebtorService
{
    private static List<Debtor> Debtors { get; }

    static DebtorService()
    {
        Debtors = new List<Debtor>
        {
            new()
            {
                id = 0, debt = new Debt() {Currency = "Dollar", Value = 1000, DebtId = 0}, firstName = "Павел",
                isDeath = false,
                lastName = "Кононов", address = new Address() {City = "Minsk", Country = "Belarus", Street = "Main"}
            },
            new()
            {
                id = 1, debt = new Debt() {Currency = "Dollar", Value = 2000, DebtId = 1}, firstName = "Мария",
                isDeath = true, lastName = "Кузьмицкая",
                address = new Address() {City = "Minsk", Country = "Belarus", Street = "Main"}
            }
        };
    }

    public static List<Debtor> GetAll()
    {
        return Debtors;
    }

    public static Debtor? Get(int id)
    {
        return Debtors.FirstOrDefault(f => f.id == id);
    }

    public static void Add(Debtor debtor)
    {
        debtor.id = Debtors.Count;
        debtor.debt.DebtId = Debtors.Count;
        Debtors.Add(debtor);
    }

    public static void Delete(int id)
    {
        var debtor = Get(id);
        if (debtor is null)
            return;

        Debtors.Remove(debtor);
    }

    public static void Update(Debtor debtor, int id)
    {
        var index = Debtors.FindIndex(f => f.id == id);
        if (index == -1)
            return;
        var newDebtor = new Debtor()
        {
            id = id, debt = debtor.debt, firstName = debtor.firstName, isDeath = debtor.isDeath,
            lastName = debtor.lastName, address = debtor.address
        };
        Debtors[index] = newDebtor;
    }
}