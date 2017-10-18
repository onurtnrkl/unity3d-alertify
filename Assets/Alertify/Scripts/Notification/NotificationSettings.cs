using UnityEngine;

namespace Alertify
{
    public sealed class NotificationSettings : Settings
	{
		[SerializeField]
		public int PoolSize;

		[SerializeField]
		public float Duration;

		[SerializeField]
		public Color MessageColor;

		[SerializeField]
		public Color SuccessColor;

		[SerializeField]
		public Color ErrorColor;

		[SerializeField]
		public Color WarningColor;
	}
}