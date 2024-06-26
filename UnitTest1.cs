using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using NUnit.Framework;

namespace similaryachts
{
    [Parallelizable(ParallelScope.Self)]
    [TestFixture]
    public class ExampleTest : PageTest
    {
        [SetUp]
        public async Task Setup()
        {
            await Page.GotoAsync("https://web-dev.bluebnc.com/en-us/boat/1555/catamaran-yacht-charter-mallorca-sunreef-74");
        }

        [Test]
        public async Task Similar_yacht()
        // checks  if there are  similar yachts
        {
            // await Expect(Page).ToHaveTitleAsync("Sunseeker 95 | Bluebnc");

             var divSelector = "div.card-group.scroll-x.scroll-x-hidden.grid.grid-auto-col.grid-col-lg-4.gap-1.gap-md-2";


            var divElement = await Page.QuerySelectorAsync(divSelector);
            
            var similaryachts = await divElement.QuerySelectorAllAsync("a");

            Assert.IsNotEmpty(similaryachts);
        }

        [Test]

        public  async  Task Related_itineraries()
        //checks  if there is related itineraries sections
        {
            var divSelector = "div.itinerary-wrapper";


            var divElement = await Page.QuerySelectorAsync(divSelector);

            var relatedItineraries = await divElement.QuerySelectorAllAsync("a");


            Assert.IsNotEmpty(relatedItineraries);
        }

        [Test]

        public async Task CheckDescription()
        //description section
        {
     
            var descriptionDivSelector = "div.description";

       
            var descriptionDivElement = await Page.QuerySelectorAsync(descriptionDivSelector);

      
            Assert.IsNotNull(descriptionDivElement);


            var innerHTML = await descriptionDivElement.InnerHTMLAsync();
            
       
            Assert.IsNotEmpty(innerHTML.Trim());
        }

        [Test]


    public async Task PricingDetail()
       //pricing section
    {
         var pricingDivSelector = "div.pricing-detail";

       
            var pricingDivElement = await Page.QuerySelectorAsync(pricingDivSelector);

      
            Assert.IsNotNull(pricingDivElement);


            var innerHTML = await pricingDivElement.InnerHTMLAsync();
            
       
            Assert.IsNotEmpty(innerHTML.Trim());
    }

    [Test]
    
        public async  Task Specification()
           //specification section
        {
              var specificationDivSelector = "div.specification";

       
            var specificationDivElement = await Page.QuerySelectorAsync(specificationDivSelector);

      
            Assert.IsNotNull(specificationDivElement);


            var innerHTML = await specificationDivElement.InnerHTMLAsync();
            
       
            Assert.IsNotEmpty(innerHTML.Trim());

        }

        [Test]

        public async Task Amenity()
           //amenity section
        {
             var amenityDivSelector = "div.amenity";

       
            var amenityDivElement = await Page.QuerySelectorAsync(amenityDivSelector);

      
            Assert.IsNotNull(amenityDivElement);


            var innerHTML = await amenityDivElement.InnerHTMLAsync();
            
       
            Assert.IsNotEmpty(innerHTML.Trim());

        }

        [Test]

        public async Task Destination()
           //destination section
    {
        var destinationDivSelector = "div.available-destination";

       
            var destinationDivElement = await Page.QuerySelectorAsync(destinationDivSelector);

      
            Assert.IsNotNull(destinationDivElement);


            var innerHTML = await destinationDivElement.InnerHTMLAsync();
            
       
            Assert.IsNotEmpty(innerHTML.Trim());

    }



        [TearDown]
        public async Task TearDown()
        {
           
            await Page.CloseAsync();
        }
    }
}





// //run settings  are  set  for  chomium -  dotnet  test --settings:demo.runsettings
