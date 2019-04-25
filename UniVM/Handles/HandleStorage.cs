using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniVM
{
    class HandleStorage
    {
        List<Handle> handles = new List<Handle>();

        public int add(Handle hndl)
        {
            int ind = handles.Count;
            handles.Add(hndl);
            return ind;
        }

        public Handle this[int key]
        {
            get
            {
                return handles[key];
            }
        }

        public bool remove(Handle hndl)
        {
            hndl.close();
            return handles.Remove(hndl);
        }
    }
}
