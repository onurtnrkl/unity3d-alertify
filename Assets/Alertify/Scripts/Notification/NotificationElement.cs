using UnityEngine;
using UnityEngine.UI;

namespace Alertify
{
    public sealed class NotificationElement : Element
    {
        [SerializeField] private Image image;
        [SerializeField] private Text text;

        public void SetColor(Color color)
        {
            image.color = color;
        }

        public void SetText(string text)
        {
            this.text.text = text;
        }
    }
}
