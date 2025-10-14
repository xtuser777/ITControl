using ITControl.Application.Positions.Interfaces;
using ITControl.Communication.Positions.Responses;
using ITControl.Domain.Shared.Exceptions;
using ITControl.Domain.Positions.Entities;

namespace ITControl.Application.Positions.Views;

public class PositionsView : IPositionsView
{
    public FindOnePositionsResponse? FindOne(Position? position)
    {
        if (position == null) throw new NotFoundException("Position not found");

        var response = new FindOnePositionsResponse()
        {
            Id = position.Id,
            Description = position.Description
        };
        
        return response;
    }

    public IEnumerable<FindManyPositionsResponse> FindMany(IEnumerable<Position>? positions)
    {
        if (positions == null) return [];
        
        return from position in positions
            select new FindManyPositionsResponse()
            {
                Id = position.Id,
                Description = position.Description,
            }; 
    }

    public CreatePositionsResponse? Create(Position? position)
    {
        if (position == null) return null;

        var response = new CreatePositionsResponse()
        {
            Id = position.Id,
        };
        
        return response;
    }
}