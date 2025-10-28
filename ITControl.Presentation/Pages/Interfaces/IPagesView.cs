using ITControl.Domain.Pages.Entities;
using ITControl.Presentation.Pages.Response;

namespace ITControl.Presentation.Pages.Interfaces;

public interface IPagesView
{
    CreatePagesResponse? Create(Page? page);
    FindOnePagesResponse? FindOne(Page? page);
    IEnumerable<FindManyPagesResponse> FindMany(IEnumerable<Page>? pages);
}