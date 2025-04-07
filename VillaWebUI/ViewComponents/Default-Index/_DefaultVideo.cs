﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Villa.Business.Abstract;
using Villa.DataAccess.Abstract;
using Villa.DTO.Dtos.VideoDtos;

namespace VillaWebUI.ViewComponents.Default_Index
{
	public class _DefaultVideo:ViewComponent
	{
		private readonly IVideoService _videoService;
		private readonly IMapper _mapper;
		public _DefaultVideo(IVideoService videoService, IMapper mapper)
		{
			_videoService = videoService;
			_mapper = mapper;
		}
		public async Task<IViewComponentResult> InvokeAsync()
		{
			var value = await _videoService.TGetListAsnc();
			var VideoList = _mapper.Map<List<ResultVideoDto>>(value);
			return View(VideoList);
		}
	}
}
