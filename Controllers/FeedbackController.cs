
using Microsoft.AspNetCore.Mvc;
using FeedbackManagement.Models;

namespace FeedbackManagement.Controllers
{
    public class FeedbackController : Controller
    {
        private static readonly List<Feedback> feedbackList = new();
        private static int nextId = 1;

        public IActionResult Index()
        {
            return View(feedbackList);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Feedback feedback)
        {
            if (!new[] { "Suggestion", "Complaint", "Appreciation", "Other" }
                .Contains(feedback.Category))
            {
                ModelState.AddModelError(
                    nameof(feedback.Category), "Select a valid category.");
            }

            if (ModelState.IsValid)
            {
                feedback.Id = nextId++;
                feedbackList.Add(feedback);

                TempData["Success"] = "Feedback submitted successfully!";

                return RedirectToAction(nameof(Index));
            }

            return View(feedback);
        }
    }
}
