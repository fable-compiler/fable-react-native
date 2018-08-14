### 2.0.0-alpha-006
Various fixes by @iyegoroff:
- added CommonProps with Key prop;
- added Alert.Options type and Alert.alertWithOptions function.

### 2.0.0-alpha-005
Various fixes by @iyegoroff:
- added UIManager;
- updated LayoutAnimationStatic.

### 2.0.0-alpha-004
Various fixes by @iyegoroff:
- updated `ImageProperties` type;
- removed `ScrollViewStyle` type, `ScrollView` uses just `ViewStyle`;
- added `ShadowOffset` type.

### 2.0.0-alpha-003
Various fixes by @iyegoroff:

- changed `IImageSourceProperties list` to `IImageSource` and added functions for fetching remote images `remoteImage` and `remoteImages`:
https://github.com/iyegoroff/fable-react-native/blob/ea8bf8ff51a1d702edb9db44620fb13a35194cfe/src/Fable.Helpers.ReactNative.fs#L1497-L1501
- updated `Switch` and `Slider` components;
- removed deprecated `SwitchIOS` and `SliderIOS` components;
- updated `FlatListProperties` and added `IFlatListProperties` interface to `ScrollViewProperties`;
- updated `ScrollViewProperties`;
- renamed function `Dip` to `dip` and `Pct` to `pct` to conform other function's naming style;
- put `WebViewBundleSource` above `ImageURISourceProperties`, so now `Uri` is inferred as `ImageURISourceProperties.Uri` which is more commonly used than `WebViewBundleSource.Uri`;
- added `RequireQualifiedAccess` to `FlexDisplayType` to prevent conflict with `Option.None`;
- several fixed typos & minor fixes;

### 2.0.0-alpha-002
* Adds currentHeight to StatusBar #29
* Adds Geotype #30

### 2.0.0-alpha-001
* Fixes by @iyegoroff: PR #23

### 1.7.2
* Some of FlatList properties are upper case: @iyegoroff

### 1.7.1
* KeyboardShouldPersistTaps changed for ScrollViews

### 1.7.0
* async-safe, static lifecycle hooks - https://fb.me/react-async-component-lifecycle-hooks

### 1.6.6
* KeyboardShouldPersistTaps changed for ScrollViews

### 1.6.5
* FlatList's KeyExtractor by Index is an int (@forki)

### 1.6.3
* Add a button (#20 @forki)

### 1.6.2
* Adding react-native-device-info helper (#19 @forki)

### 1.6.1
* Fix #17: textInput on IOS (@ddunlea)

### 1.6.0
* Fix compat issues with Fable update

### 1.5.2
* Type info for items in FlatList

### 1.5.0
* Barcode scanning via react-native-camera
* Picker values as string

### 1.4.0
* Add ReactNativeSignatureView support to the project
* Add react-native-modal-datetime-picker bindings - https://github.com/fable-compiler/fable-react-native/pull/11

### 1.3.0
* BREAKING: RN 0.47 support - this is breaking since React Native is breaking in some cases
* BREAKING: ImageResizer fixes for v1.0 - https://github.com/fable-compiler/fable-react-native/pull/10
* Add ImageEditor bindings - https://github.com/fable-compiler/fable-react-native/pull/6
* Add ReactNativeSignatureView support - https://github.com/fable-compiler/fable-react-native/pull/7
* Async launchCamera and launchImageLibrary functions - https://github.com/fable-compiler/fable-react-native/pull/8
* Add AspectRatio to FlexStyle
* Flat list support

### 1.2.3
* SignaturePad

### 1.2.2
* RemoveItem in Simple DB

### 1.2.0
* Added first prototype of FlatList mappings

### 1.1.2
* Fix error with toolbarAndroid