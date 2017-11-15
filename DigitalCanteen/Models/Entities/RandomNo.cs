using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DigitalCanteen.Models.Entities
{
    public class RandomNo
    {
        [Key]
        public int RandomID { get; set; }

        public int RandomNumber { get; set; }

        public int Amount { get; set; }

        [DefaultValue(true)]
        public bool IsCheck { get; set; }
    }
}