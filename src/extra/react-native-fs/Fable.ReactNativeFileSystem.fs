namespace Fable.ReactNativeFileSystem

open Fable.Core.JsInterop
open Fable.Core
open Fable.Import

[<AutoOpen>]
module Helpers =

    [<Import("default","react-native-fs")>]
    let private fileSystem = obj()

    let deleteFile (uri:string) : unit = fileSystem?unlink(uri) |> ignore

    let getBase64File (uri:string) : JS.Promise<string> = fileSystem?readFile(uri,"base64") |> unbox
