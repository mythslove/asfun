using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using mshtml;

namespace IEWebDownload
{



    [
    ComVisible(true),
    Guid("80256FED-E206-4F8A-A405-9BF32A76D03C"),
    ClassInterface(ClassInterfaceType.None)
    ]
    class BHO:IObjectWithSite
    {
        WebBrowser webBrowser;
        HTMLDocument document;

        public int SetSite(object site)
        {
            if (site != null)
            {
                webBrowser = (WebBrowser)site;
            }
            else
            {
            }
            return 0;
        }

        public int GetSite(ref Guid guid, out IntPtr ppvSite)
        {
            ppvSite = IntPtr.Zero;
            return 0;
        }
    }
}
