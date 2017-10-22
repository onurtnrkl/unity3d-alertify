#region License
/*================================================================
Product:    #PRODUCTNAME#
Developer:  #DEVELOPERNAME#
Date:       #DATE#

Copyright (c) #YEAR# #COMPANYNAME#. All rights reserved.
================================================================*/
#endregion

using UnityEngine;
using UnityEngine.UI;
using Alertify;

public class Test : MonoBehaviour
{
    private void Awake()
    {
        GetComponent<Button>().onClick.AddListener(OnClickButton);   
    }

    private void OnClickButton()
    {
        Dialog.Prompt("Yazı gir buraya!",
                      OnClickOk,
                      () => Notification.Error("Error!")
                     );
    }

    private void OnClickOk(string input)
    {
        Notification.Success("Success: " + input);
    }
}
