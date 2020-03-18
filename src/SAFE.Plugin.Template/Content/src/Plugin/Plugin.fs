namespace SAFE.SAFE.Plugin.Template

open SAFE
open SAFE.Core

    module Server =
        type SAFE.Plugin.Template () =
            inherit SAFEPlugin()
#if (server)
            interface ISAFEServerPlugin
#elif (client)
            interface ISAFEClientPlugin
#elif (shared)
            interface ISAFESharedPlugin
#endif