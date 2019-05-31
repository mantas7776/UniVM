using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniVM
{
    public class HandleStorage
    {
        Dictionary<int, Handle> handles = new Dictionary<int, Handle>(); 
        int lastid = 0;

        public int add(Handle hndl)
        {
            int ind = lastid++;
            handles[ind] = hndl;
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
            int id = handles.FirstOrDefault(x => x.Value == hndl).Key;
            return handles.Remove(id);
        }

        public bool isFileTaken(string fileName)
        {
            int count = handles.Where(hndl =>
                hndl.Value.GetType() == typeof(FileHandle) &&
                ((FileHandle)hndl.Value).fileName == fileName
            ).Count();

            return count > 0;
        }
    }
}
