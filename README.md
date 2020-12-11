# unity-msaa-pattern
Unity project implementing an "MSAA Sample Pattern Detector"

![](screenshot.PNG)

This project is inspired by procedures suggested in http://mynameismjp.wordpress.com/2010/07/07/msaa-sample-pattern-detector to detect current MSAA sampling pattern.
  
  
Its scene renders a grid of quads onto a render textures of size 1px * 1px.  
  
It then uses a shader with [Texture2DMS.Load(..., SampleIndex)](https://docs.microsoft.com/en-us/windows/win32/direct3dhlsl/dx-graphics-hlsl-to-load) to retrieve the color of each sample in that pixel, and stores those colors into a rectangular "pattern texture".  
  
Finally, it reads the color values of the "pattern texture" and displays a text with the sample coordinates they map to.


## Disclaimers

This is a quickly assembled project that does not do error checking and use hard-coded values.  
According to GPU and platform, it might not work correctly!  
  
 
Currently only works in Editor!  
Standalone mode is not working!!


