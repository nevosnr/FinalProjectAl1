using System;
using System.Collections.Generic;

namespace FinalProjectAl1.Models;

public partial class ViewRequestAudit
{
    public Guid UpdateId { get; set; }

    public Guid RequestTaskId { get; set; }

    public string? RequestTitle { get; set; }

    public string? RequestTaskDescription { get; set; }

    public DateTime? UpdateTimeStamp { get; set; }

    public string? UpdateDescription { get; set; }

    public string? UpdateBy { get; set; }

    public string? RequestEmailAdd { get; set; }

    public DateTime? RequestCreated { get; set; }

    public string? RequestStatus { get; set; }
}
