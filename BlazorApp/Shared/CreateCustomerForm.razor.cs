using ClassLibrary.Data.Commands;
using ClassLibrary.Data.Contracts;

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace BlazorApp.Shared;

public partial class CreateCustomerForm
{
    private CreateCustomerCommand _command = new();

    [Inject]
    public ICommandHandler<CreateCustomerCommand>? CommandHandler { get; set; }

    protected override void OnInitialized()
    {
        if (CommandHandler is null)
            return;

        _command.Receiver = CommandHandler.HandleAsync;
    }

    private async Task OnValidSubmit(EditContext context)
    {
        await _command.ExecuteAsync();
    }
}
