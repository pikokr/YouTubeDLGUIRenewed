using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Shapes;
using osu.Framework.Graphics.Sprites;
using osu.Framework.Input.Events;
using osuTK.Graphics;

namespace YtdlGui.Game.UI.Sidebar
{
    public class DefaultButton : ClickableContainer
    {
        protected readonly Box Background;
        protected readonly SpriteText Text;

        protected float InactiveOpacity = 0.4f;
        protected float ActiveOpacity = 0.6f;

        public DefaultButton()
        {
            RelativeSizeAxes = Axes.X;
            Height = 30;
            CornerRadius = 5;
            Masking = true;

            InternalChildren = new Drawable[]
            {
                Background = new Box
                {
                    RelativeSizeAxes = Axes.Both,
                    Colour = Color4.White,
                    Alpha = InactiveOpacity
                },
                new Container
                {
                    RelativeSizeAxes = Axes.Both,
                    Children = new Drawable[]
                    {
                        Text = new SpriteText
                        {
                            Origin = Anchor.Centre,
                            Anchor = Anchor.Centre,
                        }
                    }
                }
            };
        }

        protected override bool OnHover(HoverEvent e)
        {
            Background.FadeTo(ActiveOpacity, 200, Easing.OutQuint);
            return base.OnHover(e);
        }

        protected override void OnHoverLost(HoverLostEvent e)
        {
            Background.FadeTo(InactiveOpacity, 200, Easing.OutQuint);
        }
    }
}
