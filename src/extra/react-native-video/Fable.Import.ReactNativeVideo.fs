namespace Fable.Import

open System
open Fable.Core
open Fable.Import
open Fable.Import.JS
open Fable.Import.Browser

[<Erase>]
module ReactNativeVideo =

    type VideoProperties = 
        inherit React.Props<VideoStatic>
    and VideoStatic =
        inherit React.ComponentClass<VideoProperties>
    and Video =
        abstract member seek: int -> unit
        abstract member presentFullscreenPlayer: unit -> unit
        abstract member dismissFullscreenPlayer: unit -> unit
        inherit VideoStatic        

    type Globals =
        [<Import("default", from="react-native-video")>]
        static member Video with get(): Video = failwith "JS only" and set(v: Video): unit = failwith "JS only"