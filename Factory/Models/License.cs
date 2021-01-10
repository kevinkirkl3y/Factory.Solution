using System.Collections.Generic;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Factory.Models
{
  public class License
  {
    public License()
    {
      this.Engineers = new HashSet<LicenseEngineer>();
      this.Machines = new HashSet<MachineLicense>();
    }
    public int LicenseId { get; set; }
    public string LicenseType { get; set; }
    [DisplayName("Add Date")]
    [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyy-MM-dd}")]
    public DateTime IssueDate { get; set; }
    public ICollection<LicenseEngineer> Engineers { get; set; }
    public ICollection<MachineLicense> Machines { get; set; }

  }
}