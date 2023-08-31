using System;
using System.Diagnostics.CodeAnalysis;

namespace Bank.Domain.Notifications
{
    [ExcludeFromCodeCoverage]
    public class NotificationMessage
    {
        public NotificationMessage(string key, string value)
        {
            Id = Guid.NewGuid();
            Key = key;
            Value = value;
        }

        public Guid Id { get; private set; }
        public string Key { get; private set; }
        public string Value { get; private set; }
    }
}