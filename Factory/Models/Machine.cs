using System.Collections.Generic;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Factory.Models
{
  public class Machine
  {
    public Machine()
    {
      this.Engineers = new HashSet<MachineEngineer>();
      this.Licenses = new HashSet<MachineLicense>();
    }
    public int MachineId { get; set; }
    public string MachineName { get; set; }
    public string SerialNumber { get; set; }
    [DisplayName("Add Date")]
    [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyy-MM-dd}")]
    public DateTime InstallDate { get; set; }
    public virtual ICollection<MachineEngineer> Engineers { get; set; }
    public virtual ICollection<MachineLicense> Licenses { get; set; }
  }
}