using AutoMapper;
using SurveySystem.Data.DTOModels.RequestObjects;
using SurveySystem.Data.DTOModels.ResponseObjects;
using SurveySystem.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SurveySystem.Common.Mapping
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            // Add as many of these lines as you need to map your objects
            CreateMap<ElementEntity, ElementResponse>();
            CreateMap<AnswerRequest, AnswerEntity>().
                ForMember(dest => dest.QuestionElementId, opt => opt.MapFrom(source => source.ParentId))
                .ForMember(dest => dest.AnswerElement, opt => opt.MapFrom(source => source.Element));
        }
    }
}
