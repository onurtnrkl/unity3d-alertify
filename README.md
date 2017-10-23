# unity3d-alertify

# [Preview](https://onurtnrkl.github.io/unity3d-alertify/)

# Setup
* [Install Unity Package](https://github.com/onurtnrkl/unity3d-alertify/releases)
* Drag the Alertify prefab from the Alertify folder into your scene.
* Edit settings from Alertify tab in Unity Editor.

# Usage
### Notification Static Methods
* Alert(string text, UnityAction onClickOk)
* Confirm(string text, UnityAction onClickOk, UnityAction onClickCancel)
* Prompt(string text, UnityAction<string> onCickOk)
* Prompt(string text, UnityAction<string> onClickOk, UnityAction onClickCancel)
  
### Dialog Static Methods
* Message(string text)
* Success(string text)
* Error(string text)
* Warning(string text)

# Example
```cs
using Alertify;

Dialog.Alert("Alert!", () => Notification.Warning("Warning!"));
Dialog.Confirm("Confirm!", () => Notification.Success("Success!"), () => Notification.Error("Error!"));
Dialog.Prompt("Prompt!", (string input) => Notification.Success("Success: " + input), () => Notification.Error("Error!"));
```
