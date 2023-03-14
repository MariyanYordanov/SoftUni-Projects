using HouseRentingSystem.Core.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace HouseRentingSystem.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHouseService _houses;

        public HomeController(IHouseService houses)
        {
            _houses = houses;
        }

        public async Task<IActionResult> Index()
        {
            var houses = await _houses.LastThreeHouses();

            return View(houses);
        }

        public IActionResult Error(int statusCode)
        {
            if (statusCode == 400)
            {
                return View("Error400");
            }

            if (statusCode == 400)
            {
                return View("Error401");
            }

            return View();
        }

    }
}