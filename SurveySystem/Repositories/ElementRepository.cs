using SurveySystem.Data;
using SurveySystem.Data.DTOModels.ResponseObjects;
using SurveySystem.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using SurveySystem.Data.Interfaces;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

namespace SurveySystem.Repositories
{
    public class ElementRepository : IElementRepository
    {
        private ISurveyContext surveyContext;
        private readonly MapperConfiguration mapperConfiguration;
        private readonly IMapper mapper;

        public ElementRepository(ISurveyContext surveyContext, MapperConfiguration mapperConfiguration)
        {
            this.surveyContext = surveyContext;
            this.mapperConfiguration = mapperConfiguration;
            this.mapper = mapperConfiguration.CreateMapper();
        }
        public IReadOnlyList<ElementResponse> getElementsByCategory(int IdCategory)
        {
            IReadOnlyList<ElementResponse> result = this.surveyContext.Elements
              .Where(x => x.IsActive==true && x.CategoryId==IdCategory)
              .ProjectTo<ElementResponse>(this.mapperConfiguration)
              .AsNoTracking().ToList();

            return result;
        }
    }
}
