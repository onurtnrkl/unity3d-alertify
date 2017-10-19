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
        public NotificationSettings NotificationSettings;
        public DialogSettings DialogSettings;

#if UNITY_EDITOR
        private static void CreateAsset()
        {
            Settings settings = CreateInstance<Settings>();
            string folder = Path.Combine("Assets", "Alertify/Resources");
            string file = "AlertifySettings.asset";
            string path = Path.Combine(folder, file);

            AssetDatabase.CreateAsset(settings, path);
        }

        [MenuItem("Alertify/Edit Settings")]
		public static void Edit()
		{
            Settings settings = Resources.Load("AlertifySettings") as Settings;

            if (settings == null) CreateAsset();

            Selection.activeObject = settings;
        }

		[MenuItem("Alertify/GitHub Page")]
		public static void OpenGitHub()
		{
			string url = "https://github.com/onurtnrkl/unity3d-alertify";
			Application.OpenURL(url);
		}
	}
#endif
}