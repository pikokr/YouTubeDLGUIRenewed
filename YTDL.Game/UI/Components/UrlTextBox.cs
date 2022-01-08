using System;

namespace YtdlGui.Game.UI.Components
{
    public class UrlTextBox : StyledTextBox
    {
        public Action Action;

        protected override void OnTextCommitted(bool textChanged)
        {
            base.OnTextCommitted(textChanged);
            Action();
        }
    }
}
