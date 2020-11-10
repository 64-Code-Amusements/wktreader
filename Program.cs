using System;
using System.Linq;
using NetTopologySuite.IO;

namespace wktreader
{
  class Program
  {
    static string collection = "collection.txt";
    static string linestring = "linestrings.txt";
    static string linestringWithCommas = "linestringWithCommas.txt";
    static void Main(string[] args)
    {

      ReadWithCommas();
      ReadCollection();
      ReadWithoutCommas();

    }

    static void ReadWithoutCommas()
    {
      var wktReader = new WKTReader();

      Console.WriteLine("Without commas");
      var reader = new WKTFileReader(linestring, wktReader);

      // this doesn't affect the behaviour
      reader.Limit = -1;
      reader.Offset = 0;

      var geometries = reader.Read();

      Console.WriteLine($"Count of geometries: {geometries.Count}");
    }

    static void ReadCollection() { 
      var wktReader = new WKTReader();

      Console.WriteLine("Collection");
      var reader = new WKTFileReader(collection, wktReader);

      // this doesn't affect the behaviour
      reader.Limit = -1;
      reader.Offset = 0;

      var geometries = reader.Read();

      Console.WriteLine($"Count of geometries: {geometries.Count}");
      Console.WriteLine($"Count of sub geometries: {geometries.First().NumGeometries}");

  }
    static void ReadWithCommas()
    {

      var wktReader = new WKTReader();

      Console.WriteLine("With commas");
      var reader = new WKTFileReader(linestringWithCommas, wktReader);

      // this doesn't affect the behaviour
      reader.Limit = -1;
      reader.Offset = 0;

      var geometries = reader.Read();

      Console.WriteLine($"Count of geometries: {geometries.Count}");

    }
  }
}
