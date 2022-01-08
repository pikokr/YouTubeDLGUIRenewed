using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Sprites;
using osu.Framework.Graphics.Textures;
using YtdlGui.Game.Structs;

namespace YtdlGui.Game.UI
{
    [LongRunningLoad]
    public class Thumbnail : Sprite
    {
        private readonly Video video;

        public Thumbnail(Video vid = null)
        {
            video = vid;
            RelativeSizeAxes = Axes.Both;
            FillMode = FillMode.Fit;
            Anchor = Anchor.Centre;
            Origin = Anchor.Centre;
        }

        [BackgroundDependencyLoader]
        private void load(LargeTextureStore textures)
        {
            if (video != null)
            {
                Texture = textures.Get($@"https://i.ytimg.com/vi/{video.Id.Value}/original.jpg");
            }

            Texture ??= textures.Get(@"LoadFailed");
        }

        protected override void LoadComplete()
        {
            base.LoadComplete();
            this.FadeInFromZero(300, Easing.OutQuint);
        }
    }
}
