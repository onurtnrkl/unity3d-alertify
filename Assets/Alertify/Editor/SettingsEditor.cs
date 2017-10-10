using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Alertify
{
    [CustomEditor(typeof(Settings))] 
	public class SettingsEditor : Editor
	{
		public override void OnInspectorGUI()
		{
            Settings settings = (Settings)target;

			//SetupUI();
		}

        private void SetupUI()
        {
			EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("Notification Settings", EditorStyles.boldLabel);
			EditorGUILayout.EndHorizontal();
        }
	}   
}
