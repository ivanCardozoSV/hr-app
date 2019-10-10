using HrApp.API.DTO;
using HrApp.API.Exceptions;
using HrApp.API.Interfaces;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Polly;
using Polly.CircuitBreaker;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace HrApp.API
{
    public class HRApi : IHRApi
    {
        private static HRApi instance;

        public static HRApi getApi()
        {
            if (instance == null)
                instance = new HRApi();
            return instance;
        }

        private Credentials credentials;
        private Policy policy;

        private HRApi()
        {
            var retry = Policy
                       .Handle<InvalidCredentialsException>().Retry(1);
            var circuit = Policy.Handle<Exception>().CircuitBreaker(5, TimeSpan.FromMinutes(2));

            policy = Policy.Wrap(retry, circuit);
        }

        public void Setup(string user, string password)
        {
            if (user == null || password == null)
                throw new Exception("Error en usuario y contraseña");
            if (credentials != null && user == credentials.Username && password == credentials.Password)
                return;
            credentials = new Credentials
            {
                Password = password,
                Username = user
            };
        }



        public string Execute(HttpCommand httpCommand)
        {
            try
            {
                var res = policy.Execute(() => InternalExecute(httpCommand));

                return res;
            }
            catch (BrokenCircuitException e)
            {
                throw new Exception("API seems to be not working. Retry in 1 minute");
            }
            //return Execute(httpCommand, false);
        }


        private string InternalExecute(HttpCommand httpCommand)
        {
            HttpResponseMessage res = null;
            try
            {
                res = httpCommand.Execute();
            }
            catch (AggregateException ex)
            {
                ex.Handle(e =>
                {
                    if (e is HttpRequestException) throw new ConnectionException("No se pudo conectar");
                    if (e is TaskCanceledException) throw new Exceptions.TimeoutException("Tiempo de espera agotado");
                    throw new Exception("Error en la conexión a la API ");
                });
            }

            switch (res.StatusCode)
            {
                case System.Net.HttpStatusCode.Forbidden:
                    throw new InvalidCredentialsException("Api is current unavailable or you don't have access");
                case System.Net.HttpStatusCode.InternalServerError:
                    throw new Exception("Server error");
                case System.Net.HttpStatusCode.Unauthorized:
                    throw new InvalidCredentialsException("User is not authorized");
                default:
                    break;
            }


            if (res.StatusCode != System.Net.HttpStatusCode.Created
                && res.StatusCode != System.Net.HttpStatusCode.OK)
            {
                JObject jsonObj = new JObject();
                var resStsr = res.Content.ReadAsStringAsync();
                var rest = resStsr.Result;
                //var error = JsonConvert.DeserializeObject<Error>(rest);
                //var sb = new System.Text.StringBuilder();
                //foreach (var item in error.errors)
                //{
                //    sb.AppendLine(item.mensaje);
                //}
                //throw new Exception(sb.ToString());
            }

            var resStr = res.Content.ReadAsStringAsync();
            resStr.Wait();

            return resStr.Result;
        }



        private void GenerateToken()
        {
            var credentialsss = new Credentials
            {
                Username = "tomas.rebollo@softvision.com",
                Password = "softvision627",
            };
            AuthenticationCommand command = new AuthenticationCommand(credentialsss);
            var auth = InternalExecute(command);
            var token = JsonConvert.DeserializeObject<Token>(auth);
            HttpReceiver.GetReceiver().SetToken(token.Id_Token);
        }

    }
}
