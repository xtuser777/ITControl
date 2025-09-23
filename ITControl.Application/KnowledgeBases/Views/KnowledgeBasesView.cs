using ITControl.Application.KnowledgeBases.Interfaces;
using ITControl.Communication.KnowledgeBases.Responses;
using ITControl.Domain.KnowledgeBases.Entities;
using ITControl.Domain.Shared.Extensions;

namespace ITControl.Application.KnowledgeBases.Views;

public class KnowledgeBasesView : IKnowledgeBasesView
{
    public CreateKnowledgeBasesResponse? Create(KnowledgeBase? knowledgeBase)
    {
        if (knowledgeBase == null) return null;

        return new CreateKnowledgeBasesResponse
        {
            Id = knowledgeBase.Id,
        };
    }

    public FindOneKnowledgeBasesResponse? FindOne(KnowledgeBase? knowledgeBase)
    {
        if (knowledgeBase == null) return null;

        return new FindOneKnowledgeBasesResponse
        {
            Id = knowledgeBase.Id,
            Title = knowledgeBase.Title,
            Content = knowledgeBase.Content,
            EstimatedTime = knowledgeBase.EstimatedTime,
            Reason = new () 
            { 
                Value = knowledgeBase.Reason.ToString(), 
                DisplayValue = knowledgeBase.Reason.GetDisplayValue() 
            },
            UserId = knowledgeBase.UserId,
            User = knowledgeBase.User == null ? null : new FindOneKnowledgeBasesUserResponse
            {
                Id = knowledgeBase.User.Id,
                Name = knowledgeBase.User.Name,
            }
        };
    }

    public IEnumerable<FindManyKnowledgeBasesResponse> FindMany(IEnumerable<KnowledgeBase>? knowledgeBases)
    {
        if (knowledgeBases == null) return [];

        return knowledgeBases.Select(knowledgeBase => new FindManyKnowledgeBasesResponse
        {
            Id = knowledgeBase.Id,
            Title = knowledgeBase.Title,
            Content = knowledgeBase.Content,
            EstimatedTime = knowledgeBase.EstimatedTime,
            Reason = knowledgeBase.Reason.GetDisplayValue(),
            UserId = knowledgeBase.UserId,
        });
    }
}
