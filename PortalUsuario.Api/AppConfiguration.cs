﻿using RCPortalConsultor.Core;

namespace RCPortalConsultor.Api;

public class AppConfigurations
{
    public class ConnectionString
    {
        public ConnectionString(string connectionStrings)
        {
            ConnectionStrings = connectionStrings;
        }

        public string ConnectionStrings { get; set; }
    }
}