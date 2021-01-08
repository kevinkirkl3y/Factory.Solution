using System.Collections.Generic;
using System;

namespace Factory.Models
{
  public class License
  {
    public License()
    {
      this.Engineers = new HashSet<LicenseEngineer>();
    }
    public int LicenseId { get; set; }
    public string Type { get; set; }
    public DateTime IssueDate { get; set; }

    public virtual ICollection<LicenseEngineer> Engineers { get; set; }
  }
}