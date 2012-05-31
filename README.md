Conversion
==========

This light-weight library allows the user to easily convert from one type of object to another.

Samples
=======

The following sample demonstrates the basic principle of converting objects.  The Conversion library has come with a few units that can be used right out of the box, but the idea of converting one object to another is very straight forward.

    Conversion.Units.PixelUnit pixelUnit = new Conversion.Units.PixelUnit(96);
    Conversion.Units.InchUnit inchUnit = pixelUnit.ConvertTo<Conversion.Units.InchUnit>();
  
There are also a few extension methods to make the code a bit shorter.

    using Conversion;
    
    Conversion.Units.PixelUnit pixelUnit = new Conversion.Units.PixelUnit(96);
    Conversion.Units.InchUnit inchUnit = pixelUnit.ConvertToInches();
    
And, of course, the conversion library supports the following:

    using Conversion;
    
    Conversion.Units.PixelUnit pixelUnit = "96px".ConvertToPixels();
    
Or, if you aren't sure what the unit is:

    using Conversion;
    
    Conversion.Units.IUnit unit = "2in".ConvertToUnit();
    Conversion.Units.PixelUnit pixelUnit = unit.ConvertToPixels();
    
Other Samples
=============

Let's say you don't want to work with measurments, there are still many uses for this library.  Consider the following:

    using Conversion;
    
    string input = "ten";
    int i = int.Parse(input);
    
Now, you could write a simple method that will convert any string input to an integer but then you need to remember
to use that method for all conversions from string to integer.  Instead, you could do the following:

    public static int ConvertStringToInt(string input)
    {
        if (input == "ten") return 10;
        else return 0;
    }
    
Then, somewhere in your application (probably when the application starts), add:

    Conversion.ConverterFactory.Register<string, int>(ConvertStringToInt);
    
This now allows you to write:
    
    using Conversion;
    
    string input = "ten";
    int a = input.ConvertTo<int>();
    
Imagine registering some common conversion methods to be used by your project and then just call them using
"ConvertTo".