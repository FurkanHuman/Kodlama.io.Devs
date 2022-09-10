
using Application.Features.ProgrammingTechnologies.Commands.CreateProgrammingTechnology;
using Application.Features.ProgrammingTechnologies.Commands.UpdateProgrammingTechnology;
using Application.Features.ProgrammingTechnologies.Dtos;
using Application.Features.ProgrammingTechnologies.Models;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;

namespace Application.Features.ProgrammingTechnologies.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<ProgrammingTechnology, CreateProgrammingTechnologyCommand>().ForMember(f=>f.PLId,opt=>opt.MapFrom(o=>o.ProgrammingLanguageId)).ReverseMap();
            CreateMap<ProgrammingTechnology, CreatedProgrammingTechnologyDto>().ReverseMap();

            CreateMap<ProgrammingTechnology, UpdateProgrammingTechnologyCommand>().ReverseMap();
            CreateMap<ProgrammingTechnology, UpdatedProgrammingTechnologyDto>().ReverseMap();

            CreateMap<IPaginate<ProgrammingTechnology>, ProgrammingTechnologyListModel>().ReverseMap();
            CreateMap<ProgrammingTechnology, ProgrammingTechnologyListDto>().ForMember(pt => pt.ProgrammingLanguageName, opt => opt.MapFrom(ptn => ptn.ProgrammingLanguage.Name)).ReverseMap();
            CreateMap<ProgrammingTechnology, ProgrammingTechnologyGetByIdDto>().ReverseMap();
        }
    }
}
