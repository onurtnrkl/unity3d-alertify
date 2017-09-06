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

        private void Awake()
        {
            if(instance != null && instance != this)
            {
                Destroy(gameObject);
            }
            else
            {
                instance = this;
            }

			//FIXME: DontDestroyOnLoad only work for root GameObjects or components on root GameObjects.
			DontDestroyOnLoad(gameObject);
        }

        public static void Alert(string dialog, UnityAction ok)
        {
            
        }

        public static void Confirm(string dialog, UnityAction ok, UnityAction cancel)
        {
            
        }

        public static void Prompt(string dialog, UnityAction ok, UnityAction cancel)
        {
            
        }
    }   
}