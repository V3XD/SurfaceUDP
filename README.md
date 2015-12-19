# SurfaceUDP (PixelSense)
vanessa.vuibert@mail.mcgill.ca
ilja.frissen@mcgill.ca

Sends TouchDown, TouchUp and TouchMove Surface 2.0 events through UDP.
Unity3D multitouch visualizer:
https://github.com/V3XD/SurfaceTouches

How to create a new Surface 2.0 app with Visual Studio 2010:
File->new->New Project->Visual C#->Surface v2.0->Surface Application (WPF)
Add the following to the SurfaceWindow1.xaml file to make it transparent and cover the whole screen:
WindowStyle="None" AllowsTransparency="True" Background="#01FFFFFF"
Topmost="True" WindowState="Maximized" ResizeMode="NoResize"
Add the methods of your choosing to SurfaceWindow1.xaml.cs from the following list:
https://msdn.microsoft.com/en-us/library/microsoft.surface.presentation.controls.surfacewindow_methods.aspx

To close a Surface app press: alt+F4

Recommendations:
Clean the touchscreen.
Check the calibration.