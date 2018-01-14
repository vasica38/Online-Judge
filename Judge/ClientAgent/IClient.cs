using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Judge.ClientAgent
{
    public interface IClient
    {
        void Start();
        void Stop();
        void Dispose();
    }
}
