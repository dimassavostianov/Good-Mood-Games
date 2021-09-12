using UnityEngine;

namespace Scripts.Runtime.Utilities.UI.DynamicUI
{
    public abstract class DynamicUIObject : MonoBehaviour
    {
        public int CurrentStateIndex { get; private set; }
        public virtual void ChangeState(int index) => CurrentStateIndex = index;
    }
}