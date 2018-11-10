using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using BeadCSharpMobileApp.Models;

namespace BeadCSharpMobileApp.Services{

    public class AzureBeadService : IBeadRepo<Bead>{

        HttpClient client;
        IEnumerable<Bead> beads;

        public AzureBeadService(){
            client = new HttpClient();
            client.BaseAddress = new Uri($"{App.AzureBackendUrl}/");
            beads = new List<Bead>();
        }

        public async Task<IEnumerable<Bead>> GetItemsAsync(bool forceRefresh = false){
            if (forceRefresh){
                var json = await client.GetStringAsync($"api/bead");
                beads = await Task.Run(() => JsonConvert.DeserializeObject<IEnumerable<Bead>>(json));
            }
            return beads;
        }

        public async Task<Bead> GetItemAsync(string id){
            if (id != null){
                var json = await client.GetStringAsync($"api/bead/{id}");
                return await Task.Run(() => JsonConvert.DeserializeObject<Bead>(json));
            }
            return null;
        }

        public async Task<bool> AddItemAsync(Bead bead){
            if (bead == null)
                return false;
            var serializedItem = JsonConvert.SerializeObject(bead);
            var response = await client.PostAsync($"api/bead", new StringContent(serializedItem, Encoding.UTF8, "application/json"));
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> UpdateItemAsync(Bead bead){
            if (bead == null || bead.Id == null)
                return false;
            var serializedItem = JsonConvert.SerializeObject(bead);
            var buffer = Encoding.UTF8.GetBytes(serializedItem);
            var byteContent = new ByteArrayContent(buffer);
            var response = await client.PutAsync(new Uri($"api/bead/{bead.Id}"), byteContent);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteItemAsync(string id){
            if (string.IsNullOrEmpty(id))
                return false;
            var response = await client.DeleteAsync($"api/bead/{id}");
            return response.IsSuccessStatusCode;
        }
    }
}