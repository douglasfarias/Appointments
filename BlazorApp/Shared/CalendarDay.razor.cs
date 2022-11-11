using ClassLibrary.Factories;
using ClassLibrary.Models;

using Microsoft.AspNetCore.Components;

namespace BlazorApp.Shared
{
    public partial class CalendarDay
    {
        [Parameter]
        public KeyValuePair<int, string> DayNumberAndName { get; set; }
        [Parameter]
        public bool Expanded { get; set; }

        List<Appointment> _appointments = new()
        {
            new Appointment
            {
                Date = DateTime.Now,
                Done = false,
                Customer = UserFactory.CreateCustomer("(11) 68642-8147", "Luísa", "Sonza"),
                Employee = UserFactory.CreateEmployee("(11) 38147-0996", "Anitta", "Silva"),
                Services = new List<Service>()
                {
                    new()
                    {
                        Name = "Escova"
                    },
                    new()
                    {
                        Name = "Corte"
                    },
                    new()
                    {
                        Name = "Tintura"
                    }
                }
            }
        };
    }
}