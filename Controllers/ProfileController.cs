using Microsoft.AspNetCore.Mvc;
using dotnet_api.ProfileLogic;
using System.Collections.Generic;

namespace dotnet_api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProfileController : Controller
    {

        private ProfileAdmin _profileAdmin;
        public ProfileController(ProfileAdmin profileAdmin)
        {
            _profileAdmin = profileAdmin;
        }

        [HttpGet]
        public List<Profile> GetProfiles(){
            return _profileAdmin.GetProfiles();
        }

        [HttpGet("{name}")]
        public IActionResult GetProfile(string name){
            
            var profile = _profileAdmin.GetProfile(name);
            if(profile== null)
                return Ok("No profile found");
            else
                return Ok(profile);
        }

        [HttpPost]
        public Profile CreateProfile(Profile profile){
            _profileAdmin.AddProfile(profile);
            return profile;
        }

        [HttpPut]
        public IActionResult UpdateProfile(Profile profile){
            _profileAdmin.UpdateProfile(profile);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProfile(int id){
            _profileAdmin.DeleteProfile(id);
            return Ok();
        }



    }
}