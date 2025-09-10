using ITControl.Domain.Calls.Enums;
using ITControl.Domain.KnowledgeBases.Entities;

namespace ITControl.Domain.KnowledgeBases.Interfaces;

public interface IKnowledgeBasesRepository
{
    Task<KnowledgeBase?> FindOneAsync(IFindOneKnowledgeBasesRepositoryParams @params);
    Task<IEnumerable<KnowledgeBase>> FindManyAsync(IFindManyKnowledgeBasesRepositoryParams @params);
    Task CreateAsync(KnowledgeBase knowledgeBase);
    void Update(KnowledgeBase knowledgeBase);
    void Delete(KnowledgeBase knowledgeBase);
    Task<int> CountAsync(ICountKnowledgeBasesRepositoryParams @params);
    Task<bool> ExistsAsync(IExistsKnowledgeBasesRepositoryParams @params);
}

public interface IFindOneKnowledgeBasesRepositoryParams
{
    Guid Id { get; set; }
    bool? IncludeUser { get; set; }
}

public interface IFindManyKnowledgeBasesRepositoryParams
{
    Guid? Id { get; set; }
    string? Title { get; set; }
    string? Content { get; set; }
    TimeOnly? EstimatedTime { get; set; }
    CallReason? Reason { get; set; }
    Guid? UserId { get; set; }
    string? OrderByTitle { get; set; }
    string? OrderByContent { get; set; }
    string? OrderByEstimatedTime { get; set; }
    string? OrderByReason { get; set; }
    string? OrderByUser { get; set; }
    int? Page { get; set; }
    int? Size { get; set; }
}

public interface ICountKnowledgeBasesRepositoryParams
{
    Guid? Id { get; set; }
    string? Title { get; set; }
    string? Content { get; set; }
    TimeOnly? EstimatedTime { get; set; }
    CallReason? Reason { get; set; }
    Guid? UserId { get; set; }
}

public interface IExistsKnowledgeBasesRepositoryParams : ICountKnowledgeBasesRepositoryParams
{
}
