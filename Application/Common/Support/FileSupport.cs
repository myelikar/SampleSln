using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Support
{
    public class FileSupport
    {
        const string fixstg = "\\bin\\";
        static public string GetBaseDir(string curdir)
        {
            if (string.IsNullOrEmpty(curdir))
                throw new ArgumentNullException();

            if (curdir.Contains(fixstg))
            {
                string basedir = curdir.Substring(0, curdir.IndexOf(fixstg));
                return basedir;
            }

            throw new InvalidDataException();
        }
    }
}
