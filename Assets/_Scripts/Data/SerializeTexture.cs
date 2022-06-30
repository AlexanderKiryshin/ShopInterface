using System;
using UnityEngine;

namespace Assets._Scripts.Data
{
    [Serializable]
    public class SerializeTexture
    {
        [SerializeField]
        public int x;
        [SerializeField]
        public int y;
        [SerializeField]
        public byte[] bytes;
    }
}
