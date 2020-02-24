using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ZipPay.Business.Messages.Queries;
using ZipPay.Data.Entities;

using ZipPay.Data.Repositories.Read;
using ZipPay.DataContract;
using ZipPay.DataContract.Exceptions;

namespace ZipPay.Business.Handlers.QueryHandler
{
    public class GetUserByEmailHandler : IRequestHandler<GetUserByEmailQuery, UserDetail>
    {
        private readonly IUserReadRepository _userRepository;
        private readonly IMapper _mapper;
        public GetUserByEmailHandler(IUserReadRepository userRepository,IMapper mapper)
        {
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }


        public async Task<UserDetail> Handle(GetUserByEmailQuery request, CancellationToken cancellationToken)
        {
            var userEntity = await _userRepository.GetUserByEmailAsync(request.EmailAddress);
            if (userEntity == null)
                throw new ResourceNotFoundException("EmailAddress doesn't exist.");
            return _mapper.Map<UserEntity,UserDetail>(userEntity);
        }
    }
}
