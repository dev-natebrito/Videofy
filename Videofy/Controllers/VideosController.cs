using Microsoft.AspNetCore.Mvc;
using Videofy.Models;
using Videofy.Services;

namespace Videofy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VideosController : ControllerBase
    {
        private readonly IVideoService _videoService;

        public VideosController(IVideoService videoService)
        {
            _videoService = videoService;
        }

        /// <summary>
        /// Get all videos
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<List<Video>> Get()
        {
            return _videoService.Get();
        }

        /// <summary>
        /// get the video by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}", Name = "Get")]
        public ActionResult<Video> Get(string id)
        {
            var video = _videoService.Get(id);
            if (video == null)
            {
                return NotFound($"Video with id {id} not found");
            }

            return video;
        }

        /// <summary>
        /// add a new video
        /// </summary>
        /// <param name="video"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult<Video> Post([FromBody] Video video)
        {
            _videoService.Create(video);
            return CreatedAtAction(nameof(Get), new {id = video.Id}, video);
        }


        /// <summary>
        /// update an existing video
        /// </summary>
        /// <param name="id"></param>
        /// <param name="video"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public ActionResult Put(string id, [FromBody] Video video)
        {
            var existingVideo = _videoService.Get(id);

            if (existingVideo == null)
            {
                return NotFound($"Video with id {id} not found");
            }

            _videoService.Update(id, video);
            return NoContent();
        }

        /// <summary>
        /// delete a specific video
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public ActionResult Delete(string id)
        {
            var video = _videoService.Get(id);
            if (video == null)
            {
                return NotFound($"Video with id {id} not found");
            }

            _videoService.Remove(id);
            return Ok("Video with id: {id} deleted ");
        }
    }
}