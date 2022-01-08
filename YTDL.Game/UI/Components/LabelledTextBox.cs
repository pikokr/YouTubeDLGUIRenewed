using osu.Framework.Graphics.Containers;
using osu.Framework.Localisation;

namespace YtdlGui.Game.UI.Components
{
    public class LabelledTextBox : FillFlowContainer
    {
        public LabelledTextBox(StyledTextBox textBox, LocalisableString label)
        {
            AddInternal(textBox);
        }
    }
}
