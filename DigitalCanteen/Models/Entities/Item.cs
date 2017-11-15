
﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using DigitalCanteen.Models.Entities;


namespace DigitalCanteen.Models.Entities
{
    public class Item
    {   [Key]
        public int ItemId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Details { get; set; }

        [Required]
        public float Price { get; set; }
      //  public int UserId { get; set; }

        public virtual AccountDetail AccountDetail { get; set; }
        

    }
}