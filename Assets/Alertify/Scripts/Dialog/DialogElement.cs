using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Alertify
{
    public sealed class DialogElement : Element
    {
        [SerializeField] private Text dialog;
        [SerializeField] private InputField inputField;
        [SerializeField] private Text placeholderDialog;
        [SerializeField] private Button ok;
        [SerializeField] private Button cancel;

        private string InputValue
        {
            get { return inputField.text; }
        }

        /// <summary>
        /// Enables the dialog text.
        /// </summary>
        /// <param name="text">Dialog text.</param>
        public void EnableDialog(string text)
        {
            dialog.text = text;
            dialog.gameObject.SetActive(true);
        }

        /// <summary>
        /// Enables the input field.
        /// </summary>
        /// <param name="text">Placeholder dialog text.</param>
        public void EnableInputField(string text)
        {
            placeholderDialog.text = text;
            inputField.gameObject.SetActive(true);
        }

        /// <summary>
        /// Enables the ok button
        /// </summary>
        /// <param name="onClickOk">On click button action.</param>
        public void EnableOkButton(UnityAction onClickOk)
        {
            ok.onClick.AddListener(onClickOk);
            ok.gameObject.SetActive(true);
        }

        /// <summary>
        /// Enables the ok button
        /// </summary>
        /// <param name="onClickOk">On click button action for the input field.</param>
        public void EnableOkButton(UnityAction<string> onClickOk)
        {
            ok.onClick.AddListener(() => onClickOk(InputValue));
            ok.gameObject.SetActive(true);
        }

        /// <summary>
        /// Enables the cancel button.
        /// </summary>
        /// <param name="onClickCancel">On click cancel button action.</param>
        public void EnableCancelButton(UnityAction onClickCancel)
        {
            cancel.onClick.AddListener(onClickCancel);
            cancel.gameObject.SetActive(true);
        }
    }

}