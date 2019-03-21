using System;
using System.Runtime.InteropServices;

namespace DemoApp
{
    class NativeBoxWrapper : IDisposable
    {
        IntPtr handle;

        [DllImport("box")]
        extern static IntPtr CreateBox(float length, float breadth, float height);

        [DllImport("box")]
        extern static void DestroyBox(IntPtr box);

        [DllImport("box", EntryPoint="BoxGetVolume")]
        extern static double GetBoxVolume(IntPtr box, float thickness);

        public NativeBoxWrapper(float l, float b, float h)
        {
            handle = CreateBox(l, b, h);
        }

        public double GetInnerVolume(float t)
        {
            return GetBoxVolume(handle, t);
        }

        public void Dispose()
        {
            DestroyBox(handle);
            GC.SuppressFinalize(this);
        }

        ~NativeBoxWrapper()
        {
            DestroyBox(handle);
        }
    }
}
