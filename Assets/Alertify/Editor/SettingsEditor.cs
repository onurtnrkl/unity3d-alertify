using System.IO;
using UnityEditor;
using UnityEngine;

namespace Alertify
{
    [CustomEditor(typeof(Settings))]
    public class SettingsEditor : Editor
	{
        private Settings settings;
        private GameObject notificationElement;
        private GameObject dialogElement;

        [MenuItem("Alertify/Edit Settings")]
        private static void Edit()
        {
            Selection.activeObject = Settings.Instance;
        }

        [MenuItem("Alertify/GitHub Page")]
        private static void OpenGitHub()
        {
            string url = "https://github.com/onurtnrkl/unity3d-alertify";
            Application.OpenURL(url);
        }

        private GameObject LoadAsset(string name)
        {
            const string folder = "Assets/Alertify/Resources/Prefabs";
            string file = name + ".prefab";
            string path = Path.Combine(folder, file);
            GameObject asset = AssetDatabase.LoadAssetAtPath<GameObject>(path);

            return asset;
        }

        private void OnEnable()
        {
            settings = Settings.Instance;

            notificationElement = LoadAsset("NotificationElement");
            dialogElement = LoadAsset("DialogElement");
        }

        public override void OnInspectorGUI()
		{
            SetupUI();

            if (GUI.changed)
            {
                EditorUtility.SetDirty(target);
            }
        }

        private void SetupUI()
        {
            SetupNotificationUI();
            EditorGUILayout.Space();
            SetupDialogUI();
        }

        private void SetupNotificationUI()
        {
            NotificationSettings settings = this.settings.NotificationSettings;

			EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("Notification Settings", EditorStyles.boldLabel);
			EditorGUILayout.EndHorizontal();

			EditorGUILayout.BeginHorizontal();
			EditorGUILayout.LabelField("Pool Size", EditorStyles.label);
            settings.PoolSize = EditorGUILayout.IntSlider(settings.PoolSize, 1, 20);
			EditorGUILayout.EndHorizontal();

            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("Duration", EditorStyles.label);
            settings.Duration = EditorGUILayout.Slider(settings.Duration, 0.1f, 10f);
            EditorGUILayout.EndHorizontal();

			EditorGUILayout.BeginHorizontal();
			EditorGUILayout.LabelField("Message Color", EditorStyles.label);
            settings.MessageColor = EditorGUILayout.ColorField(settings.MessageColor);
			EditorGUILayout.EndHorizontal();

			EditorGUILayout.BeginHorizontal();
			EditorGUILayout.LabelField("Success Color", EditorStyles.label);
            settings.SuccessColor = EditorGUILayout.ColorField(settings.SuccessColor);
			EditorGUILayout.EndHorizontal();

			EditorGUILayout.BeginHorizontal();
			EditorGUILayout.LabelField("Error Color", EditorStyles.label);
            settings.ErrorColor = EditorGUILayout.ColorField(settings.ErrorColor);
			EditorGUILayout.EndHorizontal();

			EditorGUILayout.BeginHorizontal();
			EditorGUILayout.LabelField("Warning Color", EditorStyles.label);
            settings.WarningColor = EditorGUILayout.ColorField(settings.WarningColor);
			EditorGUILayout.EndHorizontal();

            if (GUILayout.Button("Edit Prefab"))
            {
                Selection.activeObject = notificationElement;
            }
        }

        private void SetupDialogUI()
        {
            //DialogSettings settings = this.settings.DialogSettings;

            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("Dialog Settings", EditorStyles.boldLabel);
            EditorGUILayout.EndHorizontal();

            if (GUILayout.Button("Edit Prefab"))
            {
                Selection.activeObject = dialogElement;
            }

            //EditorGUILayout.BeginHorizontal();
            //EditorGUILayout.LabelField("Box Width", EditorStyles.label);
            //float size = EditorGUILayout.Slider(settings.BoxWidth, 1, 5);
            //dialog.GetComponent<RectTransform>().sizeDelta = new Vector2(size, size);
            //EditorGUILayout.EndHorizontal();

            //EditorGUILayout.BeginHorizontal();
            //EditorGUILayout.LabelField("OK Color", EditorStyles.label);
            //settings.OkColor = EditorGUILayout.ColorField(settings.OkColor);
            //EditorGUILayout.EndHorizontal();

            //EditorGUILayout.BeginHorizontal();
            //EditorGUILayout.LabelField("Cancel Color", EditorStyles.label);
            //settings.CancelColor = EditorGUILayout.ColorField(settings.CancelColor);
            //EditorGUILayout.EndHorizontal();
        }
	}   
}
