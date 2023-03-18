using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Net;
using TRunner.Application.Commands.SportCommands;
using TRunner.Application.Interfaces.MinIO;
using TRunner.Application.Queries;
using TRunner.Application.Queries.SportQueries;
using TRunner.Application.Services.Interfaces;
using TRunner.Core;
using TRunner.Core.Common.Exceptions;
using TRunner.Core.Resources;
using TRunner.Domain.Entities;
using TRunner.Domain.Extensions;
using TRunner.Domain.Models.Request;
using TRunner.Domain.Models.Response;

namespace TRunner.Application.Services
{
    public class SportService : ISportService
    {
        #region Private Members
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        private readonly IMediator _mediator;
        private readonly IMinIOService _minIOService;
        #endregion

        #region Constructors
        public SportService(IMapper mapper, ILoggerFactory loggerFactory, IMediator mediator, IMinIOService minIOService)
        {
            _mapper = mapper;
            _logger = loggerFactory.CreateLogger<SportService>();
            _mediator = mediator;
            _minIOService = minIOService;
        }
        #endregion

        public async Task<TRunnerPageResults<SportResponse>> GetListOfSportsWithPaging(PaginationRequest request)
        {
            try
            {
                var result = await _mediator.Send(new GetSports.Query(request));

                return result;
            }
            catch (Exception ex)
            {
                var error = $"GetListOfSportsWithPagingAPI - {Helpers.BuildErrorMessage(ex)}";
                _logger.LogError(error);
                throw new Exception(error);
            }
        }

        public async Task<SportResponse> CreateSport(CreateSportRequest request)
        {
            var sport = (await _mediator.Send(
                new FindBy.Query(x => x.SportName == request.SportName)))
                .FirstOrDefault();

            if (sport != null)
                throw new KnownAPIException(
                    Resources.Sports_Create_CheckNameUnique,
                    (int)HttpStatusCode.Conflict);

            var imageUrls = await _minIOService.UploadImages(
                new List<ImageInfo> { request.Image },
                Constants.ContainerFolder.Sports);

            var createdSport = new Sport()
            {
                SportName = request.SportName,
                SportTypeId = request.SportTypeId,
                IsActive = request.IsActive,
                ImageUrl = imageUrls.FirstOrDefault()
            };

            var result = await _mediator.Send(new CreateSport.Command(createdSport));

            if (result <= 0)
            {
                throw new KnownAPIException(Resources.Sports_Create_Failed, (int)HttpStatusCode.InternalServerError);
            }

            return _mapper.Map<SportResponse>(createdSport);
        }

        public async Task<int> UpdateSport(int Id, SportRequestModel request)
        {
            try
            {
                var result = await _mediator.Send(new UpdateSport.Query(Id, request));

                return result;
            }
            catch (Exception ex)
            {
                var error = $"UpdateSportAPI - {Helpers.BuildErrorMessage(ex)}";
                _logger.LogError(error);
                throw new Exception(error);
            }
        }
    }
}