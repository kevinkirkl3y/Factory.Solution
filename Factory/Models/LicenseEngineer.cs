namespace Factory.Models
{
  public class LicenseEngineer
  {
    public int LicenseEngineerId { get; set; }
    public int LicenseId { get; set; }
    public int EngineerId { get; set; }
    public License License { get; set; }
    public Engineer Engineer { get; set; }
  }
}