﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Usuarios.Models
{
    public class Token
    {
        public Token(string value)
        {
            Value = value;
        }

        public string Value { get; }
    }
}
