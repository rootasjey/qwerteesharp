using Microsoft.VisualStudio.TestTools.UnitTesting;
using Qwerteesharp;
using System.Threading.Tasks;

namespace QwerteesharpTest {
    [TestClass]
    public class APITests {
        private QwerteesharpClient _Client { get; set; }

        /// <summary>
        /// Ensure client is initialized.
        /// </summary>
        private void InitalizeClient() {
            if (_Client == null) {
                _Client = new QwerteesharpClient();
            }
        }

        /// <summary>
        /// Test the correct instanciation.
        /// </summary>
        [TestMethod]
        public void ClientInstantationTest() {
            InitalizeClient();

            Assert.IsNotNull(_Client);
        }

        /// <summary>
        /// Test the method returns all current design from Qwertee.
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task GetAllCurrentDesignsTest() {
            InitalizeClient();

            var currentDesigns = await _Client.GetAllCurrentDesigns();

            Assert.IsNotNull(currentDesigns);
            Assert.IsTrue(currentDesigns.Count > 0);

            var firstDesign = currentDesigns[0];

            Assert.IsNotNull(firstDesign.Id);
            Assert.IsNotNull(firstDesign.Name);
            Assert.IsNotNull(firstDesign.Author);
            Assert.IsNotNull(firstDesign.ImageUrl);

            Assert.IsNotNull(firstDesign.Tee);
            Assert.IsNotNull(firstDesign.Hoodie);
            Assert.IsNotNull(firstDesign.Sweater);

            Assert.IsNotNull(firstDesign.Tee.ImagesUrls);
            Assert.IsNotNull(firstDesign.Tee.Prices);

            Assert.IsTrue(firstDesign.Tee.ImagesUrls.Count > 0);

            Assert.IsNotNull(firstDesign.Hoodie.ImageUrl);
            Assert.IsNotNull(firstDesign.Hoodie.Prices);

            Assert.IsNotNull(firstDesign.Sweater.ImageUrl);
            Assert.IsNotNull(firstDesign.Sweater.Prices);
        }

        /// <summary>
        /// Test the method returns today design from Qwertee.
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task GetTodayDesignsTest() {
            InitalizeClient();

            var todayDesigns = await _Client.GetTodayDesigns();

            Assert.IsNotNull(todayDesigns);

            Assert.IsTrue(todayDesigns.Count > 0);

            var firstDesign = todayDesigns[0];

            Assert.IsNotNull(firstDesign.Id);
            Assert.IsNotNull(firstDesign.Name);
            Assert.IsNotNull(firstDesign.Author);
            Assert.IsNotNull(firstDesign.ImageUrl);

            Assert.IsNotNull(firstDesign.Tee);
            Assert.IsNotNull(firstDesign.Hoodie);
            Assert.IsNotNull(firstDesign.Sweater);

            Assert.IsNotNull(firstDesign.Tee.ImagesUrls);
            Assert.IsNotNull(firstDesign.Tee.Prices);

            Assert.IsTrue(firstDesign.Tee.ImagesUrls.Count > 0);

            Assert.IsNotNull(firstDesign.Hoodie.ImageUrl);
            Assert.IsNotNull(firstDesign.Hoodie.Prices);

            Assert.IsNotNull(firstDesign.Sweater.ImageUrl);
            Assert.IsNotNull(firstDesign.Sweater.Prices);
        }

        /// <summary>
        /// Test the method returns last chance design from Qwertee.
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task GetLastChanceDesignsTest() {
            InitalizeClient();

            var lastChanceDesigns = await _Client.GetLastChanceDesigns();

            Assert.IsNotNull(lastChanceDesigns);


            Assert.IsTrue(lastChanceDesigns.Count > 0);

            var firstDesign = lastChanceDesigns[0];

            Assert.IsNotNull(firstDesign.Id);
            Assert.IsNotNull(firstDesign.Name);
            Assert.IsNotNull(firstDesign.Author);
            Assert.IsNotNull(firstDesign.ImageUrl);

            Assert.IsNotNull(firstDesign.Tee);
            Assert.IsNotNull(firstDesign.Hoodie);
            Assert.IsNotNull(firstDesign.Sweater);

            Assert.IsNotNull(firstDesign.Tee.ImagesUrls);
            Assert.IsNotNull(firstDesign.Tee.Prices);

            Assert.IsTrue(firstDesign.Tee.ImagesUrls.Count > 0);

            Assert.IsNotNull(firstDesign.Hoodie.ImageUrl);
            Assert.IsNotNull(firstDesign.Hoodie.Prices);

            Assert.IsNotNull(firstDesign.Sweater.ImageUrl);
            Assert.IsNotNull(firstDesign.Sweater.Prices);
        }

        /// <summary>
        /// Test the method returns the correct TimeSpan before the next sale.
        /// </summary>
        [TestMethod]
        public void GetTimeSpanBeforeNextSaleTest() {
            InitalizeClient();

            var time = _Client.GetTimeSpanBeforeNextSale();

            Assert.IsNotNull(time);
            Assert.IsTrue(time.Hours <= 23);
            Assert.IsTrue(time.TotalHours > 0);
        }
    }
}
