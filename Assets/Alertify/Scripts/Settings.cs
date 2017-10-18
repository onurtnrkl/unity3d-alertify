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
        private const string folderPath = "Alertify/Resources";
        private const string assetExtension = ".asset";

        private static string GetAssetPath(string name)
        {
            string folder = Path.Combine("Assets", folderPath);
            string file = name + assetExtension;
            string path = Path.Combine(folder, file);

            return path;
        }

#if UNITY_EDITOR
        [MenuItem("Alertify/Setup")]
        public static void Setup()
        {
            string settingsPath = GetAssetPath("AlertifySettings");
            bool fileExists = File.Exists(settingsPath);

            if(fileExists)
            {
                Debug.LogWarningFormat("Alertify already setup.");
            }
            else
            {
                Settings settings = CreateInstance<Settings>();
                NotificationSettings notificationSettings = CreateInstance<NotificationSettings>();
                DialogSettings dialogSettings = CreateInstance<DialogSettings>();

                string notificationPath = GetAssetPath("Notification");
                string dialogPath = GetAssetPath("Dialog");

                AssetDatabase.CreateAsset(settings, settingsPath);
                AssetDatabase.CreateAsset(notificationSettings, notificationPath);
                AssetDatabase.CreateAsset(dialogSettings, dialogPath);
            }			
        }

		[MenuItem("Alertify/Edit Settings")]
		public static void Edit()
		{
            Selection.activeObject = Resources.Load("AlertifySettings") as Settings;
		}

		[MenuItem("Alertify/GitHub Page")]
		public static void OpenGitHub()
		{
			string url = "https://github.com/onurtnrkl/unity3d-alertify";
			Application.OpenURL(url);
		}
#endif

	}
}