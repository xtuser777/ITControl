using ITControl.Communication.Pages.Response;
using ITControl.Domain.Entities;

namespace ITControl.Application.Interfaces;

public interface IPagesView
{
    CreatePagesResponse? Create(Page? page);
    FindOnePagesResponse? FindOne(Page? page);
    IEnumerable<FindManyPagesResponse> FindMany(IEnumerable<Page>? pages);
}