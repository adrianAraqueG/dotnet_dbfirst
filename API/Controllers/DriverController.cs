using Core.Entities;
using Core.Interface;
using Microsoft.AspNetCore.Mvc;
using API.Dtos;
using AutoMapper;
namespace API.Controllers;
public class DriverController : ApiBaseController
{
    private readonly IUnitOfWork _unitOfWork;
    private  IMapper _mapper;
    public DriverController(IUnitOfWork unitOfWork, IMapper map)
    {
        _unitOfWork = unitOfWork;
        _mapper = map;
    }



    [HttpPost("getAll")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<DriverDto>> Save(DriverDto driver)
    {
        var result = _mapper.Map<Driver>(driver);

        if (driver == null)
        {
            return BadRequest();
        }

        _unitOfWork.Drivers.Add(result);
        await _unitOfWork.SaveAsync();

        return Ok(driver);
    }



    [HttpDelete("delete/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> Delete(int id)
    {
        var result = await _unitOfWork.Drivers.GetById(id);

        if (result == null)
        {
            return BadRequest();
        }

        _unitOfWork.Drivers.Remove(result);
        await _unitOfWork.SaveAsync();

        return NoContent();
    }



    [HttpGet("get/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<DriverDto>> GetById(int id)
    {
        var dato = await _unitOfWork.Drivers.GetById(id);
        var mapeo = _mapper.Map<DriverDto>(dato);
        if (dato == null)
        {
            return BadRequest();
        }
        return mapeo;
    }



    [HttpPut("update/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<DriverDto>> Update(DriverDto driver)
    {
        var result = _mapper.Map<Driver>(driver);
        _unitOfWork.Drivers.Update(result);
        await _unitOfWork.SaveAsync();
        
        return Ok(driver);
    }
}