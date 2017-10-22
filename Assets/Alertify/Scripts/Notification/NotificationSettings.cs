using System;
using UnityEngine;

namespace Alertify
{
    [Serializable]
    public sealed class NotificationSettings
    {
        public int PoolSize;
        public float Duration;
        public Color MessageColor;
        public Color SuccessColor;
        public Color ErrorColor;
        public Color WarningColor;

        public NotificationSettings()
        {
            PoolSize = 10;
            Duration = 2.5f;
            MessageColor = Color.blue;
            SuccessColor = Color.green;
            ErrorColor = Color.red;
            WarningColor = Color.yellow;
        }
    }
}