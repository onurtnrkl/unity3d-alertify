using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Alertify
{
    public sealed class DialogSettings : Settings
	{
        [SerializeField]
        public Color OkColor;

        [SerializeField]
        public Color CancelColor;
	}
}