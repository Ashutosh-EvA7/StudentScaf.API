using System;
using System.Collections.Generic;

namespace StudentScaf.Entity.Models;

public partial class StudentScaff
{
    public int StudentId { get; set; }

    public string? Sname { get; set; }

    public int Sclass { get; set; }

    public int StotalMarksObtained { get; set; }
}
