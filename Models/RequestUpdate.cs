using System;
using System.Collections.Generic;

namespace FinalProjectAl1.Models;

public partial class RequestUpdate
{
    public Guid UpdateId { get; set; }

    public Guid RequestTaskId { get; set; }

    public DateTime? UpdateTimeStamp { get; set; }

    public string? UpdateDescription { get; set; }

    public string? UpdateBy { get; set; }

    public string? UpdateStatus { get; set; }
}
