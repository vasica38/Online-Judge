using Server.Interfaces;
using Server.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Server
{
    public class EventQueue
    {
        private Queue<SubmissionEvent> events = new Queue<SubmissionEvent>();

        public void Add(SubmissionEvent _event)
        {
            events.Enqueue(_event);
            EventLoop();
        }

        public void EventLoop()
        {
            while(events.Count>0)
            {
                //Check submmiton

                events.Dequeue();
            }
        }
    }
}
