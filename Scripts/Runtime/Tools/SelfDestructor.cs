﻿using UnityEngine;

namespace GoodMoodGames.Scripts.Runtime.Tools
{
    public class SelfDestructor : MonoBehaviour
    {
        [Tooltip("In seconds")] [SerializeField] private float _delay = 1;

        private void Start()
        {
            Destroy(gameObject, _delay);
        }
    }
}