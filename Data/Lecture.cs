using System;
using System.Collections.Generic;

namespace SchoolManagementApp.MVC.Data;

public partial class Lecture
{
    public int Id { get; set; }

    public string Firstname { get; set; } = null!;

    public string Lastname { get; set; } = null!;
}
