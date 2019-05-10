namespace Fable.ReactNativeImagePicker

open Fable.Core
open Fable.Core.JsInterop
open Fable.ReactNativeImagePicker.Types
type IP = Fable.ReactNativeImagePicker.Types.Globals

module Props =
    type IImagePickerOptions =
        interface end

    type ImagePickerOptions =
    | Title of string
    | CancelButtonTitle of string
    | TakePhotoButtonTitle of string
    | ChooseFromLibraryButtonTitle of string
    | CameraType of CameraType
    | MediaType of MediaType
    | MaxWidth of int
    | MaxHeight of int
    | Quality of float
    | VideoQuality of VideoQuality
    | DurationLimit of int
    | Rotation of int
    | AllowsEditing of bool
    | NoData of bool
    | StorageOptions of StorageOptions
        interface IImagePickerOptions

open Props

[<AutoOpen>]
module Helpers =
    let inline showImagePicker (props: IImagePickerOptions list) f =
        IP.ImagePicker.showImagePicker(!!(keyValueList CaseRules.LowerFirst props), f)

    let showImagePickerAsync (props: IImagePickerOptions list) =
        Promise.create(fun onSuccess onError ->
            showImagePicker
                props
                (fun result ->
                    if not result.didCancel then
                        if System.String.IsNullOrEmpty result.error then
                            onSuccess (Some result.uri)
                        else
                            onError (System.Exception result.error)
                    else onSuccess None)
        )

    let inline launchCamera (props: IImagePickerOptions list) f =
        IP.ImagePicker.launchCamera(!!(keyValueList CaseRules.LowerFirst props), f)

    let launchCameraAsync (props: IImagePickerOptions list) =
        Promise.create(fun onSuccess onError ->
            launchCamera
                props
                (fun result ->
                    if not result.didCancel then
                        if System.String.IsNullOrEmpty result.error then
                            onSuccess (Some result.uri)
                        else
                            onError (System.Exception result.error)
                    else onSuccess None)
        )

    let inline launchImageLibrary (props: IImagePickerOptions list) f =
        IP.ImagePicker.launchImageLibrary(!!(keyValueList CaseRules.LowerFirst props), f)
        
    let launchImageLibraryAsync (props: IImagePickerOptions list) =
        Promise.create(fun onSuccess onError ->
            launchImageLibrary
                props
                (fun result ->
                    if not result.didCancel then
                        if System.String.IsNullOrEmpty result.error then
                            onSuccess (Some result.uri)
                        else
                            onError (System.Exception result.error)
                    else onSuccess None)
        )
