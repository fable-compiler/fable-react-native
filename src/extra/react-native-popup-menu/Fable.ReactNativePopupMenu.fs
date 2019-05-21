namespace Fable.ReactNativePopupMenu

open Fable.Core.JsInterop
open Fable.React
open Fable.ReactNative
module RN = Fable.ReactNative.Helpers

open Fable.ReactNativePopupMenu.Props
module BPM = Fable.ReactNativePopupMenu.Globals

[<AutoOpen>]
module Helpers =
    /// Creates a MenuContext element
    let inline menuContext (props: MenuContextProps list) (onBackdropPress: unit -> unit) (children: ReactElement seq): ReactElement =
        RN.createElementWithBaseProps(BPM.MenuContext, ["onBackdropPress" ==> onBackdropPress], props, children)

    /// Creates a Menu element
    let inline menu (props: MenuProps list) (onSelect: obj -> unit) (children: ReactElement seq): ReactElement =
        RN.createElementWithBaseProps(BPM.Menu, ["onSelect" ==> onSelect], props, children)

    /// Creates a MenuTrigger element
    let inline menuTrigger (props: MenuTriggerProps list) (onPress: unit -> unit) (children: ReactElement seq): ReactElement =
        RN.createElementWithBaseProps(BPM.MenuTrigger, ["onPress" ==> onPress], props, children)

    /// Creates a MenuOptions element
    let inline menuOptions (props: obj) (children: ReactElement seq): ReactElement =
        RN.createElementWithObjProps(BPM.MenuOptions, props, children)

    /// Creates a MenuOption element
    let inline menuOption (props: MenuOptionProps list) : ReactElement =
        RN.createElement(BPM.MenuOption, props, [])
