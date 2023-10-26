using AutoMapper;
using MediPortal_Feedback.Models;
using MediPortal_Feedback.Models.Dtos;
using MediPortal_Feedback.Services.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace MediPortal_Feedback.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedbackController : ControllerBase
    {
        private readonly IFeedbackService _feedbackService;
        private readonly IMapper _mapper;
        private readonly ResponseDto _response;
        public FeedbackController(IFeedbackService feedbackService, IMapper mapper)
        {
            _feedbackService = feedbackService;
            _mapper = mapper;
            _response = new ResponseDto();
        }
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<ResponseDto>> AddFeedback(FeedbackRequestDto feedbackRequestDto)
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
            var newFeedback = _mapper.Map<Feedback>(feedbackRequestDto);
            newFeedback.PatientId = Guid.Parse(userIdClaim.Value);
            var res = await _feedbackService.AddFeedback(newFeedback);
            if (string.IsNullOrWhiteSpace(res))
            {
                _response.IsSuccess = false;
                _response.Message = "something went wrong";
                return BadRequest(_response);
            }
            _response.Message = res;
            return Ok(_response);

        }
        [HttpDelete]
        public async Task<ActionResult<ResponseDto>> DeleteFeedback(Guid id)
        {
            var Feedbacks = await _feedbackService.GetAllFeedbacks();
            var FeedBackToDelete = Feedbacks.FirstOrDefault(f => f.FeedbackId == id);
            if (FeedBackToDelete == null)
            {
                _response.IsSuccess = false;
                _response.Message = "something went wrong";
                return BadRequest(_response);
            }
            var res = await _feedbackService.AddFeedback(FeedBackToDelete);
           
            _response.Message = res;
            return Ok(_response);

        }
        [HttpGet("DoctorFeedback")]
        public async Task<ActionResult<ResponseDto>> GetDoctorFeedback(Guid id)
        {
            var res = await _feedbackService.GetFeedbacks(id);
            
            if (res == null)
            {
                _response.IsSuccess = false;
                _response.Message = "something went wrong";
                return BadRequest(_response);
            }
            

            _response.obj = res;
           return Ok(_response);

        }
        [HttpGet("AllFeedback")]
        public async Task<ActionResult<ResponseDto>> GetAllFeedback()
        {
            var res = await _feedbackService.GetAllFeedbacks();

            if (res == null)
            {
                _response.IsSuccess = false;
                _response.Message = "something went wrong";
                return BadRequest(_response);
            }


            _response.obj = res;
            return Ok(_response);

        }
    }
}
