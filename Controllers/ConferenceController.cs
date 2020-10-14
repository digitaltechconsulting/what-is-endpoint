using Microsoft.AspNetCore.Mvc;
using what_is_endpoint.Controllers.Services;

namespace what_is_endpoint.Controllers
{
    public class ConferenceController : Controller
    {
        private readonly IConferenceService ConferenceService ;
        public ConferenceController(IConferenceService conferenceService)
        {
           ConferenceService = conferenceService ;
        }
    }
}