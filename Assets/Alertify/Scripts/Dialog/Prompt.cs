using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Prompt : MonoBehaviour 
{
    [SerializeField]
    private InputField inputField;
    [SerializeField]
    private Button okButton;
    [SerializeField]
    private Button cancelButton;

    public void Enable(string dialog, UnityAction onClickOk, UnityAction onClickCancel)
    {
        if (onClickOk == null) Debug.Log("onClickOk null");
        if (onClickCancel == null) Debug.Log("onClickCancel null");

        inputField.transform.GetChild(0).GetComponent<Text>().text = dialog;
        okButton.onClick.AddListener(onClickOk);
        okButton.onClick.AddListener(Disable);
        cancelButton.onClick.AddListener(onClickCancel);
        cancelButton.onClick.AddListener(Disable);
        inputField.gameObject.SetActive(true);
        okButton.gameObject.SetActive(true);
        cancelButton.gameObject.SetActive(true);
        //TODO: Opening animation
        gameObject.SetActive(true);
    }

    private void Disable()
    {
        okButton.onClick.RemoveAllListeners();
        cancelButton.onClick.RemoveAllListeners();
        //TODO: Closing animation
        gameObject.SetActive(false);
    }
}
