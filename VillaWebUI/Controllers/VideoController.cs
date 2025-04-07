using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using Villa.Business.Abstract;
using Villa.DTO.Dtos.ProductDtos;
using Villa.DTO.Dtos.VideoDtos;
using Villa.Entity.Entities;

namespace VillaWebUI.Controllers
{
    public class VideoController : Controller
    {
        private readonly IVideoService _videoService;
        private readonly IMapper _mapper;
        public VideoController(IMapper mapper, IVideoService videoService)
        {
            _mapper = mapper;
            _videoService = videoService;
        }

       
        public async Task<IActionResult> Index()
        {
            var values = await _videoService.TGetListAsnc();
            var VideoList = _mapper.Map<List<ResultVideoDto>>(values);
            return View(VideoList);
        }
        public async Task<IActionResult> DeleteVideo(ObjectId id)
        {
            await _videoService.TDelete(id);
            return RedirectToAction("Index");
        }
        public IActionResult CreateVideo()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateVideo(CreateVideoDto createVideoDto)
        {
            var newVideo = _mapper.Map<Video>(createVideoDto);
            await _videoService.TCreateAsync(newVideo);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> UpdateVideo(ObjectId id)
        {
            var value = await _videoService.TGetByIdAsync(id);
            var updateVideo = _mapper.Map<UpdateVideoDto>(value);
            return View(updateVideo);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateVideo(UpdateVideoDto updateVideoDto)
        {
            var video = _mapper.Map<Video>(updateVideoDto);
            await _videoService.TUpdateAsync(video);
            return RedirectToAction("Index");
        }
    }
}
