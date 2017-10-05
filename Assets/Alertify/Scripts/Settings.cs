using System.IO;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace Alertify
{
#if UNITY_EDITOR
    [InitializeOnLoad]
#endif

    public class Settings : ScriptableObject
	{
		const string settingsAssetName = "AlertifySettings";
		const string settingsPath = "Alertify/Resources";
		const string settingsAssetExtension = ".asset";

		private static Settings instance;

		static Settings Instance
		{
			get
			{
				if (instance == null)
				{
					instance = Resources.Load("AlertifySettings") as Settings;

					if (instance == null)
					{
						// If not found, autocreate the asset object.
						instance = CreateInstance<Settings>();
#if UNITY_EDITOR
                        string path = Path.Combine(Path.Combine("Assets", settingsPath),
                                                   settingsAssetName + settingsAssetExtension
													  );
						AssetDatabase.CreateAsset(instance, path);
#endif
					}
				}
				return instance;
			}
		}

#if UNITY_EDITOR
		[MenuItem("Alertify/Edit Settings")]
		public static void Edit()
		{
            Selection.activeObject = Instance;
		}

		[MenuItem("Alertify/GitHub Page")]
		public static void OpenGitHub()
		{
			string url = "https://github.com/onurtnrkl/unity3d-alertify";
			Application.OpenURL(url);
		}
#endif
        [SerializeField]
        public byte PoolSize;

        [SerializeField]
        public Color MessageColor;

        [SerializeField]
        public Color SuccessColor;

        [SerializeField]
        public Color ErrorColor;

        [SerializeField]
        public Color WarningColor;

        public static byte GetPoolSize()
        {
            return Instance.PoolSize;
        }

        public static Color GetMessageColor()
        {
            return Instance.MessageColor;
        }

		public static Color GetSuccessColor()
		{
            return Instance.SuccessColor;
		}

		public static Color GetErrorColor()
		{
            return Instance.ErrorColor;
		}

		public static Color GetWarningColor()
		{
            return Instance.WarningColor;
		}
	}
}