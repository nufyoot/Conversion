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