using Server.Interfaces;
using Server.Tools;
using System;
using System.Collections.Generic;
using System.Text;

namespace Server.Models
{
    public class SubmissionEvent : IEvent
    {
        public SubmissionJson Submission { get; set;  }
        private EventQueue eventQueue;
        public SubmissionEvent(EventQueue eventQueue)
        {
            this.eventQueue = eventQueue;
        }
        public void Notify()
        {
            this.eventQueue.Add(this);

        }

        public void Subscribe(string data)
        {
            Submission = JsonDeserializer.Deserialize(data);
        }
    }
}
