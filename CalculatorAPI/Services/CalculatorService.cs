using AutoMapper;
using CalculatorAPI.Entities;
using CalculatorAPI.Response;
using CalculatorAPI.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace CalculatorAPI.Services
{
    public interface ICalculatorService
    {
        Task<List<CalculatorViewModel>> GetAllAnswerAsync();
        Task<ResponseModel> AddAnswerAsync(CalculatorViewModel model);
    }

    public class CalculatorService : ICalculatorService
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;
        public CalculatorService(AppDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<ResponseModel> AddAnswerAsync(CalculatorViewModel model)
        {
            try
            {
                model.Date = DateTime.UtcNow;
                var result = _mapper.Map<Calculator>(model);
                await _dbContext.Calculator.AddAsync(result);
                await _dbContext.SaveChangesAsync();
                return new ResponseModel { StatusCode = 200, Message = "Answer Stored!" };
            }
            catch
            {
                return new ResponseModel { StatusCode = 500, Message = "Something went wrong, please try again!" };
            }
        }

        public async Task<List<CalculatorViewModel>> GetAllAnswerAsync()
        {
            try
            {
                var answerList = await _dbContext.Calculator.ToListAsync();
                answerList.Reverse();

                if (answerList.Count <= 50)
                {
                    return _mapper.Map<List<CalculatorViewModel>>(answerList);
                }
                else
                {
                    _dbContext.Calculator.RemoveRange(answerList);
                    await _dbContext.SaveChangesAsync();
                    return new();
                }
            }
            catch
            {
                return new();
            }
        }
    }
}
