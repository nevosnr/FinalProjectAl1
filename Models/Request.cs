using System;
using System.Collections.Generic;

namespace FinalProjectAl1.Models;

public partial class Request
{
    public Guid RequestTaskId { get; set; }

    public string? RequestShortId { get; set; }

    public DateTime? RequestCreated { get; set; }

    public string? RequestRank { get; set; }

    public string? RequestFirstName { get; set; }

    public string? RequestLastName { get; set; }

    public string? RequestEmailAdd { get; set; }

    public string? RequestContactPhone { get; set; }

    public string? RequestUnitIdentifier { get; set; }

    public string? RequestAssignedTo { get; set; }

    public string? RequestTitle { get; set; }

    public string? RequestTaskDescription { get; set; }

    public string? RequestStatus { get; set; }

    public bool? RequestArchive { get; set; }
}
