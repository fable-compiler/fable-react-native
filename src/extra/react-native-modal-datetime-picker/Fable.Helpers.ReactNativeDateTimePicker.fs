module Fable.Helpers.ReactNativeDateTimePicker

open System
open Fable.Core
open Fable.Core.JsInterop
open Fable.Import
module RN = Fable.Helpers.ReactNative

module R = Fable.Helpers.React

type RCom = Fable.Import.React.ComponentClass<obj>

[<RequireQualifiedAccess>]
type DateTimePickerMode =
| Date
| Time
| DateTime

let DateTimePicker : RCom = importDefault "react-native-modal-datetime-picker"

/// Creates a DateTime picker
let dateTimePicker 
    (props:Fable.Helpers.ReactNative.Props.IStyle list)
    (visible:bool)
    mode
    (initialDate:DateTime)
    (dateChangedF: DateTime -> unit)
    (cancelledF: unit -> unit) : React.ReactElement =
    let settings =
        createObj
            ["onConfirm" ==> dateChangedF
             "onCancel" ==> cancelledF
             "date" ==> initialDate.Date
             "mode" ==> 
                match mode with 
                | DateTimePickerMode.Date -> "date"
                | DateTimePickerMode.Time -> "time"
                | DateTimePickerMode.DateTime -> "datetime"
                
             "isVisible" ==> visible ]
        |> unbox

    R.from DateTimePicker settings []
