﻿using System;
using System.Collections.Generic;
using System.Text;

namespace McNutClients
{
    public class ClientModel
    {
        public long Ci { get; set; }
        public string? Name { get; set; }
        public string? SurName { get; set; }
        public long? Phone { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? Address { get; set; }
        public IEnumerable<IPeanutService> Peanuts { get; set; }
    }
}
