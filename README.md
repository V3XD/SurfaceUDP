# SurfaceUDP (PixelSense)
Sends TouchDown, TouchUp and TouchMove Surface 2.0 events through UDP.

### Receiver
Unity3D multitouch visualizer: https://github.com/V3XD/SurfaceTouches

## How to create a new Surface 2.0 app with Visual Studio 2010
- File->new->New Project->Visual C#->Surface v2.0->Surface Application (WPF).
- Add the following to the SurfaceWindow1.xaml file to make it transparent and cover the whole screen:
```
WindowStyle="None" AllowsTransparency="True" Background="#01FFFFFF"
Topmost="True" WindowState="Maximized" ResizeMode="NoResize"
```
- Add the [methods](https://msdn.microsoft.com/en-us/library/microsoft.surface.presentation.controls.surfacewindow_methods.aspx) of your choosing to SurfaceWindow1.xaml.cs. 

### How to close the Surface app
Press alt+F4

## Recommendations
- Clean the touchscreen.
- Check the calibration.

## Contributors
vanessa.vuibert@mail.mcgill.ca