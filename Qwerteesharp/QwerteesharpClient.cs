using HtmlAgilityPack;
using Qwerteesharp.Models;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Qwerteesharp {
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
            var teesList = new List<Design>();
            var response = await Fetch(_BaseURL);

            if (response == null) return teesList;

            var doc = new HtmlDocument();
            doc.LoadHtml(response);

            var nodesList = doc.DocumentNode
                .Descendants("div")
                .Where(x => x.GetAttributeValue("class", "").Contains("big-slide tee"))
                .ToList();

            foreach (var node in nodesList) {
                var children = node.Descendants("div");
                var child = children.First();

                var design = new Design {
                    Id = node.GetAttributeValue("id", ""),
                    Name = child.GetAttributeValue("data-name", ""),
                    Tee = new Tee() {
                        ImagesUrls = new List<string>(),
                        //Prices = new Prices() {
                        //    EUR = new Price() {
                        //        Currency = child.GetAttributeValue("data-cursym-eur", ""),
                        //        Value = float.Parse(child.GetAttributeValue("data-tee-price-eur", ""))
                        //    },
                        //    GBP = new Price() {
                        //        Currency = child.GetAttributeValue("data-cursym-gbp", ""),
                        //        Value = float.Parse(child.GetAttributeValue("data-tee-price-gbp", ""))
                        //    },
                        //    USD = new Price() {
                        //        Currency = child.GetAttributeValue("data-cursym-usd", ""),
                        //        Value = float.Parse(child.GetAttributeValue("data-tee-price-usd", ""))
                        //    }
                        //}
                        Prices = ExtractPrices(child, "tee")
                    },
                    Hoodie = new Hoodie() {
                        //Prices = new Prices() {
                        //    EUR = new Price() {
                        //        Currency = child.GetAttributeValue("data-cursym-eur", ""),
                        //        Value = float.Parse(child.GetAttributeValue("data-hoodie-price-eur", ""))
                        //    },
                        //    GBP = new Price() {
                        //        Currency = child.GetAttributeValue("data-cursym-gbp", ""),
                        //        Value = float.Parse(child.GetAttributeValue("data-hoodie-price-gbp", ""))
                        //    },
                        //    USD = new Price() {
                        //        Currency = child.GetAttributeValue("data-cursym-usd", ""),
                        //        Value = float.Parse(child.GetAttributeValue("data-hoodie-price-usd", ""))
                        //    }
                        //}
                        Prices = ExtractPrices(child, "hoodie")
                    },
                    Sweater = new Sweater() {
                        //Prices = new Prices() {
                        //    EUR = new Price() {
                        //        Currency = child.GetAttributeValue("data-cursym-eur", ""),
                        //        Value = float.Parse(child.GetAttributeValue("data-sweater-price-eur", ""))
                        //    },
                        //    GBP = new Price() {
                        //        Currency = child.GetAttributeValue("data-cursym-gbp", ""),
                        //        Value = float.Parse(child.GetAttributeValue("data-sweater-price-gbp", ""))
                        //    },
                        //    USD = new Price() {
                        //        Currency = child.GetAttributeValue("data-cursym-usd", ""),
                        //        Value = float.Parse(child.GetAttributeValue("data-sweater-price-usd", ""))
                        //    }
                        //}
                        Prices = ExtractPrices(child, "sweater")
                    },
                    Author = new User() {
                        Id = child.GetAttributeValue("data-user-id", ""),
                        Name = child.GetAttributeValue("data-user", "")
                    }
                };

                var picture = child.Descendants("pictures").First();
                var img = picture.Descendants("img").First();
                design.Tee.ImagesUrls.Add(img.GetAttributeValue("src", ""));

                teesList.Add(design);
            }

            return teesList;
        }

        /// <summary>
        /// Get today tees.
        /// </summary>
        /// <returns>A list of today designs.</returns>
        public async Task<List<Design>> GetTodayDesigns() {
            var teesList = new List<Design>();
            var response = await Fetch(_BaseURL);

            if (response == null) return teesList;

            var doc = new HtmlDocument();
            doc.LoadHtml(response);

            var nodesList = doc.DocumentNode
                .Descendants("big-slides-wrap")
                .First()
                .Descendants("div")
                .Where(x => x.GetAttributeValue("class", "").Contains("big-slide tee"))
                .ToList();

            foreach (var node in nodesList) {
                var children = node.Descendants("div");
                var child = children.First();

                var design = new Design {
                    Id = node.GetAttributeValue("id", ""),
                    Name = child.GetAttributeValue("data-name", ""),
                    Tee = new Tee() {
                        ImagesUrls = new List<string>(),
                        Prices = ExtractPrices(child, "tee")
                    },
                    Hoodie = new Hoodie() {
                        Prices = ExtractPrices(child, "hoodie")
                    },
                    Sweater = new Sweater() {
                        Prices = ExtractPrices(child, "sweater")
                    },
                    Author = new User() {
                        Id = child.GetAttributeValue("data-user-id", ""),
                        Name = child.GetAttributeValue("data-user", "")
                    }
                };

                var picture = child.Descendants("pictures").First();
                var img = picture.Descendants("img").First();
                design.Tee.ImagesUrls.Add(img.GetAttributeValue("src", ""));

                teesList.Add(design);
            }

            return teesList;
        }

        /// <summary>
        /// Get last chance tees.
        /// </summary>
        /// <returns>A list of last chance designs.</returns>
        public async Task<List<Design>> GetLastChanceDesigns() {
            var teesList = new List<Design>();
            var response = await Fetch(_BaseURL);

            if (response == null) return teesList;

            var doc = new HtmlDocument();
            doc.LoadHtml(response);

            var nodesList = doc.DocumentNode
                .Descendants("big-slides-wrap")
                .First()
                .Descendants("div")
                .Where(x => x.GetAttributeValue("class", "").Contains("big-slide tee"))
                .ToList();

            foreach (var node in nodesList) {
                var children = node.Descendants("div");
                var child = children.First();

                var design = new Design {
                    Id = node.GetAttributeValue("id", ""),
                    Name = child.GetAttributeValue("data-name", ""),
                    Tee = new Tee() {
                        ImagesUrls = new List<string>(),
                        Prices = ExtractPrices(child, "tee")
                    },
                    Hoodie = new Hoodie() {
                        Prices = ExtractPrices(child, "hoodie")
                    },
                    Sweater = new Sweater() {
                        Prices = ExtractPrices(child, "sweater")
                    },
                    Author = new User() {
                        Id = child.GetAttributeValue("data-user-id", ""),
                        Name = child.GetAttributeValue("data-user", "")
                    }
                };

                var picture = child.Descendants("pictures").First();
                var img = picture.Descendants("img").First();
                design.Tee.ImagesUrls.Add(img.GetAttributeValue("src", ""));

                teesList.Add(design);
            }

            return teesList;
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

        /// <summary>
        /// Extract the prices from node data.
        /// </summary>
        /// <param name="node">HTMLNode to extract the data from.</param>
        /// <param name="type">Type of design (tee, sweater, hoodie).</param>
        /// <returns>A new Prices class instance.</returns>
        private Prices ExtractPrices(HtmlNode node, string type) {
            var prefix = string.Format("data-{0}-price", type);

            return new Prices() {
                EUR = new Price() {
                    Currency = node.GetAttributeValue("data-cursym-eur", ""),
                    Value = float.Parse(node.GetAttributeValue(string.Format("{0}-eur", prefix), ""))
                },
                GBP = new Price() {
                    Currency = node.GetAttributeValue("data-cursym-gbp", ""),
                    Value = float.Parse(node.GetAttributeValue(string.Format("{0}-gbp", prefix), ""))
                },
                USD = new Price() {
                    Currency = node.GetAttributeValue("data-cursym-usd", ""),
                    Value = float.Parse(node.GetAttributeValue(string.Format("{0}-usd", prefix), ""))
                }
            };
        }
    }
}
