namespace Fable.ReactNativeImageResizer.Types

open Fable.Core

type ImageResizer =
    abstract member createResizedImage: string -> int -> int -> string -> float -> float -> string -> Fable.Core.JS.Promise<obj>

type Globals =
    [<Import("default", from="react-native-image-resizer")>]
    static member ImageResizer with get(): ImageResizer = failwith "JS only" and set(v: ImageResizer): unit = failwith "JS only"