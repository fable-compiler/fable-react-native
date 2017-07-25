module Fable.Helpers.ReactNativeSignaturePad

open Fable.Core
open Fable.Core.JsInterop
open Fable.Import
module RN = Fable.Helpers.ReactNative

module R = Fable.Helpers.React

type RCom = Fable.Import.React.ComponentClass<obj>

let SignaturePad: RCom = importDefault "react-native-signature-pad"

/// Opens a signature pad with callbacks for onError and onChange
let signaturePad (props:Fable.Helpers.ReactNative.Props.IStyle list) (onError:exn -> unit) (onChange:string -> unit) : React.ReactElement =
    let onChange (o:obj) = onChange(o?base64DataUrl |> unbox)
    let pad =
        createObj
            [ "style" ==> keyValueList CaseRules.LowerFirst props
              "onError" ==> onError
              "onChange" ==> onChange ]
        |> unbox

    R.from SignaturePad pad []