using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Alertify
{
    public sealed class Dialog : MonoBehaviour
	{
        private static Dialog instance;

        private Prompt prompt;

        private void Awake()
        {
			if (instance == null)
			{
				instance = this;

                //TODO:Make this class like manager. Because monobehaviour is not working while object is not actived. 
				prompt = GetComponentInChildren<Prompt>();
			}
			else
			{
				Destroy(gameObject);
			}
        }

        public static void Alert(string dialog, UnityAction ok)
        {
            
        }

        public static void Confirm(string dialog, UnityAction ok, UnityAction cancel)
        {
            
        }

        public static void Prompt(string dialog, UnityAction<string> ok, UnityAction cancel)
        {
            if (instance == null)
            {
                Debug.Log("null");
                return;
            }
            instance.prompt.Enable(dialog, ok, cancel);
        }

        public static void Prompt(string dialog, UnityAction<string> ok)
        {
            
        }
    }   
}