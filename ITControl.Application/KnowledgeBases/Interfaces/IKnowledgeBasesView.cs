using ITControl.Communication.KnowledgeBases.Responses;
using ITControl.Domain.KnowledgeBases.Entities;

namespace ITControl.Application.KnowledgeBases.Interfaces;

public interface IKnowledgeBasesView
{
    CreateKnowledgeBasesResponse? Create(KnowledgeBase? knowledgeBase);
    FindOneKnowledgeBasesResponse? FindOne(KnowledgeBase? knowledgeBase);
    IEnumerable<FindManyKnowledgeBasesResponse> FindMany(IEnumerable<KnowledgeBase>? knowledgeBases);
}
