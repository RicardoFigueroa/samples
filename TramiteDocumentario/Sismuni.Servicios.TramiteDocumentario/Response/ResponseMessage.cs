using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sismuni.Agente.Servicio.Dto.Tramite;


namespace Sismuni.Service.Web.TramiteDocumentario.Response
{
    public class ResponseMessage
    {
        public HeadMessage _HeadMessage { get; set; }
        public List<TramiteDto> _BodyMessage { get; set; }
    }
}