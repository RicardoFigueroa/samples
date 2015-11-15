using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;


namespace Sismuni.Agente.Servicio.Dto.Tramite
{

    public class AvanceDto
    {

      
        public string TipoRegistro { get; set; }

     
        public String FechaAvance { get; set; }

       
        public string Observaciones { get; set; }

        
        public string IdTipoTramiteEstado { get; set; }

       
        public string IdTramite { get; set; }

       
        public DetalleTramiteDto DetalleExpediente { get; set; }

        
    }
}
