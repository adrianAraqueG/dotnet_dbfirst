using AutoMapper;
using Core.Entities;
using Core.Interface;
using API.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;
public class TeamController : ApiBaseController
{
    private readonly IUnitOfWork _unitOfWork;
    private IMapper _mapper;
    public TeamController(IUnitOfWork unitOfWork, IMapper map){
        _unitOfWork = unitOfWork;
        _mapper = map;
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<TeamDto>> Guardar(TeamDto ent){
        var mapeo = _mapper.Map<Team>(ent);
        if(mapeo == null){
            return BadRequest();
        }
        _unitOfWork.Teams.Add(mapeo);
        await _unitOfWork.SaveAsync();

        return Ok(ent);
    }
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> Delete(int id){
        var dato= await _unitOfWork.Teams.GetById(id);   
        if(dato == null){
            return BadRequest();
        }
        _unitOfWork.Teams.Remove(dato);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<TeamDto>> GetById(int id){
        var dato= await _unitOfWork.Teams.GetById(id);   
        if(dato == null){
            return BadRequest();
        }
        return _mapper.Map<TeamDto>(dato);
    }
    [HttpPut]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<TeamDto>> Update(TeamDto entity){
        var mapeo = _mapper.Map<Team>(entity);
        if(mapeo == null) return BadRequest();
        _unitOfWork.Teams.Update(mapeo);
        await _unitOfWork.SaveAsync();
        return Ok(entity);
    }
}