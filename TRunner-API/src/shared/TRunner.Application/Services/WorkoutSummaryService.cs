using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TRunner.Application.Commands.UserCommands;
using TRunner.Application.Commands.WorkoutSummaryCommands;
using TRunner.Application.Interfaces.MinIO;
using TRunner.Application.Services.Interfaces;
using TRunner.Core;
using TRunner.Core.Common.Exceptions;
using TRunner.Core.Resources;
using TRunner.Domain.Entities;
using TRunner.Domain.Models;
using TRunner.Domain.Models.Request;
using TRunner.Domain.Models.Response;

namespace TRunner.Application.Services
{
    public class WorkoutSummaryService : IWorkoutSummaryService
    {
        #region Private Members
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        private readonly IMinIOService _minIOService;
        #endregion

        #region Constructors
        public WorkoutSummaryService(IMapper mapper, IMediator mediator, IMinIOService minIOService)
        {
            _mapper = mapper;
            _mediator = mediator;
            _minIOService = minIOService;
        }
        #endregion
        public async Task<BaseResponseModel> CreateWorkoutSummary(CreateWorkoutSummaryRequest request)
        {
            var workoutSummaryRequest = _mapper.Map<WorkoutSummary>(request);
            var imageUrls = await _minIOService.UploadImages(request.Images, Constants.ContainerFolder.Workouts);
            var workoutImages = imageUrls.Select(imageUrl => new WorkoutImage
            {
                WorkoutImageUrl = imageUrl
            });

            workoutSummaryRequest.WorkoutImages = workoutImages.ToList();

            var result = (await _mediator.Send(new CreateWorkoutSummary.Command(workoutSummaryRequest)));
            if (result <= 0)
            {
                throw new KnownAPIException(Resources.Workout_Summary_Create_Failed, (int)HttpStatusCode.InternalServerError);
            }

            return new BaseResponseModel(HttpStatusCode.Created, Resources.Success);
            
        }
    }
}
