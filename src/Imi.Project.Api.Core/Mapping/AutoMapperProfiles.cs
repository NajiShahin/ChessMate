using AutoMapper;
using Imi.Project.Api.Core.Dtos;
using Imi.Project.Api.Core.Dtos.Comments;
using Imi.Project.Api.Core.Dtos.Events;
using Imi.Project.Api.Core.Dtos.Games;
using Imi.Project.Api.Core.Dtos.Groups;
using Imi.Project.Api.Core.Dtos.Moves;
using Imi.Project.Api.Core.Dtos.Openings;
using Imi.Project.Api.Core.Dtos.Post;
using Imi.Project.Api.Core.Dtos.Users;
using Imi.Project.Api.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Imi.Project.Api.Core.Mapping
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Event, EventResponseDto>()
                .ForMember(dest => dest.UsersInterestedCount,
                    opt => opt.MapFrom(src => src.UserEvents.Count));
            CreateMap<EventRequestDto, Event>();


            CreateMap<Game, GameResponseDto>()
                .ForMember(dest => dest.UserName,
                    opt => opt.MapFrom(src => src.User.UserName))
                .ForMember(dest => dest.MoveCount,
                    opt => opt.MapFrom(src => src.Moves.Count));

            CreateMap<Game, GameDetailResponse>()
                .ForMember(dest => dest.UserName,
                    opt => opt.MapFrom(src => src.User.UserName));

            CreateMap<GameDetailResponse, Game>();

            CreateMap<GameRequestDto, Game>();
            CreateMap<MoveRequestDto, GameMove>();


            CreateMap<GameMove, MoveResponseDto>();



            CreateMap<OpeningMove, MoveOpeningResponse>();
            CreateMap<MoveRequestDto, OpeningMove>();

            CreateMap<Post, PostResponseDto>()
                .ForMember(dest => dest.groupName,
                    opt => opt.MapFrom(src => src.Group.Name));
            CreateMap<PostRequestDto, Post>();

            CreateMap<Comment, CommentResponseDto>();
            CreateMap<CommentRequestDto, Comment>();

            CreateMap<Opening, OpeningResponseDto>();
            CreateMap<Opening, OpeningsDetailResponseDto>();
            CreateMap<OpeningsRequestDto, Opening>();

            CreateMap<Group, GroupResponseDto>();
            CreateMap<Group, GroupDetailResponseDto>()
                .ForMember(dest => dest.Users,
                opt => opt.MapFrom(src => src.GroupUsers
                .Select(u => new UserResponseDto
                {
                    Id = Guid.Parse(u.UserId),
                    FirstName = u.User.FirstName,
                    Email = u.User.Email,
                    Events = u.User.UserEvents.Select(e => new EventResponseDto
                    {
                        Id = e.EventId,
                        Name = e.Event.Name,
                        DateTimeOfEvent = e.Event.DateTimeOfEvent,
                        Description = e.Event.Description,
                        UsersInterestedCount = e.Event.UserEvents.Count,
                    }).ToList(),
                    GameCount = u.User.Games.Count,
                    Username = u.User.UserName,
                    LastName = u.User.LastName
                })));
            CreateMap<GroupRequestDto, Group>();


            CreateMap<User, LoginUserResponseDto>();

            CreateMap<LoginUserRequestDto, User>();

            CreateMap<UserEditRequest, User>();

            CreateMap<User, UserResponseDto>()
                .ForMember(dest => dest.Events,
                    opt => opt.MapFrom(src => src.UserEvents
                    .Select(e => new EventResponseDto
                    {
                        Id = e.EventId,
                        Name = e.Event.Name,
                        DateTimeOfEvent = e.Event.DateTimeOfEvent,
                        Description = e.Event.Description,
                        UsersInterestedCount = e.Event.UserEvents.Count,
                    })))
                .ForMember(dest => dest.GameCount,
                    opt => opt.MapFrom(src => src.Games.Count));
            CreateMap<UsersRequestDto, User>()
                .ForMember(dest => dest.PasswordHash,
                    opt => opt.MapFrom(src => src.Password));
        }
    }
}
