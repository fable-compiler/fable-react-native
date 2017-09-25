module Fable.Helpers.ReactNativeCamera

open System
open Fable.Core
open Fable.Core.JsInterop
open Fable.Import
open Fable.Import.ReactNativeVideo
module RN = Fable.Helpers.ReactNative

open Fable.Import.Browser
open Fable.PowerPack


open Fable.Core.JsInterop

module RN = Fable.Helpers.ReactNative

module R = Fable.Helpers.React

type RCom = Fable.Import.React.ComponentClass<obj>

module Props =

    [<RequireQualifiedAccess>]
    type CameraStyle =
        | Flex of float

    type ICameraProperties =
        interface end

    [<RequireQualifiedAccess>]
    type CameraProperties =
    | Style of CameraStyle list
        interface ICameraProperties


let Camera: RCom = importDefault "react-native-camera"

open Props

type Barcode =
    abstract data: string with get, set
    abstract ``type``: string with get, set

type CameraRef() =
    let cameraRef = ref None

    /// Sets the internal ref
    member internal __.SetRef (ref: obj) : unit = 
        cameraRef := Some ref


    /// Take a picture
    member __.Capture() = 
        
        match !cameraRef with
        | Some v -> 
            promise {
                let! data = unbox(v?capture())
                return data
            }
        | _ -> promise { return! failwith "Camera not initialized!" }


// Allows barcode reading
let barcodeScanner (props:ICameraProperties list) (ref:CameraRef) (onBarcodeRead: Barcode -> unit) (children: React.ReactElement list) : React.ReactElement =
    let additionalProps =
        createObj [
            "onBarCodeRead" ==> onBarcodeRead 
            "ref" ==> ref.SetRef]

    let props =
        !!JS.Object.assign(
            additionalProps,
            keyValueList CaseRules.LowerFirst props)

    R.from Camera props children
