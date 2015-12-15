Vanessa Vuibert
vanessa.vuibert@mail.mcgill.ca

how to create a new Surface 2.0 app with Visual Studio 2010
File->new->New Project->Visual C#->Surface v2.0->Surface Application (WPF)

Add the following to the SurfaceWindow1.xaml file to make it transparent and cover the whole screen:
WindowStyle="None" AllowsTransparency="True" Background="#01FFFFFF"
Topmost="True" WindowState="Maximized" ResizeMode="NoResize"

Add the methods of your choosing to SurfaceWindow1.xaml.cs from the following list:
https://msdn.microsoft.com/en-us/library/microsoft.surface.presentation.controls.surfacewindow_methods.aspx

To close a surface app press: alt+F4