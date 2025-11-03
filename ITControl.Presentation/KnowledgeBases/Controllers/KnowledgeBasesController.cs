using ITControl.Application.KnowledgeBases.Interfaces;
using ITControl.Presentation.KnowledgeBases.Interfaces;
using ITControl.Presentation.KnowledgeBases.Params;
using ITControl.Presentation.KnowledgeBases.Responses;
using ITControl.Presentation.Shared.Filters;
using ITControl.Presentation.Shared.Responses;
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
    [ProducesResponseType(
            typeof(FindManyResponse<FindManyKnowledgeBasesResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(
            typeof(ErrorJsonResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(void), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(void), StatusCodes.Status403Forbidden)]
    public async Task<IActionResult> Index(
        [AsParameters] IndexKnowledgeBasesParams index)
    {
        var knowledgeBases = 
            await knowledgeBasesService.FindManyAsync(index);
        var pagination = 
            await knowledgeBasesService.FindManyPaginationAsync(index);
        var data = knowledgeBasesView.FindMany(knowledgeBases);
        return Ok(new { data, pagination });
    }

    [HttpGet("{id:guid}")]
    [ProducesResponseType(
        typeof(FindOneResponse<FindOneKnowledgeBasesResponse?>), 
        StatusCodes.Status200OK)]
    [ProducesResponseType(
            typeof(ErrorJsonResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(
            typeof(ErrorJsonResponse), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(void), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(void), StatusCodes.Status403Forbidden)]
    public async Task<IActionResult> Show(
        [AsParameters] ShowKnowledgeBasesParams show)
    {
        var knowledgeBase = await knowledgeBasesService.FindOneAsync(show);
        var data = knowledgeBasesView.FindOne(knowledgeBase);
        return Ok(new { data });
    }

    [HttpPost]
    [ProducesResponseType(
        typeof(FindOneResponse<CreateKnowledgeBasesResponse?>), 
        StatusCodes.Status201Created)]
    [ProducesResponseType(
            typeof(ErrorJsonResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(void), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(void), StatusCodes.Status403Forbidden)]
    public async Task<IActionResult> Create(
        [AsParameters] CreateKnowledgeBasesParams create)
    {
        var createdKnowledgeBase = 
            await knowledgeBasesService.CreateAsync(create);
        var data = knowledgeBasesView.Create(createdKnowledgeBase);
        return CreatedAtAction(nameof(Show), 
            new { id = createdKnowledgeBase.Id }, new { data });
    }

    [HttpPut("{id:guid}")]
    [ProducesResponseType(typeof(void), StatusCodes.Status204NoContent)]
    [ProducesResponseType(
        typeof(ErrorJsonResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(
        typeof(ErrorJsonResponse), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(void), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(void), StatusCodes.Status403Forbidden)]
    public async Task<IActionResult> Update(
        [AsParameters] UpdateKnowledgeBasesParams update)
    {
        await knowledgeBasesService.UpdateAsync(update);
        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    [ProducesResponseType(typeof(void), StatusCodes.Status204NoContent)]
    [ProducesResponseType(
            typeof(ErrorJsonResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(
            typeof(ErrorJsonResponse), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(void), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(void), StatusCodes.Status403Forbidden)]
    public async Task<IActionResult> Delete(
        [AsParameters] DeleteKnowledgeBasesParams delete)
    {
        await knowledgeBasesService.DeleteAsync(delete);
        return NoContent();
    }
}
