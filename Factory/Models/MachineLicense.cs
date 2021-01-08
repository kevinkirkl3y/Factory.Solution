namespace Factory.Models
{
  public class MachineLicense
  {
    public int MachineLicenseId { get; set; }
    public int MachineId { get; set; }
    public int LicenseId { get; set; }
    public Machine Machine { get; set; }
    public License License { get; set; }

  }
}