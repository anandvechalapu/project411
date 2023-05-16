using System.Threading.Tasks;
using project411.DTO;
using project411.Service;
using Microsoft.AspNetCore.Mvc;

namespace project411.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class JiraController : ControllerBase
    {
        private readonly IJiraService _jiraService;

        public JiraController(IJiraService jiraService)
        {
            _jiraService = jiraService;
        }

        [HttpGet]
        public async Task<ActionResult<JiraConfigurationDTO>> Get()
        {
            var jiraConfig = await _jiraService.GetConfigurationAsync();
            return Ok(jiraConfig);
        }

        [HttpPut]
        public async Task<ActionResult<JiraConfigurationDTO>> Put(JiraConfigurationDTO jiraConfigurationDTO)
        {
            var jiraConfig = await _jiraService.SaveConfigurationAsync(jiraConfigurationDTO);
            return Ok(jiraConfig);
        }
    }
}