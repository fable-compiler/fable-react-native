namespace Fable.ReactNativeVideo

open Fable.ReactNative.Props

module RN = Fable.ReactNative.Helpers

module Props =
    type VideoSource = { uri : string; mainVer : float; patchVer : float }

    type IVideoProperties =
        interface end

    type VideoProperties =
        | Source of VideoSource
        | Rate of float
        | Volume of float
        | Muted of bool
        | Paused of bool
        | ResizeMode of string
        | Repeat of bool
        | PlayInBackground of bool
        | PlayWhenInactive of bool
        | IgnoreSilentSwitch of string
        | ProgressUpdateInterval of float
        | OnLoadStart of (unit->unit)
        | OnLoad of (unit->unit)
        | OnProgress of (unit->unit)
        | OnEnd of (unit->unit)
        | OnError of (unit->unit)
        | OnBuffer of (unit->unit)
        | OnTimedMetadata of (unit->unit)
        | Style of IStyle list
        | Ref of Ref<Video>
            interface IVideoProperties

open Props
open Fable.React

[<AutoOpen>]
module Helpers =
    let inline video (props:IVideoProperties list) : ReactElement =
        RN.createElement(Globals.Video, props, [])