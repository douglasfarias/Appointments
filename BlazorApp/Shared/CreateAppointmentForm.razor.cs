using ClassLibrary.Data.Commands;
using ClassLibrary.Data.Handlers;
using ClassLibrary.Factories;
using ClassLibrary.Models;

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.JSInterop;

namespace BlazorApp.Shared
{
    public partial class CreateAppointmentForm
    {
        [Inject]
        public IJSRuntime? JS { get; set; }
        [Inject]
        public IAppointmentsHandler? AppointmentsHandler { get; set; }

        CreateAppointmentCommand? _model;
        IEnumerable<Customer>? _customers;
        IEnumerable<Employee>? _employees;

        protected override void OnInitialized()
        {
            _model = CommandFactory.CreateAppointmentCommand(AppointmentsHandler!.HandleAsync);
            _customers = new List<Customer>()
            {
                UserFactory.CreateCustomer("(11) 68642-8147", "Anitta", "Silva")
            };
            _employees = new List<Employee>()
            {
                UserFactory.CreateEmployee("(11) 38147-0996", "Luísa", "Sonza")
            };
        }

        private async Task HandleValidSubmit(EditContext context)
        {
            await _model!.ExecuteAsync();
        }
    }
}