using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace SchoolManagementApp.MVC.Data;

public class StudentMetaData{
    
    [Display(Name = "First Name")]
    public string Firstname { get; set; } = null!;

    [Display(Name = "Last Name")]
    public string Lastname { get; set; } = null!;

    [Display(Name = " Date Of Birth ")]
    public DateTime? DateOfBirth { get; set; }
}

[ModelMetadataType(typeof(StudentMetaData))]
public partial class Student{}