using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace PersonDetails.WebAPi.Model
{
    public class PersonDetail
    {
        [Key]
        public Guid PersonId { get; set; }

        public byte Weight { get; set; }

        public byte FromFloor { get; set; }

        public byte ToFloor { get; set; }
    }
}
