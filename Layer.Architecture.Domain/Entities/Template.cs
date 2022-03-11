﻿using System;
using System.Collections.Generic;

namespace Layer.Architecture.Domain.Entities
{
    public partial class Template : BaseEntity
    {
        public string Title { get; set; } = null!;
        public string? PostDescription { get; set; }
        public string ImgUrl { get; set; } = null!;
    }
}
