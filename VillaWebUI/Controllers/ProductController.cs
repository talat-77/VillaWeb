﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using Villa.Business.Abstract;
using Villa.DTO.Dtos.BannerDtos;
using Villa.DTO.Dtos.ProductDtos;
using Villa.Entity.Entities;

namespace VillaWebUI.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;
        public ProductController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _productService.TGetListAsnc();
            var productList = _mapper.Map<List<ResultProductDto>>(values);
            return View(productList);
        }
        public async Task<IActionResult> DeleteProduct(ObjectId id)
        {
            await _productService.TDelete(id);
            return RedirectToAction("Index");
        }
        public IActionResult CreateProduct()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductDto createProductDto)
        {
            var newProduct = _mapper.Map<Product>(createProductDto);
            await _productService.TCreateAsync(newProduct);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> UpdateProduct(ObjectId id)
        {
            var value = await _productService.TGetByIdAsync(id);
            var updateProduct = _mapper.Map<UpdateProductDto>(value);
            return View(updateProduct);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateProduct(UpdateProductDto updateProductDto)
        {
            var product = _mapper.Map<Product>(updateProductDto);
            await _productService.TUpdateAsync(product);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> DetailProduct(ObjectId id)
        {
            var productlist = await _productService.TGetByIdAsync(id);
            var value = _mapper.Map<ResultProductDto>(productlist);
            return View(value);   
        }
    }
}
