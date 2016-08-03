using MvvmCross.Platform.Plugins;

namespace XamChat.iOS.Bootstrap
{
    public class DownloadCachePluginBootstrap
        : MvxLoaderPluginBootstrapAction<MvvmCross.Plugins.DownloadCache.PluginLoader, MvvmCross.Plugins.DownloadCache.iOS.Plugin>
    {
        protected override void Load(IMvxPluginManager manager)
        {
            MvvmCross.Plugins.File.PluginLoader.Instance.EnsureLoaded();
            base.Load(manager);
        }
    }
}