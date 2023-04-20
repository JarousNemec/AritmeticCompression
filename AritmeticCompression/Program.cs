// See https://aka.ms/new-console-template for more information

using System.Threading.Channels;
using AritmeticCompression;

Console.WriteLine("Hello, World!");
Compressor compressor = new Compressor();
var r = compressor.Encode("kava");
Console.WriteLine(r);