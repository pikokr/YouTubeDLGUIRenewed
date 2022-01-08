using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Shapes;
using osu.Framework.Graphics.Sprites;
using osu.Framework.Graphics.Textures;
using osu.Framework.Input.Events;
using osuTK.Graphics;

namespace YtdlGui.Game.UI.Components
{
    public class ListActionButton : ClickableContainer
    {
        protected readonly Box Background;
        protected readonly Sprite Icon;

        protected float InactiveOpacity = 0.4f;
        protected float ActiveOpacity = 0.6f;

        public ListActionButton()
        {
            Width = 30;
            Height = 30;
            Anchor = Anchor.CentreRight;
            Origin = Anchor.CentreRight;
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
                        Icon = new Sprite
                        {
                            Origin = Anchor.Centre,
                            Anchor = Anchor.Centre,
                            Width = 20,
                            Height = 20
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

    public class DeleteVideoButton : ListActionButton
    {
        private readonly VideoListItem item;

        public DeleteVideoButton(VideoListItem listItem)
        {
            item = listItem;
        }

        protected override bool OnClick(ClickEvent e)
        {
            item.ListContainer.Items.Remove(item.Item);
            return base.OnClick(e);
        }

        [BackgroundDependencyLoader]
        private void load(TextureStore textures)
        {
            InactiveOpacity = 0.6f;
            ActiveOpacity = 0.8f;
            Background.Colour = Color4.Red;
            Background.Alpha = InactiveOpacity;
            Icon.Texture = textures.Get(@"Icons/delete");
        }
    }
}
