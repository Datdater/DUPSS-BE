﻿using System.ComponentModel.DataAnnotations;
using DUPSS.Domain.Commons;

namespace DUPSS.Domain.Entities;

public class Category : BaseEntity
{
    public string CateName { get; set; }

    public string CateDescription { get; set; }

    // Navigation
    public ICollection<Course> Courses { get; set; }
}
