using System;
using System.Collections.Generic;

namespace SchoolManagementApp.MVC.Data;

public partial class Student
{
    public int Id { get; set; }

    public string Firstname { get; set; } = null!;

    public string Lastname { get; set; } = null!;

    public DateTime? DateOfBirth { get; set; }

    public virtual ICollection<Enrollment> Enrollments { get; } = new List<Enrollment>();
}
