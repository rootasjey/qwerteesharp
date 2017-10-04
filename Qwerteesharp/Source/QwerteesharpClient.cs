using HtmlAgilityPack;
using Qwerteesharp.Extractors;
using Qwerteesharp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Qwerteesharp {
    /// <summary>
    /// Represents an object to query Qwertee website.
    /// </summary>
    public class QwerteesharpClient
    {
        private string _BaseURL {
            get {
                return "https://www.qwertee.com/";
            }
        }
        
        /// <summary>
        /// Get all current tees available.
        /// </summary>
        /// <returns>A list of current designs.</returns>
        public async Task<List<Design>> GetAllCurrentDesigns() {
            var designsList = new List<Design>();

            var response = await Fetch(_BaseURL);
            if (response == null) return designsList;

            var doc = new HtmlDocument();
            doc.LoadHtml(response);

            var nodesList = doc.DocumentNode
                .Descendants("div")
                .Where(x => x.GetAttributeValue("class", "").Contains("big-slide tee"))
                .ToList();

            foreach (var nodeTee in nodesList) {
                designsList.Add(DataExtractor.ExtractDesign(nodeTee));
            }

            return designsList;
        }

        /// <summary>
        /// Get today tees.
        /// </summary>
        /// <returns>A list of today designs.</returns>
        public async Task<List<Design>> GetTodayDesigns() {
            var designsList = new List<Design>();
            var response = await Fetch(_BaseURL);

            if (response == null) return designsList;

            var doc = new HtmlDocument();
            doc.LoadHtml(response);

            var nodesList = doc.DocumentNode
                .Descendants("div")
                .Where(x => x.GetAttributeValue("class", "").Contains("big-slides-wrap"))
                .First()
                .Descendants("div")
                .Where(x => x.GetAttributeValue("class", "").Contains("big-slide tee"))
                .ToList();

            foreach (var nodeTee in nodesList) {
                designsList.Add(DataExtractor.ExtractDesign(nodeTee));
            }

            return designsList;
        }

        /// <summary>
        /// Get last chance tees.
        /// </summary>
        /// <returns>A list of last chance designs.</returns>
        public async Task<List<Design>> GetLastChanceDesigns() {
            var designsList = new List<Design>();
            var response = await Fetch(_BaseURL);

            if (response == null) return designsList;

            var doc = new HtmlDocument();
            doc.LoadHtml(response);
            
            var nodesList = doc.DocumentNode
                .Descendants("div")
                .Where(x => x.GetAttributeValue("id", "").Contains("last-chance-mobile"))
                .First()
                .Descendants("div")
                .Where(x => x.GetAttributeValue("class", "").Contains("big-slide tee"))
                .ToList();

            foreach (var nodeTee in nodesList) {
                designsList.Add(DataExtractor.ExtractDesign(nodeTee));
            }

            return designsList;
        }
        

        /// <summary>
        /// Get the TimeSpan left before next sale.
        /// </summary>
        /// <returns></returns>
        public TimeSpan GetTimeSpanBeforeNextSale() {
            var timezone = TimeZoneInfo.FindSystemTimeZoneById("Romance Standard Time");
            var dateTime = TimeZoneInfo.ConvertTime(DateTime.Now, timezone);

            var offsetDay = dateTime.Hour >= 23 ? 1 : 0;

            var now = DateTime.Now;
            var refDateTime = new DateTime(now.Year, now.Month, now.Day + offsetDay, 23, 0, 0);

            return refDateTime - dateTime;
        }

        /// <summary>
        /// Fetch an URL for data.
        /// </summary>
        /// <param name="url">URL to reach.</param>
        /// <returns>Response body in text format.</returns>
        private async Task<string> Fetch(string url) {
            var http = new HttpClient();
            string responseBodyAsText;

            try {
                HttpResponseMessage message = await http.GetAsync(url);
                responseBodyAsText = await message.Content.ReadAsStringAsync();

                if (string.IsNullOrEmpty(responseBodyAsText)) return null;

                return responseBodyAsText;

            } catch { return null; }
        }
    }
}
