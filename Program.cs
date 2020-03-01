using System;
using AlbumLabel.Models;
using System.Linq;

namespace AlbumLabel
{
  class Program
  {

    public static void Main(string[] args)
    {

      var isRunning = true;
      var db = new DatabaseContext();
      var bands = new LabelManagement();
      var albums = new LabelManagement();

      while (isRunning)
      {

        Console.WriteLine("Welcome to YOUR ALBUM LABEL");
        Console.WriteLine("");
        Console.WriteLine("What would you like to do?");
        Console.WriteLine("");
        Console.WriteLine("(Sign) a new band");
        Console.WriteLine("");
        Console.WriteLine("(Release) a band");
        Console.WriteLine("");
        Console.WriteLine("(Resign) a band");
        Console.WriteLine("");
        Console.WriteLine("(Produce) and album");
        Console.WriteLine("");
        Console.WriteLine("View all albums for a certian band (Discography)");
        Console.WriteLine("");
        Console.WriteLine("View all songs in a certian album (Track List)");
        Console.WriteLine("");
        Console.WriteLine("View all albums by (Release Date)");
        Console.WriteLine("");
        Console.WriteLine("View all (Signed) bands");
        Console.WriteLine("");
        Console.WriteLine("View all (Unsigned) bands");
        Console.WriteLine("");
        Console.WriteLine("(Quit)");
        var input = Console.ReadLine().ToLower();

        if (input == "sign")
        {
          Console.WriteLine("What is the name of the band ");
          var name = Console.ReadLine().ToLower();
          Console.WriteLine("");
          Console.WriteLine("What is the country of origin for this band");
          var origin = Console.ReadLine().ToLower();
          Console.WriteLine("");
          Console.WriteLine("How many members are in this band");
          var members = Console.ReadLine().ToLower();
          Console.WriteLine("");
          Console.WriteLine("What is the bands website");
          var website = Console.ReadLine().ToLower();
          Console.WriteLine("");
          Console.WriteLine("What is the main style of music the band plays");
          var style = Console.ReadLine().ToLower();
          Console.WriteLine("");
          Console.WriteLine("What is the name of the band's manager");
          var poc = Console.ReadLine().ToLower();
          Console.WriteLine("");
          Console.WriteLine("What is the best contact number for the band");
          var contactNumber = Console.ReadLine().ToLower();
          bands.SignNewBand(name, origin, members, website, style, poc, contactNumber);
        }

        else if (input == "release")
        {
          Console.WriteLine("Please input the Id of the band you would like to release, this is located to the left of the bands name");
          var displayBands = db.Bands.OrderBy(b => b.IsSigned == true);
          foreach (var b in displayBands)
          {
            Console.WriteLine($"{b.Id} {b.Name}");
          }
          var userInput = int.Parse(Console.ReadLine());
          var bandToRealease = db.Bands.First(bands => bands.Id == userInput);
          bandToRealease.IsSigned = false;
          db.SaveChanges();
        }

        else if (input == "resign")
        {
          Console.WriteLine("Here are the current bands that are not currently signed");
          Console.WriteLine("Please input the Id of the band you would like to resign, this is located to the left of the bands name");
          var displayBands = db.Bands.Where(b => b.IsSigned == false);
          foreach (var b in displayBands)
          {
            Console.WriteLine($"{b.Id} {b.Name}");
          }
          var userInput = int.Parse(Console.ReadLine());
          var bandToResign = db.Bands.First(bands => bands.Id == userInput);
          bandToResign.IsSigned = true;
          db.SaveChanges();
        }

        else if (input == "signed")
        {
          Console.WriteLine("Here are the current bands that are currently signed");
          var displayBands = db.Bands.Where(b => b.IsSigned == true);
          foreach (var b in displayBands)
          {
            Console.WriteLine($"{b.Id} {b.Name}");
          }
        }

        else if (input == "unsigned")
        {
          Console.WriteLine("Here are the current bands that are currently signed");
          var displayBands = db.Bands.Where(b => b.IsSigned == false);
          foreach (var b in displayBands)
          {
            Console.WriteLine($"{b.Id} {b.Name}");
          }
        }

        else if (input == "produce")
        {
          LabelManagement.ProduceAnAlbum();
        }

        else if (input == "release date")
        {
          var displayAlbums = db.Albums.OrderBy(a => a.ReleaseDate);
          foreach (var a in db.Albums)
          {
            Console.WriteLine($"{a.Id} {a.Title} was released on {a.ReleaseDate}");
          }
        }

        else if (input == "discography")
        {
          Console.WriteLine("Please select the Id Number located to left of the band to view all their albums");
          var displayBands = db.Bands.OrderBy(b => b.Id);
          foreach (var b in displayBands)
          {
            Console.WriteLine($"{b.Id} {b.Name}");
          }
          var userInput = int.Parse(Console.ReadLine());
          var displayBandAlbums = db.Albums.Where(a => a.BandId == userInput);
          foreach (var a in displayBandAlbums)
          {
            Console.WriteLine($"{a.Title} was realeased on {a.ReleaseDate}");
          }
        }

        else if (input == "track list")
        {
          Console.WriteLine("Please select the Id Number located to left of the album to view all the songs on the album");
          var displayAlbums = db.Albums.OrderBy(b => b.Id);
          foreach (var a in displayAlbums)
          {
            Console.WriteLine($"{a.Id} {a.Title}");
          }
          var userInput = int.Parse(Console.ReadLine());
          var displayAlbumSongs = db.Songs.Where(a => a.AlbumId == userInput);
          foreach (var s in displayAlbumSongs)
          {
            Console.WriteLine($"{s.Title}");
          }
        }

















        else if (input == "quit")
        {
          isRunning = false;
          Console.WriteLine("Good Bye!!");
        }
      }
    }


  }
}

