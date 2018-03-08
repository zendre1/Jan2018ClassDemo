using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

#region Additonal Namespaces
using ChinookSystem.BLL;
using Chinook.Data.POCOs;
#endregion

namespace Jan2018DemoWebsite.SamplePages
{
    public partial class ManagePlaylist : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            TracksSelectionList.DataSource = null;
        }

       

        protected void ArtistFetch_Click(object sender, EventArgs e)
        {
            //code to go here
            MessageUserControl.TryRun(() =>
            {
                TracksBy.Text = "Artist";
                SearchArgID.Text = ArtistDDL.SelectedValue;
                TracksSelectionList.DataBind();
            },"Tracks by Artist","Add an track to your playlist by clicking on the + (plus sign).");
        }

        protected void MediaTypeFetch_Click(object sender, EventArgs e)
        {
            //code to go here
            MessageUserControl.TryRun(() =>
            {
                TracksBy.Text = "MediaType";
                SearchArgID.Text = MediaTypeDDL.SelectedValue;
                TracksSelectionList.DataBind();
            }, "Tracks by Media Type", "Add an track to your playlist by clicking on the + (plus sign).");
        }

        protected void GenreFetch_Click(object sender, EventArgs e)
        {
            //code to go here
            MessageUserControl.TryRun(() =>
            {
                TracksBy.Text = "Genre";
                SearchArgID.Text = GenreDDL.SelectedValue;
                TracksSelectionList.DataBind();
            }, "Tracks by Genre", "Add an track to your playlist by clicking on the + (plus sign).");
        }

        protected void AlbumFetch_Click(object sender, EventArgs e)
        {
            
            //code to go here
            MessageUserControl.TryRun(() =>
            {
                TracksBy.Text = "Album";
                SearchArgID.Text = AlbumDDL.SelectedValue;
                TracksSelectionList.DataBind();
            }, "Tracks by Album", "Add an track to your playlist by clicking on the + (plus sign).");
        }

        protected void PlayListFetch_Click(object sender, EventArgs e)
        {
            //code to go here
           
        }

        protected void MoveDown_Click(object sender, EventArgs e)
        {
            //code to go here
        }

        protected void MoveUp_Click(object sender, EventArgs e)
        {
            //code to go here
        }

        protected void DeleteTrack_Click(object sender, EventArgs e)
        {
            //code to go here
        }

        protected void TracksSelectionList_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            //this method will only execute if the user has press
            //    the plus sign on a visible row from the display

            if (string.IsNullOrEmpty(PlaylistName.Text))
            {
                MessageUserControl.ShowInfo("PlayList Name", "You must supply a playlist name.");
            }
            else
            {
                //via security one can obtain the username
                string username = "HansenB";
                string playlistname = PlaylistName.Text;

                //the trackid is attached to each ListView row
                //   via the CommandArgument parameter
                //Access to the trackid is done via the
                //   ListViewCommandEventArgs e parameter
                //The e parameter is treated as an object
                //Some e parameter need to be cast as strings
                int trackid = int.Parse(e.CommandArgument.ToString());

                //all requred data can now be sent to the BLL
                //    for further processing
                //user friendly error handling
                MessageUserControl.TryRun(() =>
                {
                    //connect to your BLL
                    PlaylistTracksController sysmgr = new PlaylistTracksController();
                    sysmgr.Add_TrackToPLaylist(playlistname, username, trackid);
                    //code to retreive the up to date playlist and tracks
                    //    for refreshing the playlist track list
                },"Track Added","The track has been addded, check your list below");
            }
        }
    }
}