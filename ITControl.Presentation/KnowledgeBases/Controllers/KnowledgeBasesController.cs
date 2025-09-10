using ITControl.Application.KnowledgeBases.Interfaces;
using ITControl.Communication.KnowledgeBases.Requests;
using ITControl.Domain.KnowledgeBases.Entities;
using ITControl.Infrastructure.KnowledgeBases.Repositories;
using ITControl.Presentation.Shared.Filters;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ITControl.Presentation.KnowledgeBases.Controllers;
[Route("knowledge-bases")]
[ApiController]
[PermissionsFilter]
[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
public class KnowledgeBasesController(
    IKnowledgeBasesService knowledgeBasesService,
    IKnowledgeBasesView knowledgeBasesView) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> Index([FromQuery] FindManyKnowledgeBasesRequest request)
    {
        var @params = (FindManyKnowledgeBasesRepositoryParams)request;
        var knowledgeBases = await knowledgeBasesService.FindManyAsync(@params);
        var pagination = await knowledgeBasesService.FindManyPaginationAsync(@params);
        var data = knowledgeBasesView.FindMany(knowledgeBases);
        
        return Ok(new { data, pagination });
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> Show([FromRoute] Guid id)
    {
        var @params = new FindOneKnowledgeBasesRepositoryParams
        {
            Id = id,
            IncludeUser = true
        };
        var knowledgeBase = await knowledgeBasesService.FindOneAsync(@params);
        var data = knowledgeBasesView.FindOne(knowledgeBase);
        
        return Ok(new { data });
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateKnowledgeBasesRequest request)
    {
        var knowledgeBase = (KnowledgeBase)request;
        var createdKnowledgeBase = await knowledgeBasesService.CreateAsync(knowledgeBase);
        var data = knowledgeBasesView.Create(createdKnowledgeBase);
        
        return CreatedAtAction(nameof(Show), new { id = createdKnowledgeBase.Id }, new { data });
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateKnowledgeBasesRequest request)
    {
        var @params = (UpdateKnowledgeBaseParams)request;
        await knowledgeBasesService.UpdateAsync(id, @params);
        
        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        await knowledgeBasesService.DeleteAsync(id);
        
        return NoContent();
    }
}
