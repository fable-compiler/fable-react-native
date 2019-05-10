namespace Fable.ReactNativeDateTimePicker

open System
open Fable.Core.JsInterop
open Fable.ReactNative.Props
open Fable.React

[<AutoOpen>]
module Helpers =

    [<RequireQualifiedAccess>]
    type DateTimePickerMode =
    | Date
    | Time
    | DateTime


    /// Creates a DateTime picker
    let dateTimePicker 
        (props:IStyle list)
        (visible:bool)
        mode
        (initialDate:DateTime)
        (dateChangedF: DateTime -> unit)
        (cancelledF: unit -> unit) : ReactElement =
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

        ofImport "default" "react-native-modal-datetime-picker" settings []
