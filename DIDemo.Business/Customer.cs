﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DIDemo.Infrastructure;

namespace DIDemo.Business
{
    public class Customer : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
