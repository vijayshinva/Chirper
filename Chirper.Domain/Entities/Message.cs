using System;
using System.Collections.Generic;
using System.Text;

namespace Chirper.Domain.Entities
{
    public class Message
    {
        public Guid Id { get; set; }
        public Guid ChirpUserId { get; set; }
        public string Text { get; set; }
        public DateTime Time { get; set; }
        public bool Deleted { get; set; }
    }
}
