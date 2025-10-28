using ITControl.Domain.KnowledgeBases.Entities;
using ITControl.Presentation.KnowledgeBases.Responses;

namespace ITControl.Presentation.KnowledgeBases.Interfaces;

public interface IKnowledgeBasesView
{
    CreateKnowledgeBasesResponse? Create(KnowledgeBase? knowledgeBase);
    FindOneKnowledgeBasesResponse? FindOne(KnowledgeBase? knowledgeBase);
    IEnumerable<FindManyKnowledgeBasesResponse> FindMany(IEnumerable<KnowledgeBase>? knowledgeBases);
}
