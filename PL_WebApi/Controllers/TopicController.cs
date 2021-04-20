using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service;

namespace PL_WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TopicController : ControllerBase
    {
        readonly ITopicService topicService;
        readonly IMessageService messageService;

        public TopicController(ITopicService topicService, IMessageService messageService)
        {
            this.topicService = topicService;
            this.messageService = messageService;
        }

        [HttpGet]
        [AllowAnonymous]
        public List<TopicDTO> Get()
        {
            return topicService.GetTopics().ToList();
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public TopicDTO Get(int id)
        {
            return topicService.GetTopic(id);
        }

        [HttpPost]
        public IActionResult Create([FromBody] TopicDTO topic)
        {
            if (ModelState.IsValid)
            {
                topic.CreateOn = DateTime.Now;
                topicService.Add(topic);

                return Ok();
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpPut]
        public IActionResult Update([FromBody]TopicDTO topicDTO)
        {
            if (ModelState.IsValid)
            {
                topicService.Update(topicDTO);
                return Ok();
            }

            return BadRequest(ModelState);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin, Moderator")]
        public void Delete(int id)
        {
            topicService.Delete(id);
        }
    }
}