﻿namespace Architecture.Core.Entities.LU
{
    public class Gender
    {
        public int GenderId { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
