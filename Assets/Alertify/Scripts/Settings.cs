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
                    instance = Resources.Load("AlertifySettings") as Settings;

                    if (instance == null)
                    {
                        instance = CreateInstance<Settings>();
#if UNITY_EDITOR
                        string folder = Path.Combine("Assets", "Alertify/Resources");
                        const string file = "AlertifySettings.asset";
                        string path = Path.Combine(folder, file);

                        AssetDatabase.CreateAsset(instance, path);
#endif
                    }
                }

                return instance;
            }
        }
    }
}