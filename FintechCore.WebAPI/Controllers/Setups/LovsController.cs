using FintechCore.Application.Services.Setups.lov;
using Microsoft.AspNetCore.Mvc;

namespace FintechCore.WebAPI.Controllers.Setups;

[ApiController]
[Route("api/v1/[controller]")]
public class LovsController : ControllerBase
{
    private readonly ILovService _lovService;

    public LovsController(ILovService lovService)
    {
        _lovService = lovService;
    }
}