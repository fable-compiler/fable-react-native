namespace Fable.ReactNativeFileSystem

open System
open Fable.Core.JsInterop
open Fable.Core
open Fable.Import

[<AutoOpen>]
module Helpers =
    
    [<Import("default","react-native-fs")>]
    let private fileSystem = obj()

    /// Result of the <c>stat</c> function.
    type IStatResult =
        /// The same as the <c>uri</c> parameter of the <c>stat</c> function.
        [<Emit("$0.path")>]
        abstract Path: string

        /// Creation timestamp of the item.
        [<Emit("$0.ctime")>]
        abstract Ctime: DateTime

        /// Modification timestamp of the item.
        [<Emit("$0.mtime")>]
        abstract Mtime: DateTime

        /// Size of the item in bytes.
        [<Emit("$0.size")>]
        abstract Size: uint32

        /// UNIX filemode of the item.
        [<Emit("$0.mode")>]
        abstract Mode: uint32

        /// Android: in case of a content URI this is the pointed path, the same as <c>Path</c> otherwise.
        [<Emit("$0.originalFilepath")>]
        abstract OriginalFilepath: string

        /// Check if item is a file.
        [<Emit("$0.isFile")>]
        abstract IsFile: unit -> bool

        /// Check if item is a directory.
        [<Emit("$0.isDirectory")>]
        abstract IsDirectory: unit -> bool

    /// Delete a single file or a directory recursively.
    let deleteFile (uri:string) : unit = fileSystem?unlink(uri) |> ignore

    /// Get content of file in Base64 encoding.
    let getBase64File (uri:string) : JS.Promise<string> = fileSystem?readFile(uri,"base64") |> unbox

    /// Stat the item at <c>uri</c>.
    let stat (uri: string): JS.Promise<IStatResult> = fileSystem?stat uri