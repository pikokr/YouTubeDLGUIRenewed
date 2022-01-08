using osu.Framework.Extensions.Color4Extensions;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Sprites;
using osu.Framework.Graphics.UserInterface;
using osuTK.Graphics;

namespace YtdlGui.Game.UI.Components
{
    public class StyledTextBox : BasicTextBox
    {
        public StyledTextBox()
        {
            BackgroundUnfocused = Color4.White.Opacity(0.1f);
            BackgroundFocused = Color4.White.Opacity(0.2f);
            BackgroundCommit = Color4.White.Opacity(0.3f);
            CornerRadius = 5f;
            Masking = true;
        }

        protected override float LeftRightPadding => 10;

        protected override SpriteText CreatePlaceholder()
        {
            return new FadingPlaceholderText
            {
                Colour = Color4.White.Opacity(0.3f),
                Anchor = Anchor.CentreLeft,
                Origin = Anchor.CentreLeft,
                X = CaretWidth,
            };
        }
    }
}
