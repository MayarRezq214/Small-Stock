using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Dynamic;
using TaskCodeZone.BL;
using TaskCodeZone.DAL;



namespace TaskCodeZone.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _configuration;
        private readonly IStoreManager _storeManager;
        private readonly IItemManager _itemManager;

        public HomeController(ILogger<HomeController> logger , 
            IStoreManager storeManager,
            IItemManager itemManager)
        {
            _storeManager = storeManager;
            _logger = logger;
            _itemManager = itemManager;
        }

        public IActionResult GetAllSotres()
        {
            ViewData["StoreFlag"] = false;
            List<StoreDto>? stores = _storeManager.GetAllStores();
            ViewData["stors"] = stores;
            return View();
        }

        public IActionResult AddStore(StoreDto store)
        {
            ViewData["StoreFlag"] = false;
            StoreDto FoundStore = _storeManager.GetStoreByNameAndAddress(store.Name, store.Address);
            if(FoundStore != null)
            {
                ViewData["StoreName"] = store.Name;
                ViewData["StoreAddress"] = store.Address;
                ViewData["StoreFlag"] = true;
                List<StoreDto>? stores = _storeManager.GetAllStores();
                ViewData["stors"] = stores;
                return View("GetAllSotres");
            }
            _storeManager.AddStore(store);
            return RedirectToAction("GetAllSotres");
        }

        public IActionResult GetAllItemsForStore(int id)
        {
            GetAllItemsForStoreDto AllItemsForStore = _storeManager.GetAllItemsForStore(id);
            if(AllItemsForStore == null) { return NotFound(); }
            List<ItemDto>? items = _itemManager.GetAllItems();
            ViewData["Items"] = items;
            ViewData["ItemsForStore"] = AllItemsForStore;
            return View();
        }
        [HttpPost]
        public IActionResult DeleteStoreByID(int id)
        {
            _storeManager.DeleteStoreById(id);
            return RedirectToAction("GetAllSotres");
        }
        public ActionResult<StoreDto> UpdateStore(int id)
        {
            if (id == null) { return BadRequest(); }
            StoreDto Store = _storeManager.GetStoreByID(id);
            if (Store == null) { return NotFound(); }

            return Json(Store);
        }
        [HttpPost]
        public IActionResult UpdateStore(StoreDto Store)
        {
            if (Store == null) { return BadRequest(); }
            ViewData["StoreFlag"] = false;
            StoreDto FoundStore = _storeManager.GetStoreByNameAndAddress(Store.Name, Store.Address);
            if (FoundStore != null)
            {
                ViewData["StoreName"] = FoundStore.Name;
                ViewData["StoreAddress"] = FoundStore.Address;
                ViewData["StoreFlag"] = true;
                List<StoreDto>? stores = _storeManager.GetAllStores();
                ViewData["stors"] = stores;
                return View("GetAllSotres");
            }
            _storeManager.UpdateStore(Store);
            return RedirectToAction("GetAllSotres");
        }
        public IActionResult AddItemsInStore(ItemInStoreDto StoreItem)
        {
            if(StoreItem == null) { return BadRequest();}
            if(ModelState.IsValid)
            {
                _storeManager.AddItemInStore(StoreItem);
                return RedirectToAction($"GetAllItemsForStore", new { Id = StoreItem.StoreId });
            }
            GetAllItemsForStoreDto AllItemsForStore = _storeManager.GetAllItemsForStore(StoreItem.StoreId);
            if (AllItemsForStore == null) { return NotFound(); }
            List<ItemDto>? items = _itemManager.GetAllItems();
            ViewData["Items"] = items;
            ViewData["ItemsForStore"] = AllItemsForStore;
            return View("GetAllItemsForStore" , StoreItem);
        }
        public IActionResult Adding(ItemInStoreDto StoreItem)
        {
            StoreItem.CurrentNumberOfItems += StoreItem.Value;
            return RedirectToAction("UpdateCurrentCount", StoreItem);
        }
        public IActionResult UpdateCurrentCount( ItemInStoreDto StoreItem)
        {
            if (StoreItem == null) { BadRequest(); }
            if (ModelState.IsValid)
            {
                _storeManager.updateCurrentCount(StoreItem);
                return RedirectToAction("GetAllItemsForStore", new { id = StoreItem.StoreId });
            }
            GetAllItemsForStoreDto AllItemsForStore = _storeManager.GetAllItemsForStore(StoreItem.StoreId);
            if (AllItemsForStore == null) { return NotFound(); }
            List<ItemDto>? items = _itemManager.GetAllItems();
            ViewData["Items"] = items;
            ViewData["ItemsForStore"] = AllItemsForStore;
            return View("GetAllItemsForStore", StoreItem);

        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}