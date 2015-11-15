using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sismuni.Service.Web.TramiteDocumentario.Response
{
    public class AvanceHead
    {
        public String ResponseCode { get; set; }
        public IEnumerable<String> ResponseMessage { get; set; }
    }
}