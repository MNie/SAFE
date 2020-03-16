namespace SAFE.Plugin.Template.Runner

open SAFE
open SAFE.Core

#if (server)
    module Server =
        type Safe.Plugin.Template ()
            inherit SAFEPlugin()
            interface ISAFEServerPlugin
#elif (client)
    module Client =
        type Safe.Plugin.Template ()
            inherit SAFEPlugin()
            interface ISAFEClientPlugin
#elif (shared)
    module Shared =
        type Safe.Plugin.Template ()
            inherit SAFEPlugin()
            interface ISAFESharedPlugin
#endif