﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional Namespaces
using Chinook.Data.Entities;
using Chinook.Data.DTOs;
using Chinook.Data.POCOs;
using ChinookSystem.DAL;
using System.ComponentModel;
#endregion

namespace ChinookSystem.BLL
{
    [DataObject]
    public class TrackController
    {
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public List<Track> Tracks_List()
        {
            //create an transaction instance of your Context class
            using (var context = new ChinookContext())
            {
                return context.Tracks.OrderBy(x => x.Name).ToList();
            }
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public Track Tracks_Get(int trackid)
        {
            //create an transaction instance of your Context class
            using (var context = new ChinookContext())
            {
                return context.Tracks.Find(trackid);
            }
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public List<Track> Tracks_GetByAlbumID(int albumid)
        {
            //create an transaction instance of your Context class
            using (var context = new ChinookContext())
            {
                return context.Tracks.Where(x => x.AlbumId == albumid).Select(x => x).ToList();
            }
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public List<TrackList> List_TracksForPlaylistSelection(string tracksby, int argid)
        {
            using (var context = new ChinookContext())
            {
                IEnumerable<TrackList> results = null;

                //code to go here
                results = from x in context.Tracks
                          orderby x.Name
                          where tracksby.Equals("Artist") ? x.Album.ArtistId == argid :
                                tracksby.Equals("MediaType") ? x.MediaTypeId == argid :
                                tracksby.Equals("Genre") ? x.GenreId == argid :
                                x.AlbumId == argid
                          select new TrackList
                          {
                              TrackID = x.TrackId,
                              Name = x.Name,
                              Title = x.Album.Title,
                              MediaName = x.MediaType.Name,
                              GenreName = x.Genre.Name,
                              Composer = x.Composer,
                              Milliseconds = x.Milliseconds,
                              Bytes = x.Bytes,
                              UnitPrice = x.UnitPrice
                          };

                return results.ToList();
            }
        }//eom
    }
}
