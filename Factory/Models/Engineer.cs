using System.Collections.Generic;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace Factory.Models
{
  public class Engineer
  {
    public Engineer()
    {
      this.Licenses = new HashSet<LicenseEngineer>();
    }
    public int EngineerId { get; set; }
    public string EngineerName { get; set; }
    public string EngineerContact { get; set; }
    [DisplayName("Add Date")]
    [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyy-MM-dd}")]
    public DateTime HireDate { get; set; }

    public virtual ICollection<LicenseEngineer> Licenses { get; set; }
  }
}