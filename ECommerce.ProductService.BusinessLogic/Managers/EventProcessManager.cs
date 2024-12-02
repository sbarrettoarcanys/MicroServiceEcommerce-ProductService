using ECommerce.ProductService.BusinessLogic.IManagers;
using ECommerce.ProductService.Models.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using System.Text.Json;

namespace ECommerce.ProductService.BusinessLogic.Managers
{
    public class EventProcessManager : IEventProcessManager
    {
        private readonly IServiceScopeFactory _scopeFactory;


        public EventProcessManager(IServiceScopeFactory scopeFactory)
        {
            _scopeFactory = scopeFactory;
        }

        public void ProcessEvent(string message)
        {
            var eventType = DetermineEvent(message);

            switch (eventType)
            {
                case EventType.UserPublished:
                    AddUser(message);
                    break;
                default:
                    break;
            }
        }

        private EventType DetermineEvent(string notifcationMessage)
        {
            Console.WriteLine("--> Determining Event");

            var eventType = JsonSerializer.Deserialize<GenericEventViewModel>(notifcationMessage);

            switch (eventType.Event)
            {
                case "User_Published":
                    Console.WriteLine("--> User Published Event Detected");
                    return EventType.UserPublished;
                default:
                    Console.WriteLine("--> Could not determine the event type");
                    return EventType.Undetermined;
            }
        }

        private void AddUser(string userPublishedMessage)
        {

            using (var scope = _scopeFactory.CreateScope())
            {
                var _userManager = scope.ServiceProvider.GetRequiredService<IUserManager>();
                var registrationRequestViewModel = JsonSerializer.Deserialize<RegistrationRequestViewModel>(userPublishedMessage);

                try
                {
                    UserViewModel existingUser = _userManager.GetUser(registrationRequestViewModel.Id);
                    if (existingUser == null)
                    {
                        _userManager.Add(registrationRequestViewModel);

                    }
                    else
                    {
                        Console.WriteLine("Error : User already Exists");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error adding user (Message bus): " + ex.Message);
                }
            }
        }
    }

    enum EventType
    {
        UserPublished,
        Undetermined
    }
}

