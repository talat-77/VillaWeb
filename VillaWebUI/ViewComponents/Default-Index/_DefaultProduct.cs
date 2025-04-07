﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Villa.Business.Abstract;
using Villa.DTO.Dtos.ProductDtos;

namespace VillaWebUI.ViewComponents.Default_Index
{
    public class _DefaultProduct:ViewComponent
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;
        public _DefaultProduct(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var value = await _productService.TGetListAsnc();
            var ProductList = _mapper.Map<List<ResultProductDto>>(value);
            return View(ProductList);   
        }
    }
}
