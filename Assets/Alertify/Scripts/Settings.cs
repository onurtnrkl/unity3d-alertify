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
#if UNITY_EDITOR
		[MenuItem("Alertify/Edit Settings")]
		public static void Edit()
		{
            Debug.Log("Edit");
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