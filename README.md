# VirtualBackgroundCamera
![demo](https://user-images.githubusercontent.com/34697515/122642140-dadf1880-d143-11eb-9e8a-fc2bc6adb669.gif)

**VirtualBackgroundCamera** is a virtual camera application that allows you to use a virtual background in any applications.

---
### Dependencies
VirtualBackgroundCamera uses the following packages:
- [Unity Capture](https://github.com/creativeIKEP/UnityCapture)(This is customized for VirtualBackgroundCamera. Original Unity Capture is [here](https://github.com/schellingb/UnityCapture))
- [SelfieSegmentationBarracuda](https://github.com/creativeIKEP/SelfieSegmentationBarracuda)

---
### Install
VirtualBackgroundCamera can be downloaded from [release page](https://github.com/creativeIKEP/VirtualBackgroundCamera/releases).
Download installer(`VirtualBackgroundCamera-1.1.0setup.exe` file) from [release page](https://github.com/creativeIKEP/VirtualBackgroundCamera/releases) and execute it.

---
### Usage
#### Image Capture
1. Select source input camera device from `Input Device` pull down.
2. (Option) Set the resolution of camera images in `W` and `H` input field.
3. Push the `Start/Stop` button for starting or stopping camera capture.

#### Control of Virtual BackGround
- You can change the background image from pull down.
List of images in pull down were loaded PNG files from `VirtualBackgroundCamera_Data > LoadedImages` directory (default image is not include this).
You can output camera original image if you select the `None` option from pull down.
- You can load new images as the background image from the `New image` button.
VirtualBackgroundCamera is supported PNG(`.png`, `.PNG`) or JPG(`.jpg`, `.jpeg`, `.JPG`, `.JPEG`) images.
  - Loaded background images were convert PNG images, and save to `VirtualBackgroundCamera_Data > LoadedImages` directory.
  - You can continue to use the image is loaded once, if application is restarting.
- You can flip the image horizontally by on/off of the `Mirror mode` toggle if `Output on/off` toggle is on.

#### Output Control
Rendered images can be output as the virtual camera image if `Output on/off` toggle is on.
You can show composited image in another applications when you select a camera named `VirtualBackgroundCamera` in another applications.

---
### Author
[IKEP](https://ikep.jp)

---
### LICENSE
Copyright (c) 2021 IKEP

[MIT](/LICENSE)
