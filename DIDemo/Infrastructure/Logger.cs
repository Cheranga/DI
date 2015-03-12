using System;
using System.Diagnostics;

namespace DIDemo.Infrastructure
{
    public class Logger : ILogger
    {
        public void Log(string message)
        {
            if (!string.IsNullOrEmpty(message))
            {
                Debug.WriteLine(message);
            }
        }
    }
}