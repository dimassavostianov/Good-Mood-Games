﻿using UnityEngine;

namespace Tools
{
    public class LinkOpener : MonoBehaviour
    {
        [SerializeField] string _url;

        public void OpenURL()
        {
            Application.OpenURL(_url);
        }
    }
}