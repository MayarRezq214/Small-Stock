using Microsoft.AspNetCore.Mvc;
using TaskCodeZone.BL;

namespace TaskCodeZone.Controllers
{
    public class ItemsController : Controller
    {
        private readonly ILogger<ItemsController> _logger;
        private readonly IItemManager _itemManager;

        public ItemsController(ILogger<ItemsController> logger ,
            IItemManager itemManager)
        {
            _itemManager = itemManager;
            _logger = logger;
        }

        public IActionResult GetAllItems()
        {
            ViewData["ItemFlag"] = false;
            List<ItemDto>? items = _itemManager.GetAllItems();
            ViewData["Items"] = items;
            return View();
        }
        public IActionResult AddItem(ItemDto Item)
        {
            ViewData["ItemFlag"] = false;
            ItemDto item = _itemManager.GetItemByName(Item.Name);
            if(item != null)
            {
                ViewData["ItemFlag"] = true;
                ViewData["ItemName"] = item.Name;
                List<ItemDto>? items = _itemManager.GetAllItems();
                ViewData["Items"] = items;
                return View("GetAllItems");
            }
            _itemManager.AddItem(Item);
            return RedirectToAction("GetAllItems");
        }
        [HttpPost]
        public IActionResult DeleteItemById(int id)
        {
            _itemManager.DeleteItemById(id);
            return RedirectToAction("GetAllItems");
        }
        public ActionResult<ItemDto> UpdateItem(int id)
        {
            if (id == null) { return BadRequest(); }
            ItemDto Item = _itemManager.GetItemById(id);
            if (Item == null) { return NotFound(); }
            return Json(Item);
        }
        [HttpPost]
        public IActionResult UpdateItem(ItemDto Item)
        {
            if (Item == null) { return BadRequest(); }
            
            _itemManager.UpdateItem(Item);
            return RedirectToAction("GetAllItems");
        }

    }
}
