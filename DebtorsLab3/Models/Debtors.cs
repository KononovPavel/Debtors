namespace DebtorsLab3.Models;

public class Debtor
{
    public int id { get; set; }
    public string? firstName { get; set; }
    public string? lastName { get; set; }
    public Debt debt { get; set; }
    public Boolean? isDeath { get; set; }

    public Address address { get; set; }
}