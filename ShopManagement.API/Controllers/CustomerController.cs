﻿using Microsoft.AspNetCore.Mvc;
using ShopManagement.Logic.Responses.AllCustomers;
using ShopManagement.Logic.Responses.Birthday;
using ShopManagement.Logic.Responses.CustomerPurchases;
using ShopManagement.Logic.Responses.FavoriteCategories;
using ShopManagement.Logic.Responses.LastCustomers;
using ShopManagement.Logic.Services.Interfaces;

namespace ShopManagement.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CustomerController : ControllerBase
{
    private readonly ICustomerService _customerService;

    public CustomerController(ICustomerService customerService)
    {
        _customerService = customerService;
    }
    
    /// <summary>
    /// Get all customers
    /// </summary>
    /// <response code="200"></response>
    [HttpGet("get-all-customers")]
    [ProducesResponseType(typeof(AllCustomersResponse), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAllCustomers()
    {
        var response = await _customerService.GetAllCustomers();
        return Ok(response);
    }
    
    /// <summary>
    /// Get customer's purchases
    /// </summary>
    /// <response code="200"></response>
    [HttpGet("get-customer-purchases/{customerId}")]
    [ProducesResponseType(typeof(CustomerPurchasesResponse), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetCustomerPurchases([FromRoute] Guid customerId)
    {
        var response = await _customerService.GetCustomerPurchasesAsync(customerId);
        return Ok(response);
    }
    
    /// <summary>
    /// Get customers with specified birthday
    /// </summary>
    /// <response code="200"></response>
    [HttpGet("get-birthday-list")]
    [ProducesResponseType(typeof(BirthdayResponse), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetBirthdayList([FromQuery] DateTime date)
    {
        var response = await _customerService.GetCustomersByBirthdayAsync(date);
        return Ok(response);
    }

    /// <summary>
    /// Get customers who did purchases recently
    /// </summary>
    /// <response code="200"></response>
    [HttpGet("get-recent-customers")]
    [ProducesResponseType(typeof(LastCustomersResponse), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetCustomersWithinNLastDays([FromQuery] int nLastDays)
    {
        var response = await _customerService.GetCustomersWithRecentPurchasesAsync(nLastDays);
        return Ok(response);
    }

    /// <summary>
    /// Get customer favorite categories
    /// </summary>
    /// <response code="200"></response>
    [HttpGet("get-customer-favorite-categories/{customerId}")]
    [ProducesResponseType(typeof(FavoriteCategoriesResponse), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetFavoriteCategories([FromRoute] Guid customerId)
    {
        var response = await _customerService.GetFavoriteCategoriesAsync(customerId);
        return Ok(response);
    }
}