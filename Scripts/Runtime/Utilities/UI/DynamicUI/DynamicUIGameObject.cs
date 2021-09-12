using System.Linq;
using UnityEngine;

namespace Scripts.Runtime.Utilities.UI.DynamicUI
{
    public sealed class DynamicUIGameObject : DynamicUIObject
    {
        [SerializeField] private GameObject[] _gameObjects;
        
        public override void ChangeState(int index)
        {
            base.ChangeState(index);
            
            var activeObject = _gameObjects[index];
            foreach (var go in _gameObjects.Where(x => x != null))
                go.SetActive(go == activeObject);
        }
    }
}