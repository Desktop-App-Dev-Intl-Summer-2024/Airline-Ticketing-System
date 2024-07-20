using Assignment1_FarmersMarketApp.Models;
using System.Text;

using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Windows;
using System.Collections;

namespace Assignment1_FarmersMarketApp.API
{
    internal class RestApiRequest
    {
        HttpClient httpClient;

        //CONSTRUCTOR
        public RestApiRequest() {
            httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("https://localhost:7238/api/Product/");
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json")
                );
        }

        //GET ALL PRODUCTS
        public async Task<List<Product>> getAllProducts() {
            List<Product> products = null;

            try {
                HttpResponseMessage rawResponse = await httpClient.GetAsync("GetAllProducts");
                Response response = await getResponse(rawResponse);

                products = response.products;
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }

            return products;
        }

        //GET INDIVIDUAL PRODUCT
        public async Task<Product> getProduct(int id)
        {
            Product product = null;

            try
            {
                HttpResponseMessage rawResponse = await httpClient.GetAsync("GetProduct/" + id);
                Response response = await getResponse(rawResponse);

                product = response.product;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return product;
        }

        //ADD PRODUCT
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

        //UPDATE PRODUCT BY ID
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

        //DELETE PRODUCT
        public async Task<int> deleteProductApi(int id)
        {
            int status = 0;

            try
            {
                HttpResponseMessage rawResponse = await httpClient.DeleteAsync(
                    "DeleteProduct/" + id);
                Response response = await getResponse(rawResponse);

                MessageBox.Show(response.statusMessage);

                if (response.statusCode == 200)
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

        //UPDATE DB WITH PURCHASE
        public async Task<int> updateDbWithPurchase(ArrayList selectedProducts)
        {
            int status = 0;

            try
            {
                StringContent jsonContent = getJsonContent(selectedProducts);

                HttpResponseMessage rawResponse = await httpClient.PutAsync(
                    "UpdateDbWithPurchase/", jsonContent);
                Response response = await getResponse(rawResponse);

                MessageBox.Show(response.statusMessage);

                if (response.statusCode == 200)
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

        //JSONCONTENT GETTER
        private StringContent getJsonContent(object body)
        {
            string json = JsonConvert.SerializeObject(body);
            return new StringContent(json, Encoding.UTF8, "application/json");
        }

        //RESPONSE GETTER
        private async Task<Response> getResponse(HttpResponseMessage httpResponseMessage) {
            string jsonResponse = await httpResponseMessage.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Response>(jsonResponse);
        }
    }
}
