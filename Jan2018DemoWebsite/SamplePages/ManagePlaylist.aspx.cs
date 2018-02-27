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

        protected void CheckForException(object sender, ObjectDataSourceStatusEventArgs e)
        {
            MessageUserControl.HandleDataBoundException(e);
        }

        protected void ArtistFetch_Click(object sender, EventArgs e)
        {
            MessageUserControl.TryRun(() =>
            {
                //code to go here
                TracksBy.Text = "Artist";
                SearchArgID.Text = ArtistDDL.SelectedValue;
                //refresh the track list display
                TracksSelectionList.DataBind();
            });
        }

        protected void MediaTypeFetch_Click(object sender, EventArgs e)
        {
            MessageUserControl.TryRun(() =>
            {
                //code to go here
                TracksBy.Text = "Media";
                SearchArgID.Text = MediaTypeDDL.SelectedValue;
                //refresh the track list display
                TracksSelectionList.DataBind();
            });
        }

        protected void GenreFetch_Click(object sender, EventArgs e)
        {
            MessageUserControl.TryRun(() =>
            {
                //code to go here
                TracksBy.Text = "Genre";
                SearchArgID.Text = GenreDDL.SelectedValue;
                //refresh the track list display
                TracksSelectionList.DataBind();
            });
        }

        protected void AlbumFetch_Click(object sender, EventArgs e)
        {
            MessageUserControl.TryRun(() =>
            {
                //code to go here
                TracksBy.Text = "Album";
                SearchArgID.Text = AlbumDDL.SelectedValue;
                //refresh the track list display
                TracksSelectionList.DataBind();
            });
        }

        protected void PlayListFetch_Click(object sender, EventArgs e)
        {
            //code to go here
            if (string.IsNullOrEmpty(PlaylistName.Text))
            {
                MessageUserControl.ShowInfo("Missing Field", "PlayList Name is required");
            }
            else
            {
                string username = "HansenB";
                string playlistname = PlaylistName.Text;
                //ListViewDataItem rowContents = e.Item as ListViewDataItem;
                MessageUserControl.TryRun(() =>
                {
                    PlaylistTracksController sysmgr = new PlaylistTracksController();
                    List<UserPlaylistTrack> results = sysmgr.List_TracksForPlaylist(playlistname, username);
                    if (results.Count() == 0)
                    {
                        MessageUserControl.ShowInfo("No tracks found.", "Check playlist name if you expect tracks.");
                    }
                    else
                    {
                        PlayList.DataSource = results;
                        PlayList.DataBind();
                    }
                });
            }
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
            //code to go here
            if (string.IsNullOrEmpty(PlaylistName.Text))
            {
                MessageUserControl.ShowInfo("Missing Field", "PlayList Name is required");
            }
            else
            {
                string username = "HansenB";
                string playlistname = PlaylistName.Text;
                //ListViewDataItem rowContents = e.Item as ListViewDataItem;
                MessageUserControl.TryRun(() =>
                {
                    PlaylistTracksController sysmgr = new PlaylistTracksController();
                    sysmgr.Add_TrackToPLaylist(playlistname, username,
                        int.Parse(e.CommandArgument.ToString()));
                    List<UserPlaylistTrack> results = sysmgr.List_TracksForPlaylist(playlistname, username);
                    PlayList.DataSource = results;
                    PlayList.DataBind();
                });

            }
        }

    }
}