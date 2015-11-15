using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using Sismuni.Service.Web.TramiteDocumentario.Response;
using Sismuni.Agente.Servicio.Dto.Tramite;


namespace TramiteDocumetarioServiceClient
{
    class Program
    {
        static void Main(string[] args)
        {
            consultarTramitesPendiantes().Wait();
            registrarAvanceTipoRegistroUno().Wait();
            registrarAvanceTipoRegistroDos().Wait();
            registrarAvanceTipoRegistroTres().Wait();
            string read = Console.ReadLine();
        }

        static async Task consultarTramitesPendiantes()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://52.26.20.117/servicio/TramiteDocumentario/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = await client.GetAsync("Tramite.svc/5");
                Console.WriteLine(response.IsSuccessStatusCode);
                if (response.IsSuccessStatusCode)
                {
                    ResponseMessage _ResponseMessage = await response.Content.ReadAsAsync<ResponseMessage>();
                    Console.WriteLine("ResponseMessage: " + _ResponseMessage._HeadMessage.ResponseMessage);

                    
                        foreach(TramiteDto _TramiteDto in _ResponseMessage._BodyMessage)
                        {
                            Console.WriteLine("NroExpediente: " + _TramiteDto.NroExpediente);
                            Console.WriteLine("NroTramite: " + _TramiteDto.NroTramite);
                            Console.WriteLine("CodigoAdministrado: " + _TramiteDto.CodigoAdministrado);
                            Console.WriteLine("Observaciones: " + _TramiteDto.Observaciones);
                            Console.WriteLine("FechaEmision: " + _TramiteDto.FechaEmision);
                            Console.WriteLine("              ::::detalleExpediente::::");

                            foreach (DetalleTramiteDto _DetalleTramiteDto in _TramiteDto.detalleExpediente)
                            {
                                Console.WriteLine("                                                      ");
                                Console.WriteLine("CodigoRequisito: " + _DetalleTramiteDto.CodigoRequisito);
                                Console.WriteLine("InformacionRequisito: " + _DetalleTramiteDto.InformacionRequisito);
                                Console.WriteLine("NroFolio: " + _DetalleTramiteDto.NroFolio);
                                Console.WriteLine("RutaArchivo: " + _DetalleTramiteDto.RutaArchivo);
                            
                            }

                        }

                }
            }
        }

        static async Task registrarAvanceTipoRegistroUno()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://52.26.20.117/servicio/TramiteDocumentario/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));


                var Avance = new AvanceDto() { TipoRegistro = "1", 
                                                              FechaAvance = "14/11/2015", 
                                                              Observaciones ="Tramite",
                                                              IdTipoTramiteEstado = "1",
                                                              IdTramite = "1"
                                                              };

                HttpResponseMessage response = await client.PostAsJsonAsync("Tramite.svc/avance", Avance);

                if (response.IsSuccessStatusCode)
                {
                    AvanceResponse _ResponseMessage = await response.Content.ReadAsAsync<AvanceResponse>();
                    Console.WriteLine("ResponseMessage TipoRegistro 1 : " + _ResponseMessage._HeadMessage.ResponseCode);

                }
            }
        }

        static async Task registrarAvanceTipoRegistroDos()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://52.26.20.117/servicio/TramiteDocumentario/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));


                var Avance = new AvanceDto()
                {
                    TipoRegistro = "2",
                    IdTramite = "1",
                    DetalleExpediente = new DetalleTramiteDto() { 
                         CodigoRequisito = "1",
                         InformacionRequisito = "Numero de solicitud",
                         RutaArchivo = "/modelo/trama/planos2.pdf"
                    }
                };

                HttpResponseMessage response = await client.PostAsJsonAsync("Tramite.svc/avance", Avance);

                if (response.IsSuccessStatusCode)
                {
                    AvanceResponse _ResponseMessage = await response.Content.ReadAsAsync<AvanceResponse>();
                    Console.WriteLine("ResponseMessage TipoRegistro 2 : " + _ResponseMessage._HeadMessage.ResponseCode);

                }
            }
        }

        static async Task registrarAvanceTipoRegistroTres()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://52.26.20.117/servicio/TramiteDocumentario/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));


                var Avance = new AvanceDto()
                {
                    TipoRegistro = "3",
                    FechaAvance = "14/11/2015",
                    Observaciones = "Tramite",
                    IdTipoTramiteEstado = "1",
                    IdTramite = "1",
                    DetalleExpediente = new DetalleTramiteDto()
                    {
                        CodigoRequisito = "1",
                        InformacionRequisito = "Numero de solicitud",
                        RutaArchivo = "/modelo/trama/planos2.pdf"
                    }
                };

                HttpResponseMessage response = await client.PostAsJsonAsync("Tramite.svc/avance", Avance);

                if (response.IsSuccessStatusCode)
                {
                    AvanceResponse _ResponseMessage = await response.Content.ReadAsAsync<AvanceResponse>();
                    Console.WriteLine("ResponseMessage TipoRegistro 3 : " + _ResponseMessage._HeadMessage.ResponseCode);

                }
            }
        }
    }
}
/*

{
	"TipoRegistro":1,
	"FechaAvance":"14/11/2015",
	"Observaciones":"no presenta observaciones por ahora",
	"IdTipoTramiteEstado":"1",
	"IdTramite":"1"
}

{
	"TipoRegistro":2,
	"IdTramite":"1",
	"DetalleExpediente":{
		"CodigoRequisito":"1",
		"InformacionRequisito":"Numero de solicitud",
		"RutaArchivo":"/modelo/trama/planos.pdf"
	}
}
 
{
	"TipoRegistro":3,
	"FechaAvance":"14/11/2015",
	"Observaciones":"no presenta observaciones por ahora",
	"IdTipoTramiteEstado":"1",
	"IdTramite":"1",
	"DetalleExpediente":{
		"CodigoRequisito":"1",
		"InformacionRequisito":"Numero de solicitud",
		"RutaArchivo":"/modelo/trama/planos.pdf"
	}
}


 
*/