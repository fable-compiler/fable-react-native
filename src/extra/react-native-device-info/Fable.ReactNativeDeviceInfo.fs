namespace Fable.Helpers.ReactNativeDeviceInfo
open Fable.Core.JsInterop

[<AutoOpen>]
module Helpers =

    let private deviceInfo: obj = importDefault "react-native-device-info"

    /// Gets the API level.
    let getAPILevel () : int =
        deviceInfo?getAPILevel() |> unbox


    /// Gets the application name.
    let getApplicationName () : string =
        deviceInfo?getApplicationName() |> unbox

    /// Gets the device brand.
    let getBrand () : string =
        deviceInfo?getBrand() |> unbox

    /// Gets the application build number.
    /// Note: There is a type inconsistency: Android return an integer instead of the documented string.
    let getBuildNumber () : string =
        deviceInfo?getBuildNumber() |> unbox


    /// Gets the application bundle identifier.
    let getBundleId () : string =
        deviceInfo?getBundleId() |> unbox


    /// Gets the carrier name (network operator).
    let getCarrier () : string =
        deviceInfo?getCarrier() |> unbox


    /// Gets the device country based on the locale information.
    let getDeviceCountry () : string =
        deviceInfo?getDeviceCountry() |> unbox


    /// Gets the device ID.
    let getDeviceId () : string =
        deviceInfo?getDeviceId() |> unbox

    /// Gets the device locale.
    let getDeviceLocale () : string =
        deviceInfo?getDeviceLocale() |> unbox

    /// Gets the device name.
    let getDeviceName () : string =
        deviceInfo?getDeviceName() |> unbox

    /// Gets the time at which the app was first installed, in milliseconds.
    let getFirstInstallTime () : int64 =
        deviceInfo?getFirstInstallTime() |> unbox

    /// Gets the device font scale. 
    /// The font scale is the ratio of the current system font to the "normal" font size, 
    /// so if normal text is 10pt and the system font is currently 15pt, the font scale would be 1.5
    /// This can be used to determine if accessability settings has been changed for the device; 
    /// you may want to re-layout certain views if the font scale is significantly larger ( > 2.0 )
    let getFontScale () : float =
        deviceInfo?getFontScale() |> unbox


    /// Gets available storage size, in bytes.
    let getFreeDiskStorage () : int64 =
        deviceInfo?getFreeDiskStorage() |> unbox

    /// Gets the device current IP address.
    ///
    /// Needs android.permission.ACCESS_WIFI_STATE
    let getIPAddress () : string =
        deviceInfo?getIPAddress() |> unbox

    /// Gets the application instance ID.
    /// See https://developers.google.com/instance-id/
    let getInstanceID () : string =
        deviceInfo?getInstanceID() |> unbox

    /// Gets the time at which the app was last updated, in milliseconds.
    let getLastUpdateTime () : int64 =
        deviceInfo?getLastUpdateTime() |> unbox

    /// Gets the network adapter MAC address.
    ///
    /// Needs android.permission.ACCESS_WIFI_STATE
    let getMACAddress () : string =
        deviceInfo?getMACAddress() |> unbox

    /// Gets the device manufacturer.
    let getManufacturer () : string =
        deviceInfo?getManufacturer() |> unbox

    /// Returns the maximum amount of memory that the JVM will attempt to use, in bytes.
    let getMaxMemory () : int64 =
        deviceInfo?getMaxMemory() |> unbox

    /// Gets the device model.
    let getModel () : string =
        deviceInfo?getModel() |> unbox


    /// Gets the device phone number.
    ///
    /// Needs android.permission.READ_PHONE_STATE
    let getPhoneNumber () : string =
        deviceInfo?getPhoneNumber() |> unbox

    /// Gets the application human readable version.
    let getReadableVersion () : string =
        deviceInfo?getReadableVersion() |> unbox

    /// Gets the device serial number.
    let getSerialNumber () : string =
        deviceInfo?getSerialNumber() |> unbox

    /// Gets the device OS name.
    let getSystemName () : string =
        deviceInfo?getSystemName() |> unbox

    /// Gets the device OS version.
    let getSystemVersion () : string =
        deviceInfo?getSystemVersion() |> unbox


    /// Gets the device default timezone.
    let getTimezone () : string =
        deviceInfo?getTimezone() |> unbox

    /// Gets full disk storage size, in bytes.
    let getTotalDiskCapacity () : int64 =
        deviceInfo?getTotalDiskCapacity() |> unbox

    /// Gets the device total memory, in bytes.
    let getTotalMemory () : int64 =
        deviceInfo?getTotalMemory() |> unbox

    /// Gets the device unique ID.
    let getUniqueID () : string =
        deviceInfo?getUniqueID() |> unbox


    /// Gets the device User Agent.
    let getUserAgent () : string =
        deviceInfo?getUserAgent() |> unbox


    /// Gets the application version.
    let getVersion () : string =
        deviceInfo?getVersion() |> unbox

    /// Tells if the user preference is set to 24-hour format.
    let is24Hour () : bool =
        deviceInfo?is24Hour() |> unbox

    /// Tells if the application is running in an emulator.
    let isEmulator () : bool =
        deviceInfo?isEmulator() |> unbox

    /// Tells if a PIN number or a fingerprint was set for the device.
    let isPinOrFingerprintSet (callback: bool -> unit) : unit =
        deviceInfo?isPinOrFingerprintSet(callback) |> unbox

    /// Tells if the device is a tablet.
    let isTablet () : bool =
        deviceInfo?isTablet() |> unbox
