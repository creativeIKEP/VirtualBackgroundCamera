# VirtualBackgroundCamera
![demo](https://user-images.githubusercontent.com/34697515/122642140-dadf1880-d143-11eb-9e8a-fc2bc6adb669.gif)

**VirtualBackgroundCamera** is a virtual camera application that allows you to use a virtual background in any web meeting.

---
### Dependencies
VirtualBackgroundCamera uses the following packages:
- [Unity Capture](https://github.com/schellingb/UnityCapture)
- [KlakSpout](https://github.com/keijiro/KlakSpout)
- [SelfieSegmentationBarracuda](https://github.com/creativeIKEP/SelfieSegmentationBarracuda)

---
### Install
VirtualBackgroundCamera can be downloaded from [release page](https://github.com/creativeIKEP/VirtualBackgroundCamera/releases).
Download installer(`.exe` file) from [release page](https://github.com/creativeIKEP/VirtualBackgroundCamera/releases) and execute it.

In order to use the VirtualBackgroundCamera video as a virtual camera in other applications, you need to setup one of the below dependencies package.

#### Virtual camera setup with Unity Capture
1. Download [Unity Capture](https://github.com/schellingb/UnityCapture).
2. Run the `Install.bat` inside the `Install` directory.

Check `README.md` in [Unity Capture](https://github.com/schellingb/UnityCapture) repository for more details.

#### Virtual camera setup with Spout
[Spout](https://spout.zeal.co/) is an inter-application video transmission system for Windows.
1. Download a zip file from [GitHub release page of Spout](https://github.com/leadedge/Spout2/releases).
2. Unzip the downloaded zip file and run the `SpoutSettings.exe` inside the `SPOUTSETTINGS`. (Follow `Setup.pdf` document).
3. Download a zip file from [GitHub release page of SpoutCam](https://github.com/leadedge/SpoutCam/releases).
4. Unzip the downloaded zip file and run the `SpoutCamSettings.exe`. (Check `readme.txt` for more details).

Check the [Spout web page](https://spout.zeal.co/) for more details more about Spout and SpoutCam.

---
### Usage
#### Image Capture
1. Select source input camera device from `Input Device` pull down.
2. (Option) Set the resolution of camera images in `W` and `H` input field.
3. Push the `Start/Stop` button for starting or stopping camera capture.

#### Control of Virtual BackGround
- You can change the background image from pull down.
List of images in pull down were loaded PNG files from `VirtualBackgroundCamera_Data > LoadedImages` directory (default image is not include this).
- You can load new images as the background image from the `New image` button.
VirtualBackgroundCamera is supported PNG(`.png`, `.PNG`) or JPG(`.jpg`, `.jpeg`, `.JPG`, `.JPEG`) images.
  - Loaded background images were convert PNG images, and save to `VirtualBackgroundCamera_Data > LoadedImages` directory.
  - You can continue to use the image is loaded once, if application is restarting.
- You can control the human edge with the slider UI. VirtualBackgroundCamera renders input camera images if thie value is 0.

#### Output Selection
Rendered images can be output as the virtual camera image if you setup [Unity Capture](https://github.com/schellingb/UnityCapture) or [Spout](https://spout.zeal.co/) in the [Install section](#Install).
- Select the `Use UnityCapture` toggle and select `Unity Video Capture` camera in another applications if you setup [Unity Capture](https://github.com/schellingb/UnityCapture).
  - You can flip the image horizontally by on/off of the `Mirror mode` toggle if you use UnityCapture.
- Select the `Use Spout` toggle and select `SpoutCam` camera in another applications if you setup [Spout](https://spout.zeal.co/).

---
### Author
[IKEP](https://ikep.jp)

---
### LICENSE
Copyright (c) 2021 IKEP

[MIT](/LICENSE)
