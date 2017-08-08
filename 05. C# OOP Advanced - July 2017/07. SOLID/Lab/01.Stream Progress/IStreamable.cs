using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Stream_Progress
{
    public interface IStreamable
    {
        int Length { get; set; }

        int BytesSent { get; set; }
    }
}
