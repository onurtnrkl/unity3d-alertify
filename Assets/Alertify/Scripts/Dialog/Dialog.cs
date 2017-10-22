using UnityEngine;
using UnityEngine.Events;

namespace Alertify
{
    public sealed class Dialog : MonoBehaviour
    {
        private static Dialog instance;

        //private DialogSettings settings;
        private DialogElement element;

        private void Awake()
        {
            if (instance == null)
            {
                instance = this;

                Init();
            }
            else
            {
                Destroy(gameObject);
            }
        }


        private void Init()
        {
            //settings = Settings.Instance.DialogSettings;
            GameObject prefab = Resources.Load<GameObject>("Prefabs/DialogElement");

            element = Instantiate(prefab, transform).GetComponent<DialogElement>();
        }

        public static void Alert(string dialog, UnityAction ok)
        {
            instance.element.EnableDialog(dialog);
            instance.element.EnableOkButton(ok);
            instance.element.FadeIn();
        }

        public static void Confirm(string dialog, UnityAction ok, UnityAction cancel)
        {
            instance.element.EnableDialog(dialog);
            instance.element.EnableOkButton(ok);
            instance.element.EnableCancelButton(cancel);
            instance.element.FadeIn();
        }

        public static void Prompt(string dialog, UnityAction<string> ok, UnityAction cancel)
        {
            instance.element.EnableInputField(dialog);
            instance.element.EnableOkButton(ok);
            instance.element.EnableCancelButton(cancel);
            instance.element.FadeIn();
        }

        public static void Prompt(string dialog, UnityAction<string> ok)
        {
            instance.element.EnableInputField(dialog);
            instance.element.EnableOkButton(ok);
            instance.element.FadeIn();
        }
    }
}