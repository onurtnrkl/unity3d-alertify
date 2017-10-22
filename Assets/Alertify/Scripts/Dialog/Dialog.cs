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

        /// <summary>
        /// Creates alert window.
        /// </summary>
        /// <param name="text">Dialog text.</param>
        /// <param name="onClickOk">On click ok button.</param>
        public static void Alert(string text, UnityAction onClickOk)
        {
            onClickOk += () => instance.element.FadeOut();
            instance.element.EnableDialog(text);
            instance.element.EnableOkButton(onClickOk);
            instance.element.FadeIn();
        }

        /// <summary>
        /// Creates Confirm window.
        /// </summary>
        /// <param name="text">Dialog text.</param>
        /// <param name="onClickOk">On click ok button.</param>
        /// <param name="onClickCancel">On click cancel button.</param>
        public static void Confirm(string text, UnityAction onClickOk, UnityAction onClickCancel)
        {
            onClickOk += () => instance.element.FadeOut();
            onClickCancel += () => instance.element.FadeOut();
            instance.element.EnableDialog(text);
            instance.element.EnableOkButton(onClickOk);
            instance.element.EnableCancelButton(onClickCancel);
            instance.element.FadeIn();
        }

        /// <summary>
        /// Creates Prompt Window.
        /// </summary>
        /// <param name="text">Dialog text.</param>
        /// <param name="onClickOk">On click ok button.</param>
        /// <param name="onClickCancel">On click cancel button.</param>
        public static void Prompt(string text, UnityAction<string> onClickOk, UnityAction onClickCancel)
        {
            onClickOk += (string input) => instance.element.FadeOut();
            onClickCancel += () => instance.element.FadeOut();
            instance.element.EnableInputField(text);
            instance.element.EnableOkButton(onClickOk);
            instance.element.EnableCancelButton(onClickCancel);
            instance.element.FadeIn();
        }

        /// <summary>
        /// Creates Prompt Window.
        /// </summary>
        /// <param name="text">Dialog text.</param>
        /// <param name="onClickOk">On click ok button.</param>
        public static void Prompt(string text, UnityAction<string> onCickOk)
        {
            onCickOk += (string input) => instance.element.FadeOut();
            instance.element.EnableInputField(text);
            instance.element.EnableOkButton(onCickOk);
            instance.element.FadeIn();
        }
    }
}