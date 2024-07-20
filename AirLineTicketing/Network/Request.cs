﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using AirLineTicketing.Models;
using System.Windows;
using Newtonsoft.Json;

namespace AirLineTicketing.Network
{
    internal class Request
    {
        HttpClient httpClient;

        public Request()
        {
            httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("https://localhost:7003/api/Flights/");
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json")
                );
        }

        public async Task<List<Flight>> getAllFlights()
        {
            List<Flight> flights = null;

            try
            {
                HttpResponseMessage rawResponse = await httpClient.GetAsync("GetAllFlights");
                Response response = await getResponse(rawResponse);

                flights = response.flights;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return flights;
        }

        public async Task<Places> getAllPlaces()
        {
            Places places = null;

            try
            {
                HttpResponseMessage rawResponse = await httpClient.GetAsync("GetOriginAndDestination");
                Response response = await getResponse(rawResponse);

                places = response.places;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return places;
        }

        public async Task<List<Flight>> getFlightsByFilter(FlightsFilter filter)
        {
            List<Flight> flights = null;

            try
            {
                StringContent jsonContent = getJsonContent(filter);
                HttpResponseMessage rawResponse = await httpClient.PostAsync("GetFlightsByFilter", jsonContent);
                Response response = await getResponse(rawResponse);

                flights = response.flights;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return flights;
        }

        private StringContent getJsonContent(Object body)
        {
            string json = JsonConvert.SerializeObject(body);
            return new StringContent(json, Encoding.UTF8, "application/json");
        }

        private async Task<Response> getResponse(HttpResponseMessage httpResponseMessage)
        {
            string jsonResponse = await httpResponseMessage.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Response>(jsonResponse);
        }
    }
}