using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniVM
{
    class StartStop : BaseSystemProcess
    {
        StartStop(int id, int priority) : base(id, priority) { }
        public override void Run()
        {
            throw new NotImplementedException();
        }
    }
}
