using UnityEngine;
using UnityEngine.UI;

namespace GoodMoodGames.Scripts.Runtime.Utilities.UI.DynamicUI
{
    public sealed class DynamicUIImage : DynamicUIObject
    {
        [SerializeField] private Image _image;
        [SerializeField] private Sprite[] _sprites;
        
        public override void ChangeState(int index)
        {
            base.ChangeState(index);
            _image.sprite = _sprites[index];
        }
    }
}