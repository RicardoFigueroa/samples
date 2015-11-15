using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Sismuni.Agente.Servicio.Dto.Tramite
{
  
    public class TramiteDto
    {

      
        public string NroTramite { get; set; }

    
        public int CodigoAdministrado { get; set; }

       
        public string FechaEmision { get; set; }

  
        public int NroExpediente { get; set; }

     
        public string Observaciones { get; set; }

        public IEnumerable<DetalleTramiteDto> detalleExpediente { get; set; }

    }
}
