using Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Controllers;

[Route("api/[controller]")]
[ApiController]
public class CareerController : ControllerBase
{
    private readonly CareerContext careerContext;

    public CareerController(CareerContext context)
    {
        careerContext = context;
    }

    [HttpGet]
    [AllowAnonymous]
    public IActionResult Test()
    {
        var db = careerContext
            .CareerEntries.Include(ce => ce.Tags)
            .Include(ce => ce.Location)
            .ToList();
        return new OkObjectResult(db);
    }
}
