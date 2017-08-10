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
        | OnLoadStart of Func<unit, unit>
        | OnLoad of Func<unit, unit>
        | OnProgress of Func<unit, unit>
        | OnEnd of Func<unit, unit>
        | OnError of Func<unit, unit>
        | OnBuffer of Func<unit, unit>
        | OnTimedMetadata of Func<unit, unit>
        | Style of RN.Props.IStyle list
        | Ref of RN.Ref<Video>
            interface IVideoProperties

open Props

let inline video (props:IVideoProperties list) : React.ReactElement =
    RN.createElement(
      RNV.Video,
        !!JS.Object.assign(keyValueList CaseRules.LowerFirst props), [])

let inline seek (i: int) =
    RNV.Video.seek(i)

let inline presentFullscreenPlayer () =
    RNV.Video.presentFullscreenPlayer ()

let inline launchImageLibrary () =
    RNV.Video.dismissFullscreenPlayer ()