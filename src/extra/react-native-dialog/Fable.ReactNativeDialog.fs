namespace Fable.ReactNativeDialog

open Fable.Core
open Fable.Core.JsInterop
open Fable.React
open Fable.ReactNative.Props

type IButtonProperties =
    interface end

[<RequireQualifiedAccess>]
type ButtonProperties =
    | Label of string
    | Disabled of bool
    | OnPress of (unit -> unit)
    | Color of string
        interface IButtonProperties

type IInputProperties =
    interface end

[<RequireQualifiedAccess>]
type InputProperties =
    | Label of string
    | OnChangeText of (string -> unit)
    | Value of string
    | Ref of (obj -> unit)
        interface IInputProperties
        static member WrapperStyle (style: IStyle list) : IInputProperties = !!("wrapperStyle", keyValueList CaseRules.LowerFirst style)

type IContainerProperties =
    interface end

[<RequireQualifiedAccess>]
type ContainerProperties =
    | Visible of bool
        interface IContainerProperties
        static member ContentStyle (style: IStyle list) : IContainerProperties = !!("contentStyle", keyValueList CaseRules.LowerFirst style)
        static member HeaderStyle (style: IStyle list) : IContainerProperties = !!("headerStyle", keyValueList CaseRules.LowerFirst style)
        static member FooterStyle (style: IStyle list) : IContainerProperties = !!("footerStyle", keyValueList CaseRules.LowerFirst style)
        static member ButtonSeparatorStyle (style: IStyle list) : IContainerProperties = !!("buttonSeparatorStyle", keyValueList CaseRules.LowerFirst style)

type IExports =
    abstract Title : ReactElementType<obj>
    abstract Description : ReactElementType<obj>
    abstract Container : ReactElementType<obj>
    abstract Button : ReactElementType<obj>
    abstract Input : ReactElementType<obj>

[<AutoOpen>]
module Helpers =
    let Dialog : IExports = import "default" "react-native-dialog"

    let title (text:string) : ReactElement =
        let title =
            createObj [ ]
            |> unbox
        ReactElementType.create Dialog.Title title [ str text ]

    let description (text:string) : ReactElement =
        let description =
            createObj [ ]
            |> unbox
        ReactElementType.create Dialog.Description description [ str text ]

    let button (props:IButtonProperties list) : ReactElement =
        ReactElementType.create Dialog.Button (keyValueList CaseRules.LowerFirst props) []

    let input (props:IInputProperties list) : ReactElement =
        ReactElementType.create Dialog.Input (keyValueList CaseRules.LowerFirst props) []

    let container (props:IContainerProperties list) (children) : ReactElement =
        ReactElementType.create Dialog.Container (keyValueList CaseRules.LowerFirst props) children