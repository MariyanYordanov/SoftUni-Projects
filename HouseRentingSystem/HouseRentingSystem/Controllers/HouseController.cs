using HouseRentingSystem.Core.Contracts;
using HouseRentingSystem.Core.Models.House;
using HouseRentingSystem.Extension;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HouseRentingSystem.Controllers
{
    [Authorize]
    public class HouseController : Controller
    {
        private readonly IHouseService _houses;
        private readonly IAgentService _agents;

        public HouseController(IHouseService houses, IAgentService agents)
        {
            _houses = houses;
            _agents = agents;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> All([FromQuery] AllHousesQueryModel queryModel)
        {
            var queryResult = await _houses.All(
                queryModel.Category,
                queryModel.SearchTerm,
                queryModel.Sorting,
                queryModel.CurrentPage,
                AllHousesQueryModel.HousesPerPage);

            queryModel.TotalHousesCount = queryResult.TotalHouseCount;
            queryModel.Categories = await _houses.AllCategoryNames();
            queryModel.Houses = queryResult.Houses;

            return View(queryModel);
        }

        [HttpGet]
        public async Task<IActionResult> Mine()
        {
            IEnumerable<HouseServiceModel> myHouses;

            var userId = User.Id();
            if (await _agents.ExistsById(userId))
            {
                int currentAgentId = await _agents.GetAgentId(userId);

                myHouses = await _houses.AllHousesByAgentId(currentAgentId);
            }
            else
            {
                myHouses = await _houses.AllHousesByUserId(userId);
            }

            return View(myHouses);
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            if (!await _houses.Exists(id))
            {
                return RedirectToAction(nameof(All));
            }

            var model = await _houses.HouseDetailsById(id);

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            if ((await _agents.ExistsById(User.Id())) == false)
            {
                return RedirectToAction(nameof(AgentsController.Become), "Agents");
            }

            return View(new HouseFormModel()
            {
                HouseCategories = await _houses.AllCategoties()
            });
        }
        
        [HttpPost]
        public async Task<IActionResult> Add(HouseFormModel model)
        {
            if ((await _agents.ExistsById(User.Id())) == false)
            {
                return RedirectToAction(nameof(AgentsController.Become), "Agents");
            }

            if ((await _houses.CategoryExists(model.CategoryId)) == false)
            {
                ModelState.AddModelError(nameof(model.CategoryId), "Category does not exist.");
                model.HouseCategories = await _houses.AllCategoties();
            }

            if (!ModelState.IsValid)
            {
                model.HouseCategories = await _houses.AllCategoties();

                return View(model);
            }

            int agentId = await _agents.GetAgentId(User.Id());

            int id = await _houses.Create(model, agentId);

            return RedirectToAction(nameof(Details), new { id });
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            if ((await _houses.Exists(id)) == false)
            {
                return RedirectToAction(nameof(All));
            }

            if ((await _houses.HasAgentWithId(id,User.Id())) == false)
            {
                return RedirectToPage("/Account/AccessDenied", new { area = "Identity" });
            }

            var house = await _houses.HouseDetailsById(id);

            var houseCategoryId = await _houses.GetHouseCategoryId(house.Id);

            var model = new HouseFormModel()
            {
                Id = id,
                Title = house.Title,
                Address = house.Address,
                Description = house.Description,
                ImageUrl = house.ImageUrl,
                PricePerMonth = house.PricePerMonth,
                CategoryId = houseCategoryId,
                HouseCategories = await _houses.AllCategoties()
            };

            return View(model);
        }

        
        [HttpPost]
        public async Task<IActionResult> Edit(int id, HouseFormModel model)
        {
            if (id != model.Id)
            {
                return Unauthorized();
            }

            if ((await _houses.Exists(model.Id)) == false)
            {
                ModelState.AddModelError("", "House does not exist");
                model.HouseCategories = await _houses.AllCategoties();

                return View(model);
            }

            if ((await _houses.HasAgentWithId(model.Id, User.Id())) == false)
            {
                return Unauthorized();
            }

            if ((await _houses.CategoryExists(model.CategoryId)) == false)
            {
                ModelState.AddModelError(nameof(model.CategoryId),"Gategory does not exist");
                model.HouseCategories = await _houses.AllCategoties();

                return View(model);
            }

            if (!ModelState.IsValid)
            {
                model.HouseCategories = await _houses.AllCategoties();

                return View(model);
            }

            await _houses.Edit(model.Id,model);

            return RedirectToAction(nameof(Details), new { model.Id });
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            if ((await _houses.Exists(id)) == false)
            {
                return RedirectToAction(nameof(All));
            }

            if ((await _houses.HasAgentWithId(id, User.Id())) == false)
            {
                return Unauthorized();
            }

            var house = await _houses.HouseDetailsById(id);

            var model = new HouseDetailsDeleteModel()
            {
                Title = house.Title,
                Address = house.Address,
                ImageUrl = house.ImageUrl
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id, HouseDetailsDeleteModel model)
        {
            if ((await _houses.Exists(id)) == false)
            {
                return RedirectToAction(nameof(All));
            }

            if ((await _houses.HasAgentWithId(id, User.Id())) == false)
            {
                return Unauthorized();
            }

            await _houses.Delete(id);

            return RedirectToAction(nameof(All));
        }

        [HttpPost]
        public async Task<IActionResult> Rent(int id)
        {
            if ((await _houses.Exists(id)) == false)
            {
                return RedirectToAction(nameof(All));
            }

            if (await _agents.ExistsById(User.Id()))
            {
                return Unauthorized();
            }

            if (await _houses.IsRented(id))
            {
                return RedirectToAction(nameof(All));
            }

            await _houses.Rent(id, User.Id());

            return RedirectToAction(nameof(Mine));
        }

        [HttpPost]
        public async Task<IActionResult> Leave(int houseId)
        {
            if ((await _houses.IsRented(houseId)) == false)
            {
                return RedirectToAction(nameof(All));
            }

            if ((await _houses.Exists(houseId)) == false)
            {
                return RedirectToAction(nameof(All));
            }

            if ((await _houses.IsRentedByUserId(houseId, User.Id())) == false)
            {
                return Unauthorized();//RedirectToPage("/Account/AccessDenied", new { area = "Identity" });
            }

            await _houses.Leave(houseId);

            return RedirectToAction(nameof(Mine));
        }
    }
}
