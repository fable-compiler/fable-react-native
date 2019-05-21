namespace Fable.ReactNativePushNotification

open Fable.Core

type PushNotification =
    abstract member configure: PushNotificationOptions -> unit

and PushNotificationOptions =
    abstract onRegister: obj -> unit

type Globals =
    [<Import("default", from="react-native-push-notification")>]
    static member PushNotification with get(): PushNotification = failwith "JS only" and set(v: PushNotification): unit = failwith "JS only"