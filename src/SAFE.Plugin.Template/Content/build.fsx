open System.IO
#r "paket: groupref build //"
#load "./.fake/build.fsx/intellisense.fsx"

#if !FAKE
#r "netstandard"
#r "Facades/netstandard" // https://github.com/ionide/ionide-vscode-fsharp/issues/839#issuecomment-396296095
#endif

open System

open Fake.Core
open Fake.DotNet
open Fake.IO
open Fake.Tools

//Target.create "Clean" (fun _ ->
    //Git.CommandHelper.directRunGitCommandAndFail "." "clean -fxd"
//)

Target.create "Build" (fun _ ->
    let projects =
        DirectoryInfo(__SOURCE_DIRECTORY__).GetDirectories "src"
        |> Array.tryHead
        |> fun src ->
            match src with
            | Some dir -> DirectoryInfo.getMatchingFilesRecursive "*.fsproj" dir
            | None -> [||]

    projects
    |> Array.iter (fun proj ->
        let result = DotNet.exec (fun x -> { x with DotNetCliPath = "dotnet" }) "build" proj.FullName
        if not result.OK then failwithf "`dotnet build %s failed with %O" proj.Name result
    )
)

open Fake.Core.TargetOperators

"Build"

Target.runOrDefaultWithArguments "Build"
