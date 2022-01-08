using osu.Framework.Bindables;

namespace YtdlGui.Game.Structs
{
    public class Video
    {
        public Bindable<string> Id = new("0000000000");
        public Bindable<string> Title = new("Title");
        public Bindable<string> Creator = new("Creator");
    }
}
