using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ProgrammingLanguages
{
  class Program
  {
    static void Main()
    {
      List<Language> languages = File.ReadAllLines("./languages.tsv")
        .Skip(1)
        .Select(line => Language.FromTsv(line))
        .ToList();

    //   foreach (var l in languages)
    //   {
    //     Console.WriteLine(l.Prettify());
    //   }

      var basicInfo = languages.Select(x => $" Year: {x.Year} - Name: {x.Name} - Chief Developer: {x.ChiefDeveloper}");

      foreach (var info in basicInfo)
      {
        Console.WriteLine(info);
      }

      var cSharp = languages.Where(x => x.Name == "C#");

      foreach (var lang in cSharp)
      {
        Console.WriteLine(lang.Prettify());
      }

      var microsoft = languages.Where(m => m.ChiefDeveloper.Contains("Microsoft"));

      // foreach (var micro in microsoft)
      // {
      //   Console.WriteLine(micro.Prettify());
      // }

      var predecessors = languages.Where(p => p.Predecessors.Contains("Lisp"));

      // foreach (var pre in predecessors)
      // {
      //   Console.WriteLine(pre.Prettify());
      // }

      var scripts = languages.Where(s => s.Name.Contains("Script"));

      // foreach (var script in scripts)
      // {
      //   Console.WriteLine(script.Prettify());
      // }

      // Console.WriteLine(languages.Count());

      var nearMil = languages
      .Where(n => n.Year >= 1995 && n.Year <= 2005)
      .Select(n => $"{n.Name} was invented in {n.Year}");

      // Console.WriteLine($"{nearMil.Count()}");

      // foreach (var near in nearMil)
      // {
      //   Console.WriteLine(near);
      // }

     // PrettyPrintAll(predecessors);
     // PrintAll(nearMil);

     var ordered = languages.OrderBy(x => x.Name);

     var oldest = languages.Min(b => b.Year);

     //PrettyPrintAll(ordered);
     //Console.WriteLine(oldest);

    }

     public static void PrettyPrintAll(IEnumerable<Language> langs)
      {
        foreach (var lang in langs)
        {
          Console.WriteLine(lang.Prettify());
        }
     }

     public static void PrintAll(IEnumerable<Object> sequence)
      {
        foreach (Object seq in sequence)
        {
          Console.WriteLine(seq);
        }
     }
  }
}