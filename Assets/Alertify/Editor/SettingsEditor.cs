using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Alertify
{
    [CustomEditor(typeof(Settings))]
    public class SettingsEditor : Editor
	{
        private NotificationSettings notificationSettings;
        private DialogSettings dialogSettings;

        private void OnEnable()
        {
            notificationSettings = Resources.Load<NotificationSettings>("Notification");
            dialogSettings = Resources.Load<DialogSettings>("Dialog");
        }

        public override void OnInspectorGUI()
		{
            Settings settings = (Settings)target;

            serializedObject.Update();

            SetupUI();

            serializedObject.ApplyModifiedProperties();
		}

        private void SetupUI()
        {
            SetupNotificationUI();
            EditorGUILayout.Space();

        }

        private void SetupNotificationUI()
        {
			EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("Notification Settings", EditorStyles.boldLabel);
			EditorGUILayout.EndHorizontal();

			EditorGUILayout.BeginHorizontal();
			EditorGUILayout.LabelField("Pool Size", EditorStyles.label);
            notificationSettings.PoolSize = EditorGUILayout.IntSlider(notificationSettings.PoolSize, 1, 20);
			EditorGUILayout.EndHorizontal();

            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("Duration", EditorStyles.label);
            notificationSettings.Duration = EditorGUILayout.Slider(notificationSettings.Duration, 0.1f, 10f);
            EditorGUILayout.EndHorizontal();

			EditorGUILayout.BeginHorizontal();
			EditorGUILayout.LabelField("Message Color", EditorStyles.label);
            notificationSettings.MessageColor = EditorGUILayout.ColorField(notificationSettings.MessageColor);
			EditorGUILayout.EndHorizontal();

			EditorGUILayout.BeginHorizontal();
			EditorGUILayout.LabelField("Success Color", EditorStyles.label);
            notificationSettings.SuccessColor = EditorGUILayout.ColorField(notificationSettings.SuccessColor);
			EditorGUILayout.EndHorizontal();

			EditorGUILayout.BeginHorizontal();
			EditorGUILayout.LabelField("Error Color", EditorStyles.label);
            notificationSettings.ErrorColor = EditorGUILayout.ColorField(notificationSettings.ErrorColor);
			EditorGUILayout.EndHorizontal();

			EditorGUILayout.BeginHorizontal();
			EditorGUILayout.LabelField("Warning Color", EditorStyles.label);
            notificationSettings.WarningColor = EditorGUILayout.ColorField(notificationSettings.WarningColor);
			EditorGUILayout.EndHorizontal();

            //TODO: Settings to need add:
            //Text settings
            //
        }

        private void SetupDialogUI()
        {
            
        }
	}   
}
