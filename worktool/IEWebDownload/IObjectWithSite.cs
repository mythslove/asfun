using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Runtime.InteropServices;

namespace IEWebDownload
{
    class IObjectWithSite
    {
        [
        ComVisible(true),
        InterfaceType(ComInterfaceType.InterfaceIsIUnknown),
        Guid("B63365E2-4483-472C-B1BC-41749C5DC20D")
        ]
        public interface IObjectWithSite
        {
            [PreserveSig]
            int SetSite([MarshalAs(UnmanagedType.IUnknown)]object site);

            [PreserveSig]
            int GetSite(ref Guid guid, out IntPtr ppvSite);
        }
    }
}
