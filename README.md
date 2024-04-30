# RGB Filter

An application to load an image from file and then apply simple filters on a per-pixel basis.

This is the C# version of the application with Windows Forms GUI elements.

## Build

Clone the repo and use Visual Studio (Community Edition works fine for me) to open the solution (*.sln) file in the root directory. Should build/run at the push of a button.

It's modeled on a standard Windows productivity application so using it should be pretty straightforward.

## Filters

The Black and White filter takes the average of the Red, Green and Blue values for each pixel and sets all three of Red, Green and Blue to that average.

The Invert filter inverts Red, Green and/or Blue by setting each to their original value subtracted from 255. Naturally this filter is its own inverse. I structured its menu to practice the implementation of a sub-menu.

The Scale filter multiplies each of Red, Green and/or Blue by the provided scale factor. I structured this menu to practice dialog boxes, group boxes, check boxes and text boxes. Note that the scaled value is rounded to an integer, and is limited to a max of 255 and a min of 0, so this filter can be lossy.

## Inspiration

My younger son came to me and out of the blue asked me if I knew what RGB pixel encoding was. I said I did, and he told me that he had a theory, that if you took the Red, Green and Blue values for each pixel in an image, averaged them, and then set all three values to that average, the result would be the original image in black and white.

I told him that I couldn't imagine where he got that theory from or why he thought it would work that way but that I could absolutely write a Windows application to test his theory.

I wrote the application in C++ as I was familiar with Windows GUI application development with C++ from prior work experience.

He was of course right--we changed a bunch of family photos to black and white and got a real kick out of it. Since it was pretty easy from there, we added some more basic filters.

This is pretty much that same application but written in C# as an exercise in improving my C# skills.
