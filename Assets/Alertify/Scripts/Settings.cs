﻿using System.IO;
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

        /*
        private void Awake()
        {
            Debug.Log("I am awake!");
            Settings settings = Resources.Load("AlertifySettings") as Settings;

            if (settings == null)
            {
#if UNITY_EDITOR
                Debug.LogFormat("Asset Path: {0}", GetAssetPath(settingsAssetName));
                CreateAsset();
#endif
            }
        }
        */

        protected void CreateAsset()
        {
            Settings settings = CreateInstance<Settings>();
			string path = GetAssetPath("AlertifySettings");

			AssetDatabase.CreateAsset(settings, path);
		}

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
			Settings settings = CreateInstance<Settings>();
            string settingsPath = GetAssetPath("AlertifySettings");
            bool fileExists = File.Exists(settingsPath);

            if(fileExists)
            {
                Debug.LogWarningFormat("Alertify already setup.");
            }
            else
            {
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