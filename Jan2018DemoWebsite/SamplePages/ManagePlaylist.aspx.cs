using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

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
            TracksBy.Text = "Artist";
            SearchArgID.Text = ArtistDDL.SelectedValue;
            //refresh the track list display
            TracksSelectionList.DataBind();
        }

        protected void MediaTypeFetch_Click(object sender, EventArgs e)
        {

        }

        protected void GenreFetch_Click(object sender, EventArgs e)
        {

        }

        protected void AlbumFetch_Click(object sender, EventArgs e)
        {

        }

        protected void PlayListFetch_Click(object sender, EventArgs e)
        {

        }

        protected void MoveDown_Click(object sender, EventArgs e)
        {

        }

        protected void MoveUp_Click(object sender, EventArgs e)
        {

        }

        protected void DeleteTrack_Click(object sender, EventArgs e)
        {

        }

        protected void TracksSelectionList_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            string arg = e.CommandArgument.ToString();
            PlaylistName.Text = arg;
        }



        //protected void TracksSelectionList_Command(object sender, CommandEventArgs e)
        //{
        //    string arg = e.CommandArgument.ToString();
        //    PlaylistName.Text = arg;
        //}

        //protected void AddtoPlaylist_Command(object sender, CommandEventArgs e)
        //{

        //}
    }
}