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
        GetComponent<Button>().onClick.AddListener(()=>Notification.Warning("Seni seviyorum."));   
    }
}
