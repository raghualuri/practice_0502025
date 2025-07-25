﻿using Microsoft.AspNetCore.Mvc;
//using practice_0502025.Application.DTO;
using practice_0502025.Application.DTOs;
using practice_0502025.Application.Interfaces;
using practice_0502025.Controllers.Base;
using practice_0502025.Entities;

namespace practice_0502025.Controllers
{
    public class OrderController : BaseController<Order,OrderDto>
    {
        // The constructor passes the ProductDto service to the base controller
        public OrderController(IGenericService<Order,OrderDto> productService)
            : base(productService)
        {
            // All generic CRUD methods (GetAll, GetById, Create, Update, Delete)
            // are now inherited from BaseController.
            // Only add Product-specific controller actions here if they don't fit
            // the generic pattern (e.g., [HttpGet("by-category/{category}")])
        }

        // IMPORTANT: REMOVE any old/custom implementations of GetAll, GetById, Create, Update, Delete
        // that were here previously. They are now provided by BaseController.
    }
}