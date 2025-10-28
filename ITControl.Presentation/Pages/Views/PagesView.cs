using ITControl.Application.Pages.Translators;
using ITControl.Domain.Pages.Entities;
using ITControl.Presentation.Pages.Interfaces;
using ITControl.Presentation.Pages.Response;

namespace ITControl.Presentation.Pages.Views;

public class PagesView : IPagesView
{
    public CreatePagesResponse? Create(Page? page)
    {
        if (page is null) return null;

        return new CreatePagesResponse()
        {
            Id = page.Id,
        };
    }

    public FindOnePagesResponse? FindOne(Page? page)
    {
        if (page is null) return null;

        return new FindOnePagesResponse()
        {
            Id = page.Id,
            Name = page.Name,
            DisplayName = PagesTranslator.ToDisplayValue(page.Name),
        };
    }

    public IEnumerable<FindManyPagesResponse> FindMany(IEnumerable<Page>? pages)
    {
        if (pages is null) return [];

        return from page in pages
            select new FindManyPagesResponse()
            {
                Id = page.Id,
                Name = page.Name,
                DisplayName = PagesTranslator.ToDisplayValue(page.Name),
            }; 
    }
}