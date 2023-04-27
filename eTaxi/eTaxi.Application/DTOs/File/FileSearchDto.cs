using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eTaxi.Application.DTOs.File
{
    public class FileSearchDto
    {
        public int? UserId { get; set; }
        public string Type { get; set; } = string.Empty;
        public int? FeedbackId { get; set; }
    }
}
