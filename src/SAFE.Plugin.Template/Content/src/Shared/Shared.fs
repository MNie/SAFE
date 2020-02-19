namespace SAFE.PluginName

open SAFE
open SAFE.Core

#if (target = "server")
namespace SAFE.PluginName.Server =
    type PluginName ()
        inherit SAFEPlugin()
        interface ISAFEServerPlugin
#elif (target = "client")
    namespace SAFE.PluginName.Client =
        type PluginName ()
            inherit SAFEPlugin()
            interface ISAFEClientPlugin
#else
    namespace SAFE.PluginName.Shared =
        type PluginName ()
            inherit SAFEPlugin()
            interface ISAFESharedPlugin
#endif