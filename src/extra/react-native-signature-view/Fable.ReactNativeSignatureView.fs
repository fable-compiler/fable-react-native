namespace Fable.ReactNativeSignatureView

open Fable.Core
open Fable.Core.JsInterop
open Fable.React
open Fable.ReactNative
open Fable.ReactNative.Props

type SignatureViewRef() =
    let signatureView = ref None

    /// Sets the internal ref
    member internal __.SetRef (ref: obj) : unit = 
        signatureView := Some ref

    /// Resets the signature
    member __.Reset() = 
        match !signatureView with
        | Some v -> v?_resetSignature() |> ignore
        | _ -> ()

    /// Saves the signature to the local drive.
    member __.Save() = 
        match !signatureView with
        | Some v -> v?_saveSignature() |> ignore
        | _ -> ()

[<AutoOpen>]
module Helpers =

    /// Opens a signature pad with callbacks for onError and onChange
    let signatureView (props:IStyle list) (ref:SignatureViewRef) (onSaveEvent:string -> unit) : ReactElement =
        let onSaveEvent (o:obj) =
            onSaveEvent(o?savePath |> unbox)
            
        let pad =
            createObj
                [ "style" ==> keyValueList CaseRules.LowerFirst props
                  "ref" ==> ref.SetRef
                  "onSaveEvent" ==> onSaveEvent ]
            |> unbox

        ofImport "default" "react-native-signature-view" pad []
