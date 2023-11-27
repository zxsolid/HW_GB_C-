using ImplicitCasting.Base.Classes;

Bits<byte> bitsByte = 5;
Bits<int> bitsInt = 255;
Bits<long> bitsLong = 1234567890;


Console.WriteLine($"bitsByte: {bitsByte.Value}");
Console.WriteLine($"bitsInt: {bitsInt.Value}");
Console.WriteLine($"bitsLong: {bitsLong.Value}");

Console.ReadLine();