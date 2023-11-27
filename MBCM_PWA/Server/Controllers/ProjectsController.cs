using MBCM_PWA.Client.Shared.Models;
using MBCM_PWA.Client.Shared;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.Security.Cryptography;
using System.Text;
using System;
using Microsoft.EntityFrameworkCore;

namespace MBCM_PWA.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        private readonly MBCM_DbContext _dbContext;

        public ProjectsController(MBCM_DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet("users")]
        public IEnumerable<User> GetUsers()
        {
            return _dbContext.tblUser.AsNoTracking().ToList();
        }

        [HttpGet("project-requests")]
        public IEnumerable<ProjectRequest> GetProjectRequests()
        {
            return _dbContext.tblRequest.Include(r => r.User).Include(r => r.Project).AsNoTracking().ToList();
        }

        [HttpGet("user-projects")]
        public IEnumerable<UserProjects> GetUserProjects()
        {
            return _dbContext.tblUserProject.Include(up => up.Project).Include(up => up.User).AsNoTracking().ToList();
        }


        [HttpGet]
        public IEnumerable<Project> Get()
        {
            return _dbContext.tblProject.AsNoTracking().ToList();
        }

        [HttpDelete("remove-user-from-project/{userProjectID}")]
        public IActionResult RemoveUserFromProject(int userProjectID)
        {
            var userProject = _dbContext.tblUserProject.Find(userProjectID);

            if (userProject == null)
            {
                return NotFound();
            }

            _dbContext.tblUserProject.Remove(userProject);
            _dbContext.SaveChanges();

            return Ok();
        }

        [HttpPost("send-request/{projectId}")]
        public IActionResult SendRequest(int projectId, [FromQuery] int userId)
        {
            Console.WriteLine($"Received request - ProjectId: {projectId}, UserId: {userId}");

            using (var transaction = _dbContext.Database.BeginTransaction())
            {
                try
                {
                    // Check if the user is already part of the project
                    var existingUserProject = _dbContext.tblUserProject
        .FirstOrDefault(up => up.userID == userId && up.projectID == projectId);

                    if (existingUserProject != null)
                    {
                        return BadRequest("User is already part of the project.");
                    }

                    // Check if the user has already requested to join
                    var existingRequest = _dbContext.tblRequest
                        .FirstOrDefault(req => req.UserID == userId && req.ProjectID == projectId);

                    if (existingRequest != null)
                    {
                        return BadRequest("User has already requested to join the project.");
                    }

                    // If the user is not part of the project and has not requested to join, proceed to send a new request
                    var request = new ProjectRequest
                    {
                        ProjectID = projectId,
                        UserID = userId,
                        IsAccepted = false
                    };

                    _dbContext.tblRequest.Add(request);
                    _dbContext.SaveChanges();

                    transaction.Commit();

                    return Ok();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    Console.WriteLine($"Error sending request: {ex.Message}");
                    return BadRequest("Error sending request. Please try again.");
                }
            }
        }

        [HttpDelete("delete-request/{requestId}")]
        public IActionResult DeleteRequest(int requestId)
        {
            var request = _dbContext.tblRequest.Find(requestId);

            if (request == null)
            {
                return NotFound();
            }

            _dbContext.tblRequest.Remove(request);
            _dbContext.SaveChanges();

            return Ok();
        }

        [HttpPost("accept-request/{requestId}")]
        public IActionResult AcceptRequest(int requestId)
        {
            var request = _dbContext.tblRequest.Find(requestId);

            if (request == null)
            {
                return NotFound();
            }

            var userProject = new UserProjects
            {
                userID = request.UserID,
                projectID = request.ProjectID
            };

            _dbContext.tblUserProject.Add(userProject);
            _dbContext.tblRequest.Remove(request);
            _dbContext.SaveChanges();

            return Ok();
        }

        [HttpPost("decline-request/{requestId}")]
        public IActionResult DeclineRequest(int requestId)
        {
            var request = _dbContext.tblRequest.Find(requestId);

            if (request == null)
            {
                return NotFound();
            }

            _dbContext.tblRequest.Remove(request);
            _dbContext.SaveChanges();

            return Ok();
        }

        [HttpPost("register")]
        public IActionResult RegisterUser([FromBody] UserRegistration model)
        {
            try
            {
                // Validate input (add your validation logic here)

                // Check if the user already exists
                var existingUser = _dbContext.tblUser.FirstOrDefault(u => u.userEmail == model.Email);

                if (existingUser != null)
                {
                    return BadRequest("User with this email already exists.");
                }

                // Hash the password
                var hashedPassword = HashPassword(model.Password);

                // Create a new user
                var newUser = new User
                {
                    userEmail = model.Email,
                    firstName = model.FirstName,
                    lastName = model.LastName,
                    userBio = model.Bio,
                    userPhoneNumber = model.PhoneNum,
                    JoinedDate = DateTime.Now,
                    userType = "Volunteer" // Add a default value or get it from the registration model
                };

                _dbContext.tblUser.Add(newUser);
                _dbContext.SaveChanges();

                // Retrieve the auto-generated ID
                int generatedUserId = newUser.UserID;

                // Create a new entry in tblUserCredentials for hashed password
                var newUserCredentials = new UserCredentials
                {
                    UserID = generatedUserId, // Use the auto increment generated ID
                    HashedPassword = hashedPassword // Store hashed password in tblUserCredentials
                };

                _dbContext.tblUserCredentials.Add(newUserCredentials);
                _dbContext.SaveChanges();

                return Ok("User registered successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Registration failed. Error: {ex.ToString()}");
                return BadRequest($"Registration failed. Error: {ex.Message}");

            }
        }

        private string HashPassword(string password)
        {
            // Generate a random salt
            byte[] salt = new byte[16];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }

            // Hash the password with the salt using SHA-256
            string hashedPassword = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 10000,
                numBytesRequested: 256 / 8));

            // Store the salt separately for later verification
            string saltString = Convert.ToBase64String(salt);

            // Combine the salt and hashed password for storage
            string combinedHash = $"{saltString}:{hashedPassword}";

            return combinedHash;
        }

        [HttpPost("login")]
        public IActionResult LoginUser([FromBody] UserLogin model)
        {
            try
            {
                // Check if the user exists with the provided email
                var user = _dbContext.tblUser.FirstOrDefault(u => u.userEmail == model.Email);

                if (user == null)
                {
                    // User not found, return BadRequest
                    return BadRequest("Invalid email or password.");
                }

                // Retrieve the hashed password from the tblUserCredentials
                var userCredentials = _dbContext.tblUserCredentials.FirstOrDefault(uc => uc.UserID == user.UserID);

                if (userCredentials == null)
                {
                    // Something went wrong, return BadRequest
                    return BadRequest("Invalid email or password.");
                }

                // Verify the entered password against the hashed password
                bool passwordValid = VerifyPassword(model.Password, userCredentials.HashedPassword);

                if (!passwordValid)
                {
                    // Password is incorrect, return BadRequest
                    return BadRequest("Invalid email or password.");
                }

                // Authentication successful
                // You might generate and return a JWT token here for future authenticated requests

                // Return the UserId along with a success message
                return Ok(new { Message = "Login successful!", UserId = user.UserID });
            }
            catch (Exception ex)
            {
                // Log the error and return BadRequest
                Console.WriteLine($"Login failed. Error: {ex.Message}");
                return BadRequest("Login failed. Please try again.");
            }
        }

        [HttpGet("getUserId")]
        public async Task<IActionResult> GetUserId(string email)
        {
            try
            {
                Console.WriteLine($"GetUserId called with email: {email}");
                var user = await _dbContext.tblUser
                    .Where(u => u.userEmail == email)
                    .Select(u => u.UserID)
                    .FirstOrDefaultAsync();

                if (user != 0)
                {
                    return Ok(user);
                }
                else
                {
                    return NotFound("User not found.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in GetUserId: {ex.Message}");
                return BadRequest($"Error getting user ID: {ex.Message}");
            }
        }

        private bool VerifyPassword(string enteredPassword, string hashedPassword)
        {
            // Extract the salt and hashed password from the stored combined hash
            var parts = hashedPassword.Split(':');
            if (parts.Length != 2)
            {
                return false; // Invalid hash format
            }

            string saltString = parts[0];
            string storedHashedPassword = parts[1];

            // Convert the salt and entered password to bytes
            byte[] salt = Convert.FromBase64String(saltString);
            byte[] enteredPasswordBytes = Encoding.UTF8.GetBytes(enteredPassword);

            // Hash the entered password with the stored salt
            string enteredPasswordHash = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: enteredPassword,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 10000,
                numBytesRequested: 256 / 8));

            // Compare the hashed passwords
            return string.Equals(enteredPasswordHash, storedHashedPassword);
        }

        [HttpDelete("remove-user/{userId}")]
        public IActionResult RemoveUser(int userId)
        {
            var user = _dbContext.tblUser.Find(userId);

            if (user == null)
            {
                return NotFound();
            }

            // Remove the user from projects
            var userProjects = _dbContext.tblUserProject.Where(up => up.userID == userId);
            _dbContext.tblUserProject.RemoveRange(userProjects);

            // Remove the user's requests
            var userRequests = _dbContext.tblRequest.Where(req => req.UserID == userId);
            _dbContext.tblRequest.RemoveRange(userRequests);

            // Remove the user
            _dbContext.tblUser.Remove(user);

            _dbContext.SaveChanges();

            return Ok();
        }

        [HttpGet("getUserDetails/{userId}")]
        public async Task<IActionResult> GetUserDetails(int userId)
        {
            try
            {
                var user = await _dbContext.tblUser
                    .FirstOrDefaultAsync(u => u.UserID == userId);

                if (user != null)
                {
                    return Ok(user);
                }
                else
                {
                    return NotFound("User not found.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in GetUserDetails: {ex.Message}");
                return BadRequest($"Error getting user details: {ex.Message}");
            }
        }

        [HttpGet("getUserProjects/{userId}")]
        public IActionResult GetUserProjects(int userId)
        {
            var userProjects = _dbContext.tblUserProject
                .Where(up => up.userID == userId)
                .Include(up => up.Project) // Include the Project navigation property
                .AsNoTracking()
                .ToList();

            return Ok(userProjects);
        }
    }
}
