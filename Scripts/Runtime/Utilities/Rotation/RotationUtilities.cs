using UnityEngine;

namespace GoodMoodGames.Scripts.Runtime.Utilities.Rotation
{
    public static class RotationUtilities
    {
        public static float RotationOnAxis(int axis, Quaternion rot)
        {
            rot.x /= rot.w;
            rot.y /= rot.w;
            rot.z /= rot.w;
            rot.w = 1;
 
            return 2.0f * Mathf.Rad2Deg * Mathf.Atan(rot[axis]);
        }
    }
}