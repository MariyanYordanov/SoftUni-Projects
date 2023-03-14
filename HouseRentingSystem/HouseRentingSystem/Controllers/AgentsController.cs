using HouseRentingSystem.Core.Models.Agent;
using HouseRentingSystem.Core.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using HouseRentingSystem.Extension;

namespace HouseRentingSystem.Controllers
{
    [Authorize]
    public class AgentsController : Controller
    {
        private readonly IAgentService _agents;

        public AgentsController(IAgentService agents)
        {
            _agents = agents;
        }

        [HttpGet]
        public async Task<IActionResult> Become()
        {
            if (await _agents.ExistsById(User.Id()))
            {
                ModelState.AddModelError(string.Empty,"You are an agent already!");

                return RedirectToAction("Mine","House");
            }

            var model = new BecomeAgentFormModel();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Become(BecomeAgentFormModel model)
        {
            var userId = User.Id();

            if (await _agents.ExistsById(userId))
            {
                ModelState.AddModelError(string.Empty, "You already are agent!");

                return RedirectToAction(nameof(AgentsController.Become),"Agents");
            }

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (await _agents.UserWithPhoneExists(model.PhoneNumber))
            {
                ModelState.AddModelError(nameof(model.PhoneNumber),
                    "Phone number already exists. Try with another one.");

                return RedirectToAction(nameof(AgentsController.Become),"Agents");
            }

            if (await _agents.UserHasRents(userId))
            {
                ModelState.AddModelError("Error", "You should have to rents to become an agent!");
            }

            await _agents.Create(userId, model.PhoneNumber);

            return RedirectToAction(nameof(HouseController.All), "House");
        }
    }
}
