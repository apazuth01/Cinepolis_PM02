using Cinepolis.Clases;
using Cinepolis.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
namespace Cinepolis.Controller
{
    public class peliculasHomeController
    {
        public async static Task<List<ApiPeliculasHome.ph>> ObtenerPeliculasHomeTegus()
        {
            var direc = new ruta();
            String direccion = direc.ruta_();
            List<ApiPeliculasHome.ph> listapaises = new List<ApiPeliculasHome.ph>();
            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync(direccion + "/peliculas_tegucigalpa");
                if (response.IsSuccessStatusCode)
                {
                    var contenido = response.Content.ReadAsStringAsync().Result;
                    listapaises = JsonConvert.DeserializeObject<List<ApiPeliculasHome.ph>>(contenido);
                    Console.WriteLine("Lista" + response.ToString());
                    Console.WriteLine(contenido.ToString());
                }
            }
            return listapaises;
        }



        public async static Task<List<ApiPeliculasHome.ph>> ObtenerPeliculasHomeSPS()
        {
            var direc = new ruta();
            String direccion = direc.ruta_();
            List<ApiPeliculasHome.ph> listapaises = new List<ApiPeliculasHome.ph>();
            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync(direccion + "/peliculas_sps");
                if (response.IsSuccessStatusCode)
                {
                    var contenido = response.Content.ReadAsStringAsync().Result;
                    listapaises = JsonConvert.DeserializeObject<List<ApiPeliculasHome.ph>>(contenido);
                    Console.WriteLine("Lista" + response.ToString());
                    Console.WriteLine(contenido.ToString());
                }
            }
            return listapaises;
        }

       
        public async static Task<List<contructorCompra.h>> ObtenerPagos(string correo)
        {
            var direc = new ruta();
            String direccion = direc.ruta_();
            List<contructorCompra.h> listapaises = new List<contructorCompra.h>();
            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync(direccion + "/historial/" + correo);
                if (response.IsSuccessStatusCode)
                {
                    var contenido = response.Content.ReadAsStringAsync().Result;
                   // listapaises = JsonConvert.DeserializeObject<List<ApiPeliculasHome.ph>>(contenido);
                    listapaises = JsonConvert.DeserializeObject<List<contructorCompra.h>>(contenido);
                    Console.WriteLine("Lista" + response.ToString());
                    Console.WriteLine(contenido.ToString());
                }
            }
          //  return listapaises;

      


            //using (WebClient wc = new WebClient())
            //{
                
            //    //var parametros = "id=" + idc + "&hora=" + hora;
            //    var parametros = "?correo=" + correo;
            //    var direc = new ruta();
            //    String direccion = direc.ruta_();
            //    Console.WriteLine("Link " + direccion + correo);
            //    direccion = direccion + "/historial";
            //    Console.WriteLine(parametros.ToString());
            //    wc.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
            //    string HtmlResult = wc.UploadString(direccion, "POST", parametros);
            //    Console.WriteLine(HtmlResult);
            //    //
            //    //  if (HtmlResult.)
            //    //  {
            //    // var contenido = response.Content.ReadAsStringAsync().Result;
            //    var contenido = HtmlResult.ToString();// response.Content.ReadAsStringAsync().Result;

            //    listapaises = JsonConvert.DeserializeObject<List<contructorCompra.h>>(contenido);
            //    // }
            //    //if (HtmlResult.Contains("si"))
            //    //{
            //    //    rbTres.IsVisible = true;
            //    //    lblhorario.IsVisible = true;
            //    //}
            //    //else
            //    //{
            //    //    rbTres.IsVisible = false;
            //    //    lblhorario.IsVisible = false;
            //    //}
            //}
            // MultipartFormDataContent parametros = new MultipartFormDataContent();

            // MultipartFormDataContent parametros = new MultipartFormDataContent();
            //   StringContent email = new StringContent(correo);

            // parametros.Add(email, "correo");

            //StringContent email = new StringContent("{correo: " + correo + "}");
            //using (HttpClient client = new HttpClient())

            //{
            //    //client.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
            //    //  client.DefaultRequestHeaders.Add("Content-Type", "application/json; charset=utf-8");
            //  //  var response = await client.PostAsync(direccion, parametros);
            //    var response = await client.GetAsync(direccion + "/historial/" + correo);
            //  //  Console.WriteLine("Ruta " + direccion + "/historial" + "?correo=" + correo + " Respuesta " + response);
            //    if (response.IsSuccessStatusCode)
            //    {
            //        var contenido = response.Content.ReadAsStringAsync().Result;
            //        listapaises = JsonConvert.DeserializeObject<List<contructorCompra.h>>(contenido);
            //    }
            //    //Console.WriteLine("Ruta " + direccion + "/historial" + "?correo=" + correo + " Respuesta " + response);
            //}

            return listapaises;
        }
    }
}
