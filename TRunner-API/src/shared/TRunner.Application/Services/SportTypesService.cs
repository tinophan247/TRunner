using AutoMapper;
using MediatR;
using TRunner.Application.Queries;
using TRunner.Application.Services.Interfaces;
using TRunner.Domain.Models.Response;


namespace TRunner.Application.Services
{
    public class SportTypesService : ISportTypeService
    {
        #region Private Members
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        #endregion

        #region Constructors
        public SportTypesService(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }
        #endregion

        public async Task<IEnumerable<SportTypesResponse>> GetAllSportTypes()
        {
            var result = await _mediator.Send(new GetSportTypes.Query());

            return _mapper.Map<List<SportTypesResponse>>(result);
        }
    }
}