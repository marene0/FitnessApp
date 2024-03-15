using FitnessApp.DTO;
using FitnessApp.Interfaces;
using FitnessApp.Model;
using FitnessApp.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace FitnessApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : Controller
    {
        private readonly IWorkoutService _workoutService;
        private readonly IUserService _userService;

        public UserController(IWorkoutService workoutService, IUserService userService)
        {
            _workoutService = workoutService;
            _userService = userService;
        }

        [HttpGet("{userId:Guid}/workouts")] 
        public async Task<IActionResult> GetUserWorkoutsl()
        {
            var userId = Guid.Empty;
            try
            {
                userId = Guid.Parse(HttpContext.User.FindFirstValue(ClaimTypes.Sid));
                var workouts = await _workoutService.GetAllWorkoutsAsync(userId);
                return Ok(workouts);
            }
            catch (Exception ex)
            {
                return NotFound();
            }
        }

     
        [HttpPost]
        public async Task<ActionResult<bool>> CreateUser([FromBody] UserDTO userDTO)
        {
            userDTO.Id = Guid.Parse(HttpContext.User.FindFirstValue(ClaimTypes.Sid));

            try
            {
                var createdUser = await _userService.CreateUser(userDTO);
                return Ok(createdUser != null);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
                        
        }


        [HttpPut]
        public async Task<IActionResult> UpdateUser([FromBody] UserDTO UpdateuserDto)
        {
            UpdateuserDto.Id = Guid.Parse(HttpContext.User.FindFirstValue(ClaimTypes.Sid));

            var user = await _userService.UpdateUser(UpdateuserDto);

            if (user != null)
            {
                return Ok(user);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet]
        public async Task<ActionResult<UserDTO>> GetUserById()
        {
            var id = Guid.Parse(HttpContext.User.FindFirstValue(ClaimTypes.Sid));
            var user = await _userService.GetUserById(id); 
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

    }

    //[Authorize]
    //public class FileManagerController : ControllerBase

    //{

    //    private readonly IManageImage _iManageImage;
    //    public FileManagerController(IManageImage iManageImage)
    //    {
    //        _iManageImage = iManageImage;
    //    }

    //    [HttpPost("image")]

    //    public async Task<IActionResult> UploadFile(IFormFile _File, Guid userId)
    //    {
    //        var result = await _iManageImage.UploadFile(_File, userId);
    //        return Ok(result);
    //    }

    //    [HttpGet("{fileName}")]
    //    public async Task<IActionResult> DownloadFile(string fileName)
    //    {
    //        var result = await _iManageImage.DownloadFile(fileName);
    //        return File(result.Item1, result.Item2, result.Item2);
    //    }
    //}




}
