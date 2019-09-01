using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kurs
{
    public abstract class AArch
    {
        public int Port { get; set; }
        public IPAddress Address { get; set; }
        protected Form form;
        protected Thread thread;
        public long pointer;

        public virtual void Close() { }
        protected virtual void Message(string msg) { }
    }
}
