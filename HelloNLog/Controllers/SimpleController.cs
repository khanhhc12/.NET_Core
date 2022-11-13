using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace HelloNLog.Controllers;

[ApiController]
public class SimpleController : ControllerBase
{
    private readonly ILogger<SimpleController> _logger;

    public SimpleController(ILogger<SimpleController> logger)
    {
        _logger = logger;
    }

    [HttpPost]
    [Route("api/simple/post")]
    public object Post(SimpleModel model)
    {
        _logger.LogTrace(JsonConvert.SerializeObject(model));
        return model;
    }

    public class SimpleModel
    {
        public string value { get; set; }
        public string text { get; set; }
        [JsonIgnore]
        public string ignore { get; set; }
        public string ignore2 { internal get; set; }
    }
}
