using System;
using osu.Framework.Input.Events;

namespace YtdlGui.Game.UI.Sidebar
{
    public class VideoAddButton : DefaultButton
    {
        private readonly Action action;

        public VideoAddButton(Action commitAction)
        {
            action = commitAction;
            Text.Text = "추가하기";
        }

        protected override bool OnClick(ClickEvent e)
        {
            action();
            return base.OnClick(e);
        }
    }
}
