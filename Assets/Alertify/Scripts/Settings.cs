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

        private static Settings instance;

        public static Settings Instance
        {
            get
            {
                if (instance == null)
                {
                    Settings settings = Resources.Load("AlertifySettings") as Settings;

                    if (settings == null)
                    {
                        settings = CreateInstance<Settings>();

                        if (Application.isEditor)
                        {
                            string folder = Path.Combine("Assets", "Alertify/Resources");
                            string file = "AlertifySettings.asset";
                            string path = Path.Combine(folder, file);

                            AssetDatabase.CreateAsset(settings, path);
                        }
                    }

                    instance = settings;
                }

                return instance;
            }
        }
    }
}