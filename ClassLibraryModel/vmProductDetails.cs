using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryModel
{
    public class vmProductDetails
    {
        public int id { get; set; }
        public string detailsid { get; set; }
        public string sizename { get; set; }
        public decimal offerprice { get; set; }
        public byte[] codeimage { get; set; }
    }
}
