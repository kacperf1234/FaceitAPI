﻿using System;
using System.Collections.Generic;
using System.Text;
using FaceitAPI.Interfaces;

namespace FaceitAPI.Types
{
    public class Authorization : IAuthorizable
    {
        public string Key { get; set; }

        public Authorization(string apikey)
        {
            Key = apikey;
        }

        public string GetBearer()
        {
            return "Bearer " + Key;
        }
    }
}
