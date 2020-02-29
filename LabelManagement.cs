using System;
using System.Collections.Generic;
using System.Linq;

namespace AlbumLabel
{
  public class LabelManagement

  {


    public void SignNewBand(string name, string origin, string numberOfMembers, string website, string style, string poc, string contactNumber)
    {
      var db = new Models.DatabaseContext();
      var band = new Models.Band
      {
        Name = name,
        CountryOfOrigin = origin,
        NumberOfMembers = numberOfMembers,
        Website = website,
        Style = style,
        IsSigned = true,
        PersonOfContact = poc,
        ContactPhoneNumber = contactNumber


      };
      db.Bands.Add(band);
      db.SaveChanges();
    }

    public static void ProduceAnAlbum()
    {
      var db = new Models.DatabaseContext();
      Console.WriteLine("");
      Console.WriteLine("What is the name of the album you would like to add?");
      var title = Console.ReadLine().ToLower();
      Console.WriteLine("");
      Console.WriteLine("Is this an explicit album? (yes) or (no)");
      var userInput = Console.ReadLine().ToLower();
      var isExplicit = false;
      if (userInput == "yes")
      {
        isExplicit = true;
      }

      else
      {
        isExplicit = false;

      }
      Console.WriteLine("What is the release date of the album?, (yyyy, mm, dd)");
      var releaseDate = DateTime.Parse(Console.ReadLine().ToLower());
      Console.WriteLine("Which band is producing this album?, please select the id located to the left of the band");
      var displayBands = db.Bands;
      foreach (var b in displayBands)
      {
        Console.WriteLine($"{b.Id} {b.Name}");
      }
      var bandId = int.Parse(Console.ReadLine());
      var album = new Models.Album
      {
        Title = title,
        IsExplicit = isExplicit,
        ReleaseDate = releaseDate,
        BandId = bandId



      };

      db.Albums.Add(album);
      db.SaveChanges();

      var albumId = album.Id;

      ProduceASong(albumId);
    }

    public static void ProduceASong(int albumId)
    {
      var db = new Models.DatabaseContext();
      Console.WriteLine("Now lets add some songs to the album");
      Console.WriteLine("");
      Console.WriteLine("What is the name of the you would like to add song");
      var title = Console.ReadLine().ToLower();
      Console.WriteLine("");
      Console.WriteLine("Input a few lyrics from the song");
      var lyrics = Console.ReadLine().ToLower();
      Console.WriteLine("");
      Console.WriteLine("How many minutes is the song?, please round to the nearest minute");
      var length = Console.ReadLine().ToLower();
      Console.WriteLine("");
      Console.WriteLine("Please input one genre for the song");
      var genre = Console.ReadLine().ToLower();
      Console.WriteLine("");
      Console.WriteLine("Would you Like to add another song");
      var song = new Models.Song
      {
        Title = title,
        Lyrics = lyrics,
        Length = length,
        Genre = genre,
        AlbumId = albumId
      };
      db.Songs.Add(song);
      db.SaveChanges();








    }


  }
}