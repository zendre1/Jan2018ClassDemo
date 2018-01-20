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
    [Table("Genres")]
    public class Genre
    {
        [Key]
        public int GenreId { get; set; }

        [StringLength(120, ErrorMessage = "Genre name has a maximum of 120 characters")]
        public string Name { get; set; }
        public virtual ICollection<Track> Tracks { get; set; }

    }
}
