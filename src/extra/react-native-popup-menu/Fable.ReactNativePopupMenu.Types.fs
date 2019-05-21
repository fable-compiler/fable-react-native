namespace Fable.ReactNativePopupMenu

open Fable.Core.JsInterop
open Fable.React
open Fable.ReactNative.Props

module Props =
    type MenuContextProps =
        | Style of IStyle list

    type MenuProps =
        | Opened of bool

    type MenuTriggerProps =
        | Text of string

    type MenuOptionProps =
        | Value of int
        | Text of string

open Props

module Globals =
    let MenuContext: ReactElementType<MenuContextProps> = importMember "react-native-popup-menu"
    let Menu: ReactElementType<MenuProps> = importDefault "react-native-popup-menu"
    let MenuTrigger: ReactElementType<MenuTriggerProps> = importMember "react-native-popup-menu"
    let MenuOptions: ReactElementType = importMember "react-native-popup-menu"
    let MenuOption: ReactElementType<MenuOptionProps> = importMember "react-native-popup-menu"
