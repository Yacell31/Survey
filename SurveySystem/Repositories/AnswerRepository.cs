using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using SurveySystem.Data.DTOModels.RequestObjects;
using SurveySystem.Data.Entities;
using SurveySystem.Data.Interfaces;
using SurveySystem.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SurveySystem.Repositories
{
    public class AnswerRepository : IAnswerRepository
    {

        private ISurveyContext surveyContext;
        private readonly MapperConfiguration mapperConfiguration;
        private readonly IMapper mapper;

        public AnswerRepository(ISurveyContext surveyContext, MapperConfiguration mapperConfiguration)
        {
            this.surveyContext = surveyContext;
            this.mapperConfiguration = mapperConfiguration;
            this.mapper = mapperConfiguration.CreateMapper();
        }

        public void AddAnswers(IReadOnlyList<AnswerRequest> answerList)
        {
            IList<AnswerEntity> answerEntityList = answerList
            .AsQueryable()
            .ProjectTo<AnswerEntity>(this.mapperConfiguration)
            .AsNoTracking().ToList();

            this.surveyContext.AddRange(answerEntityList.ToArray());
            this.surveyContext.SaveChanges();
        
        }
    }
}
