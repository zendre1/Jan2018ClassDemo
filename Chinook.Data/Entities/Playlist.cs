using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional Namespaces
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
#endregion

namespace Chinook.Data.Entities
{
    [Table("Playlist")]
    public class Playlist
    {
        [Key]
        public int PlaylistId { get; set; }

        [Required(ErrorMessage = "Playlist Name is required.")]
        [StringLength(120, ErrorMessage = "Playlist name has a maximum of 120 characters")]
        public string Name { get; set; }

        [StringLength(120, ErrorMessage = "Playlist username has a maximum of 120 characters")]
        public string UserName { get; set; }

        //navigational properties
        public virtual ICollection<PlaylistTrack> PlaylistTracks { get; set; }

    }
}
