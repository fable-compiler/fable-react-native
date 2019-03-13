module Fable.Helpers.ReactNativeSimpleStore.KeyValueStore

open Fable.Core.JsInterop
open Fable.Import
open Fable.PowerPack


type RCom = Fable.Import.React.ComponentClass<obj>
let AsyncStorage: RCom = importDefault "@react-native-community/async-storage"

/// Retrieves all keys from the AsyncStorage.
let getAllKeys() : JS.Promise<string []> =
    Promise.create(fun success fail ->
        AsyncStorage?getAllKeys
            (fun err keys ->
                if not (isNull err) && not (isNull (err?message)) then
                    fail (unbox err)
                else
                    success (unbox keys)) |> ignore)
