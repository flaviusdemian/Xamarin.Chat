using MvvmCross.Platform.Plugins;

namespace XamChat.iOS
{
    public class NoPreLoadPluginBootstrapAction<TPlugin, TPlatformPlugin> : MvxLoaderPluginBootstrapAction<TPlugin, TPlatformPlugin> where TPlugin : IMvxPluginLoader where TPlatformPlugin : IMvxPlugin
    {
        protected override void PreLoad(IMvxPluginManager manager)
        {
            // do nothing;
        }
    }
}
