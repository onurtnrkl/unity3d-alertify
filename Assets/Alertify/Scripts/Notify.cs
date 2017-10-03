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

namespace Alertify
{
    public sealed class Notify : MonoBehaviour
    {
        private Image image;
        private Text text;

        private void Awake()
        {
            image = GetComponent<Image>();
            text = GetComponentInChildren<Text>();
        }

        public void SetColor(Color color)
        {
            image.color = color;
        }

        public void SetText(string text)
        {
            this.text.text = text;
        }

        public void FadeIn()
        {
            gameObject.SetActive(true);
        }

        public void FadeOut()
        {
            gameObject.SetActive(false);
        }
    }
}
