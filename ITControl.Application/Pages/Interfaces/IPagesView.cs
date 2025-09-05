using ITControl.Communication.Pages.Response;
using ITControl.Domain.Pages.Entities;

namespace ITControl.Application.Pages.Interfaces;

public interface IPagesView
{
    CreatePagesResponse? Create(Page? page);
    FindOnePagesResponse? FindOne(Page? page);
    IEnumerable<FindManyPagesResponse> FindMany(IEnumerable<Page>? pages);
}