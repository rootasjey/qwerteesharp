using HtmlAgilityPack;
using Qwerteesharp.Models;
using System.Collections.Generic;
using System.Linq;

namespace Qwerteesharp.Extractors {
    internal static class DataExtractor
    {
        /// <summary>
        /// Extract the prices from node data.
        /// </summary>
        /// <param name="node">HTMLNode to extract the data from.</param>
        /// <param name="type">Type of design (tee, sweater, hoodie).</param>
        /// <returns>A new Prices class instance.</returns>
        public static Prices ExtractPrices(HtmlNode node, string type) {
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

        /// <summary>
        /// Parse and extract a Design from an HTMLNode.
        /// </summary>
        /// <param name="nodeTee">Node to extract data from.</param>
        /// <returns></returns>
        public static Design ExtractDesign(HtmlNode nodeTee) {
            var childrenNodeTee = nodeTee.Descendants("div");
            var childNodeTee = childrenNodeTee.First();
            var defaultLink = "https://www.qwertee.com/";

            var design = new Design {
                Id = nodeTee.GetAttributeValue("id", ""),
                Name = childNodeTee.GetAttributeValue("data-name", ""),
                Link = defaultLink,
                Tee = new Tee() {
                    ImagesUrls = new List<string>(),
                    Prices = ExtractPrices(childNodeTee, "tee")
                },
                Hoodie = new Hoodie() {
                    Prices = ExtractPrices(childNodeTee, "hoodie")
                },
                Sweater = new Sweater() {
                    Prices = ExtractPrices(childNodeTee, "sweater")
                },
                Author = new User() {
                    Id = childNodeTee.GetAttributeValue("data-user-id", ""),
                    Name = childNodeTee.GetAttributeValue("data-user", "")
                }
            };

            design = AddImagesToDesign(design, childNodeTee);

            return design;
        }

        /// <summary>
        /// Populate a Design with images.
        /// </summary>
        /// <param name="design">Design to populate.</param>
        /// <param name="childNodeTee">Node to extract data from.</param>
        /// <returns></returns>
        public static Design AddImagesToDesign(Design design, HtmlNode childNodeTee) {
            var picture = childNodeTee.Descendants("picture").First();
            var img = picture.Descendants("img").First();
            var imgMensSource = img.GetAttributeValue("src", "");
            var imgWomensSource = imgMensSource.Replace("-mens-", "-womens-");
            var imgKidsSource = imgMensSource.Replace("-mens-", "-kids-");
            var imgHoodieSource = imgMensSource.Replace("-mens-", "-hoodie-");
            var imgSweaterSource = imgMensSource.Replace("-mens-", "-sweater-");
            var imgZoomSource = imgMensSource.Replace("-mens-", "-zoom-");

            design.ImageUrl = FormatUrl(imgZoomSource);

            design.Tee.ImagesUrls.Add(FormatUrl(imgMensSource));
            design.Tee.ImagesUrls.Add(FormatUrl(imgWomensSource));
            design.Tee.ImagesUrls.Add(FormatUrl(imgKidsSource));

            design.Hoodie.ImageUrl = FormatUrl(imgHoodieSource);
            design.Sweater.ImageUrl = FormatUrl(imgSweaterSource);

            return design;
        }

        private static string FormatUrl(string url) {
            if (url.StartsWith("//")) {
                return $"https:{url}";
            }

            return url;
        }
    }
}
