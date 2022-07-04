using System.Collections.Generic;
using System.Threading.Tasks;
using Inventory_Sytem.Models;
using System.Net.Http;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace Inventory_Sytem.Repositories {
    public class ProductRepository {

        private HttpClientHandler clientHandler = new HttpClientHandler();
        private HttpClient client;

        public ProductRepository() {
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
            client = new HttpClient(clientHandler);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("aplication/json"));
            client.BaseAddress = new System.Uri("https://localhost:5001/");
        }

        public async Task<List<Product>> GetProducts() {
            var result = await client.GetAsync("v1/products");
            var content = await result.Content.ReadAsStringAsync();

            var teste = JsonConvert.DeserializeObject<List<Product>>(content);

            return JsonConvert.DeserializeObject<List<Product>>(content);
        }

        public async Task<Product> GetProductById(int id) {
            var result = await client.GetAsync("v1/products/" + id);
            var content = await result.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<Product>(content);
        }

        public async Task<Product> GetProductByName(string name) {
            var result = await client.GetAsync("v1/products/name/" + name);
            var content = await result.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<Product>(content);
        }

    }
}
