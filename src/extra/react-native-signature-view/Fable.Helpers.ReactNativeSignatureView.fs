module Fable.Helpers.ReactNativeSignatureView

open Fable.Core
open Fable.Core.JsInterop
open Fable.Import
module RN = Fable.Helpers.ReactNative

module R = Fable.Helpers.React

type RCom = Fable.Import.React.ComponentClass<obj>

type SignatureViewRef() =
    let signatureView = ref None

    /// Sets the internal ref
    member internal __.SetRef (ref: obj) : unit = 
        signaturePad := Some ref

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


let SignatureView: RCom = importDefault "react-native-signature-view"

/// Opens a signature pad with callbacks for onError and onChange
let signatureView (props:Fable.Helpers.ReactNative.Props.IStyle list) (ref:SignatureViewRef) (onSaveEvent:string -> unit) : React.ReactElement =
    let onSaveEvent (o:obj) =
        onSaveEvent(o?savePath |> unbox)
        
    let pad =
        createObj
            [ "style" ==> keyValueList CaseRules.LowerFirst props
              "ref" ==> ref.SetRef
              "onSaveEvent" ==> onSaveEvent ]
        |> unbox

    R.from SignatureView pad []
