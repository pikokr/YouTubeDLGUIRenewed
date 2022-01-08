using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Textures;
using osu.Framework.IO.Stores;
using osuTK;
using YoutubeExplode;
using YTDL.Resources;

namespace YtdlGui.Game
{
    public class YtdlGameBase : osu.Framework.Game
    {
        private DependencyContainer dependencies;

        protected override IReadOnlyDependencyContainer CreateChildDependencies(IReadOnlyDependencyContainer parent) => dependencies = new DependencyContainer(base.CreateChildDependencies(parent));

        protected override Container<Drawable> Content { get; }

        protected YtdlGameBase()
        {
            // Ensure game and tests scale with window size and screen DPI.
            base.Content.Add(Content = new DrawSizePreservingFillContainer
            {
                // You may want to change TargetDrawSize to your "default" resolution, which will decide how things scale and position when using absolute coordinates.
                TargetDrawSize = new Vector2(1280, 720)
            });
        }

        [BackgroundDependencyLoader]
        private void load()
        {
            var dllStore = new DllResourceStore(typeof(YtdlResources).Assembly);
            Resources.AddStore(dllStore);

            var largeStore = new LargeTextureStore(Host.CreateTextureLoaderStore(new NamespacedResourceStore<byte[]>(Resources, @"Textures")));
            largeStore.AddStore(Host.CreateTextureLoaderStore(new OnlineStore()));
            dependencies.Cache(largeStore);

            dependencies.Cache(new YoutubeClient());

            AddFont(Resources, @"Fonts/NanumSquareRound");
            AddFont(Resources, @"Fonts/NanumSquareRound-Light");
            AddFont(Resources, @"Fonts/NanumSquareRound-Bold");
        }
    }
}
