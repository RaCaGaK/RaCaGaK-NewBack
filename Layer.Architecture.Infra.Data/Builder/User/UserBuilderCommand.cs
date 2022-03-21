﻿namespace Layer.Architecture.Infra.Data.Builder
{
    public class UserBuilderCommand
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string NickName { get; set; }
        public string? ImgUrl { get; set; }
        public string Email { get; set; }
        public string Passwd { get; set; }
    }
}