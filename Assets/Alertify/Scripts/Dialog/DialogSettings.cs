using System;
using UnityEngine;

namespace Alertify
{
    [Serializable]
    public sealed class DialogSettings
	{
        public float BoxWidth;
        public Color OkColor;
        public Color CancelColor;

        public DialogSettings()
        {
            BoxWidth = 5f;
            OkColor = Color.green;
            CancelColor = Color.red;
        }
	}
}