using Assignment1_FarmersMarketApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Windows;

namespace Assignment1_FarmersMarketApp.API
{
    internal class RestApiRequest
    {
        HttpClient httpClient;

        public RestApiRequest() {
            httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("https://localhost:7238/api/Product/");
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json")
                );
        }

        public async Task<int> postProductApi(Product product) {
            int status = 0;

            try
            {
                StringContent jsonContent = getJsonContent(product);
                HttpResponseMessage rawResponse = await httpClient.PostAsync("AddProduct", jsonContent);
                Response response = await getResponse(rawResponse);

                MessageBox.Show(response.statusMessage);

                if (response.statusCode == 200) {
                    status = 1;
                }
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }

            return status;
        }

        public async Task<int> putProductApi(Product product) {
            int status = 0;

            try
            {
                StringContent jsonContent = getJsonContent(product);

                HttpResponseMessage rawResponse = await httpClient.PutAsync(
                    "UpdateProductById/" + product.id, jsonContent);
                Response response = await getResponse(rawResponse);

                MessageBox.Show(response.statusMessage);

                if(response.statusCode == 200)
                {
                    status = 1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return status;
        }

        private StringContent getJsonContent(Product product)
        {
            string json = JsonConvert.SerializeObject(product);
            return new StringContent(json, Encoding.UTF8, "application/json");
        }

        private async Task<Response> getResponse(HttpResponseMessage httpResponseMessage) {
            string jsonResponse = await httpResponseMessage.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Response>(jsonResponse);
        }
    }
}
