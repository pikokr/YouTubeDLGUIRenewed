using osu.Framework.Bindables;

namespace YtdlGui.Game.Structs
{
    public class Video
    {
        public Bindable<string> Title = new("Title");
        public Bindable<string> Creator = new("Creator");
    }
}
