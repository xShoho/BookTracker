namespace BookTracker.Models;

using System.ComponentModel;

public enum Genre
{
    [Description("Fiction")]
    Fiction,

    [Description("Non Fiction")]
    NonFiction,

    [Description("Mystery")]
    Mystery,

    [Description("Science Fiction")]
    ScienceFiction,

    [Description("Fantasy")]
    Fantasy,

    [Description("Biography")]
    Biography,

    [Description("History")]
    History,

    [Description("Self Help")]
    SelfHelp,

    [Description("Technical")]
    Technical,

    [Description("Other")]
    Other,
}
