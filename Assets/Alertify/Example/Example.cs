using UnityEngine;
using Alertify;

public class Example : MonoBehaviour
{
    public void OnClickAlert()
    {
        Dialog.Alert("Alert!",
                    () => Notification.Warning("Warning!"));
    }

    public void OnClickConfirm()
    {
        Dialog.Confirm("Confirm!",
                      () => Notification.Success("Success!"),
                      () => Notification.Error("Error!"));
    }

    public void OnClickPrompt()
    {
        Dialog.Prompt("Prompt!",
                     (string input) => Notification.Success("Success: " + input),
                     () => Notification.Error("Error!"));
    }
}
