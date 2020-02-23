using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ZipPay.Business.Messages.Queries;
using ZipPay.Data.Entities;
using ZipPay.Data.Repositories;
using ZipPay.DataContract;

namespace ZipPay.Business.Handlers.QueryHandler
{
    public class GetUserByEmailHandler : IRequestHandler<GetUserByEmailQuery, User>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public GetUserByEmailHandler(IUserRepository userRepository,IMapper mapper)
        {
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }


        public async Task<User> Handle(GetUserByEmailQuery request, CancellationToken cancellationToken)
        {
            var userEntity = await _userRepository.GetUserByEmailAsync(request.EmailAddress);
            return _mapper.Map<UserEntity,User>(userEntity);
        }
    }
}
