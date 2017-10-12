using MvvmCross.Platform.Plugins;

namespace XamChat.iOS.Bootstrap
{
	//public class FilePluginBootstrap
	//    : NoPreLoadPluginBootstrapAction<MvvmCross.Plugins.File.PluginLoader, MvvmCross.Plugins.File.iOS.Plugin>
	//{
	//}
	public class FilePluginBootstrap
	   : MvxLoaderPluginBootstrapAction<MvvmCross.Plugins.File.PluginLoader, MvvmCross.Plugins.File.iOS.Plugin>
	{
	}
}