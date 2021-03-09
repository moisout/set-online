using Microsoft.AspNetCore.Mvc;
using set.models.Game;
using set.service.Practice.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace set.api.Controllers
{
  [Route("api/practice")]
  public class PracticeController : Controller
  {
    private IPracticeService PracticeService;

    public PracticeController(IPracticeService practiceService)
    {
      PracticeService = practiceService;
    }

    [HttpGet]
    public PracticeTableDto GetPracticeTable()
    {
      return PracticeService.GetPracticeTable();
    }
  }
}
