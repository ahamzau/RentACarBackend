using Application.Features.Cars.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Cars.Queries.GetById;

public class GetByIdCarQuery : IRequest<GetByIdCarResponse>
{
    public int Id { get; set; }

    public class GetByIdCarQueryHandler : IRequestHandler<GetByIdCarQuery, GetByIdCarResponse>
    {
        private readonly ICarRepository _carRepository;
        private readonly IMapper _mapper;
        private readonly CarBusinessRules _carBusinessRules;

        public GetByIdCarQueryHandler(ICarRepository carRepository, CarBusinessRules carBusinessRules, IMapper mapper)
        {
            _carRepository = carRepository;
            _carBusinessRules = carBusinessRules;
            _mapper = mapper;
        }

        public async Task<GetByIdCarResponse> Handle(GetByIdCarQuery request, CancellationToken cancellationToken)
        {
            await _carBusinessRules.CarIdShouldExistWhenSelected(request.Id);

            Car? car = await _carRepository.GetAsync(c => c.Id == request.Id, include: c =>  c.Include(c => c.CarImages));
            GetByIdCarResponse carDto = _mapper.Map<GetByIdCarResponse>(car);
            return carDto;
        }
    }
}
