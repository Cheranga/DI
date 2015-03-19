﻿using DIDemo.Infrastructure;
using DIDemo.Infrastructure.Interfaces;

namespace DIDemo.Business.Models
{
    public class Customer : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
