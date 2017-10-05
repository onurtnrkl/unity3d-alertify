using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Alertify
{
    [CustomEditor(typeof(Settings))] 
	public sealed class SettingsEditor : Editor
	{
        private Settings instance;

		public override void OnInspectorGUI()
		{
            instance = (Settings)target;

			SetupUI();
		}

        private void SetupUI()
        {
			EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("Notification Settings", EditorStyles.boldLabel);
			EditorGUILayout.EndHorizontal();
        }
	}   
}
