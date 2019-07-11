namespace Fable.ReactNativeMaps

open Fable.Core
open Fable.Core.JsInterop
open Fable.ReactNative.Props
open Fable.React.Helpers
open Fable.React

type Region =
    class end
    with

        static member Create(latitude:float,longitude:float,latitudeDelta:float,longitudeDelta:float) : Region =
            createObj
                [ "latitude" ==> latitude
                  "longitude" ==> longitude
                  "latitudeDelta" ==> latitudeDelta
                  "longitudeDelta" ==> longitudeDelta ]
            |> unbox

        static member Create(latitude:float,longitude:float) : Region =
            Region.Create(latitude, longitude, 0.0922, 0.0421)

type IMapViewProperties =
    interface end

[<RequireQualifiedAccess>]
type MapViewProperties =
    | Ref of (obj -> unit)
    | Provider of string
    | ShowsUserLocation of bool
    | UserLocationAnnotationTitle of string
    | FollowsUserLocation of bool
    | ShowsMyLocationButton of bool
    | ShowsPointsOfInterest of bool
    | ShowsCompass of bool
    | ShowsScale of bool
    | ShowsBuildings of bool
    | ShowsTraffic of bool
    | ShowsIndoors of bool
    | ShowsIndoorLevelPicker of bool
    | ZoomEnabled of bool
    | ZoomControlEnabled of bool
    | MinZoomLevel of int
    | MaxZoomLevel of int
    | RotateEnabled of bool
    | ScrollEnabled of bool
    | PitchEnabled of bool
    | ToolbarEnabled of bool
    | CacheEnabled of bool
    | LoadingEnabled of bool
    | LoadingIndicatorColor of string
    | LoadingBackgroundColor of string
    | MoveOnMarkerPress of bool
    | Region of Region
    | InitialRegion of Region
        interface IMapViewProperties

        static member Style (style: IStyle list) : IMapViewProperties = !!("style", keyValueList CaseRules.LowerFirst style)

type MapRef(mapRef) =
    member __.fitToElements(animated:bool) : unit =
        if not (isNull mapRef) then
            mapRef?fitToElements(animated) |> ignore

type GeoCoordinates =
    abstract latitude: float with get, set
    abstract longitude: float with get, set

type Point =
    abstract x: float with get, set
    abstract y: float with get, set

type DragPosition =
    abstract coordinate: GeoCoordinates with get, set
    abstract posiiton: Point with get, set

type ICalloutProperties =
    interface end

[<RequireQualifiedAccess>]
type CalloutProperties =
    | Key of string
    | Tooltip of bool
    | OnPress of (unit -> unit)
        interface ICalloutProperties

type ICircleProperties =
    interface end

[<RequireQualifiedAccess>]
type CircleProperties =
    | Key of string
    | Center of GeoCoordinates
    | Radius of float
    | FillColor of string
        interface ICircleProperties

[<RequireQualifiedAccess>]
type MarkerColor =
    | Red
    | Tomato
    | Orange
    | Yellow
    | Gold
    | Wheat
    | Tan
    | Linen
    | Green
    | Blue
    | Aqua
    | Violet
    | Indigo
    with
        override this.ToString() =
            match this with
            | Red -> "red"
            | Tomato -> "tomato"
            | Orange -> "orange"
            | Yellow -> "yellow"
            | Gold -> "golf"
            | Wheat -> "wheat"
            | Tan -> "tan"
            | Linen -> "linen"
            | Green -> "green"
            | Blue -> "blue"
            | Aqua -> "aqua"
            | Violet -> "violet"
            | Indigo -> "indigo"

type IMarkerProperties =
    interface end

[<RequireQualifiedAccess>]
type MarkerProperties =
    | Key of string
    | Identifier of string
    | Coordinate of GeoCoordinates
    | OnDragStart of DragPosition
    | OnDrag of DragPosition
    | OnDragEnd of DragPosition
    | Draggable
    | Title of string
    | Description of string
    | PinColor of string
        interface IMarkerProperties

[<AutoOpen>]
module Helpers =

    let getPosition (options: obj) : Fable.Core.JS.Promise<obj> = importMember "./location.js"


    let getGeoPosition () =
        promise {
            let! pos = getPosition()
            let (c:GeoCoordinates) = pos?coords |> unbox
            return c
        }

    let createCoordinates(latitude:float,longitude:float) : GeoCoordinates =
         createObj
            [ "latitude" ==> latitude
              "longitude" ==> longitude ]
        |> unbox


    let mapView (props:IMapViewProperties list) (children) : ReactElement =
        ofImport "default" "react-native-maps" (keyValueList CaseRules.LowerFirst props) children


    let circle (props:ICircleProperties list) : ReactElement =
        ofImport "Circle" "react-native-maps" (keyValueList CaseRules.LowerFirst props) []

    let callout (props:ICalloutProperties list) (children) : ReactElement =
        ofImport "Callout" "react-native-maps" (keyValueList CaseRules.LowerFirst props) children

    let marker (props:IMarkerProperties list) (children) : ReactElement =
        ofImport "Marker" "react-native-maps" (keyValueList CaseRules.LowerFirst props) children