using TMPro;
using UnityEngine;

namespace Scripts.Runtime.Tools.Text
{
    public class RewardTextSetter : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _text;
        [SerializeField] private string _format = "${0}";
        
        [Space]
        [SerializeField] private int _minReward;
        [SerializeField] private int _maxReward;
        
        private void Start()
        {
            _text.text = string.Format(_format, RandomGenerator.GetRandom(_minReward, _maxReward));
        }
    }
}