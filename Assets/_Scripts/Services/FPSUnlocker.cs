using UnityEngine.Device;

namespace _Scripts.Services
{
    public class FPSUnlocker
    {
        public FPSUnlocker()
        {
            Application.targetFrameRate = 60;
        }
    }
}