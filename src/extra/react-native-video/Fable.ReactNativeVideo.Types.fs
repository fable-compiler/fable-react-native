namespace Fable.ReactNativeVideo

open Fable.Core
open Fable.Core.JsInterop
open Fable.React
open Fable.ReactNative.Props

type VideoProps = 
    | Style of IStyle list

and Video =
    abstract member seek: int -> unit
    abstract member presentFullscreenPlayer: unit -> unit
    abstract member dismissFullscreenPlayer: unit -> unit

module Globals =
    let Video: ReactElementType<VideoProps> = importDefault "react-native-video"