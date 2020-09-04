using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevenNote.Models
{
    public class NoteCreate // this model is to capture Title, Content, and DateCreated. Id will be generated after POST request happens. .Service and .Data layer will work together to do take care of that.
    {
        [Required]
        [MinLength(2, ErrorMessage = "Please eneter at least 2 characters.")]
        [MaxLength(100, ErrorMessage = "There are too many characters in this field.")]
        public string Title { get; set; }

        [MaxLength(8000)]
        public string Content { get; set; }
    }
}
