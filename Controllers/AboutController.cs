using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace NamespaceName
{
  public class ControllerNameController : Controller
  {

    ILogger<ControllerNameController> _logger;

    public ControllerNameController(ILogger<ControllerNameController> logger)
    {
      _logger = logger;
    }

    public IActionResult Index()
    {
      
      return View();
    }
  }
}