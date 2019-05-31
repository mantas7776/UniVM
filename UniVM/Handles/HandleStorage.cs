using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniVM
{
    public class HandleStorage
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

        public bool isFileTaken(string fileName)
        {
            int count = handles.Where(hndl =>
                hndl.GetType() == typeof(FileHandle) &&
                ((FileHandle)hndl).fileName == fileName
            ).Count();

            return count > 0;
        }
    }
}
