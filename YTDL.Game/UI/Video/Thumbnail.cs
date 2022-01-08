using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Sprites;
using osu.Framework.Graphics.Textures;
using YtdlGui.Game.Structs;

namespace YtdlGui.Game.UI.Video
{
    [LongRunningLoad]
    public class Thumbnail : Sprite
    {
        private readonly VideoItem video;

        public Thumbnail(VideoItem vid = null)
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
                Texture = textures.Get($@"https://i.ytimg.com/vi/{video.Video.Id.Value}/original.jpg");
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
