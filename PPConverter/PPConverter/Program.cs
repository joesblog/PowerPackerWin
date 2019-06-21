using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace PPConverter
{
 public  class Program
  {

    [DllImport("PowerPacker32.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
    public static extern void dumpToFile(string source, string destination);


    [DllImport("PowerPacker32.dll", SetLastError = true, CallingConvention = CallingConvention.Cdecl)]
    public static extern IntPtr convert(string source);
    static void Main(string[] args)
    {

      string pathOfCurrentFile = "";
      string pathForSaveFile = "";
      if (args == null || args.Length == 0)
      {
        Console.WriteLine("No Args, Usage PPConverter Infile.txt Outfile.txt");
      //  Console.ReadLine();
      }
      else if (args.Length == 1)
      {
        pathOfCurrentFile = args[0];
        pathForSaveFile = Path.GetDirectoryName(args[0]) + "\\" +  Path.GetFileNameWithoutExtension(args[0]) +"_ppext" + Path.GetExtension(args[0]);
        writeFile(pathOfCurrentFile, pathForSaveFile);

      }
      else if (args.Length == 2)
      {
        pathOfCurrentFile = args[0];
        pathForSaveFile = args[1];
        writeFile(pathOfCurrentFile, pathForSaveFile);
      }


    }

    static void writeFile(string src, string dst)
    {
      IntPtr ptr = new IntPtr();
      ptr = convert(src);
      string op = Marshal.PtrToStringAnsi(ptr);

      File.WriteAllText(dst, op);
    }
  }
}
