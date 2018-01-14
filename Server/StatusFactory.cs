using Server.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Server
{
    public class StatusFactory
    {
        private static Dictionary<string, Status> statuses = new Dictionary<string, Status>();

        public static void RegisterStatus(string code, Status status)
        {
            statuses[code] = status;
        }

        public static void RemoveStatus(string code)
        {
            if (statuses[code] != null)
            {
                statuses.Remove(code);
            }
        }

        public static Status GetStatus(string code)
        {
            return statuses[code];
        }
    }
}
