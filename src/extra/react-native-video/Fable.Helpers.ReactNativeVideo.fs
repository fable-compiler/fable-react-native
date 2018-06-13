module Fable.Helpers.ReactNativeVideo

open System
open Fable.Core
open Fable.Core.JsInterop
open Fable.Import
open Fable.Import.ReactNativeVideo
module RN = Fable.Helpers.ReactNative
type RNV = ReactNativeVideo.Globals

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
        | Style of RN.Props.IStyle list
        | Ref of RN.Ref<Video>
            interface IVideoProperties

open Props

let inline video (props:IVideoProperties list) : React.ReactElement =
    RN.createElement(
      RNV.Video,
        props, [])