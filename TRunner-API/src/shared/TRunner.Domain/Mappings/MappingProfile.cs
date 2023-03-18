using AutoMapper;
using Newtonsoft.Json;
using TRunner.Domain.Entities;
using TRunner.Domain.Models.Request;
using TRunner.Domain.Models.Response;

namespace TRunner.Domain.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<User, AuthenticateResponse>()
            .ForMember(dest => dest.RoleName, opt => opt.MapFrom(src => src.UserRole.RoleName));
        CreateMap<User, UserResponse>()
            .ForMember(dest => dest.RoleName, opt => opt.MapFrom(src => src.UserRole.RoleName));
        CreateMap<UpdateUserRequest, User>();
        CreateMap<Sport, SportResponse>();
        CreateMap<CreateWorkoutSummaryRequest, WorkoutSummary>()
            .ForPath(dest => dest.WorkoutDetailByTime.WorkoutDetailData, opt => opt.MapFrom(src => JsonConvert.SerializeObject(src.DetailRecordsNotDevice)));
        CreateMap<SportType, SportTypesResponse>();
    }
}
