using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ZipPay.Business.Messages.Commands;
using ZipPay.Business.Messages.Queries;
using ZipPay.Data.Entities;
using ZipPay.Data.Repositories.Read;
using ZipPay.Data.Repositories.Write;
using ZipPay.DataContract;
using ZipPay.DataContract.Exceptions;

namespace ZipPay.Business.Handlers.QueryHandler
{
    public class CreateUserHandler : IRequestHandler<CreateUserCommand,UserDetail>
    {
        private readonly IUserWriteRepository _userWriteRepository;
        private readonly IUserReadRepository _userReadRepository;
        private readonly IMapper _mapper;
        public CreateUserHandler(IUserReadRepository userReadRepository, IUserWriteRepository userWriteRepository,IMapper mapper)
        {
            _userReadRepository = userReadRepository ?? throw new ArgumentNullException(nameof(userReadRepository));
            _userWriteRepository = userWriteRepository ?? throw new ArgumentNullException(nameof(userWriteRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }


        public async Task<UserDetail> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var retrievedUser = await _userReadRepository.GetUserByEmailAsync(request?._User?.EmailAddress);
            if (retrievedUser != null)
                throw new BadRequestException($"User with email address {request?._User?.EmailAddress} already exists.");

            var userEntity = _mapper.Map<User, UserEntity>(request._User);
            userEntity.UserId = Guid.NewGuid();

            await _userWriteRepository.CreateUserAsync(userEntity);
            return _mapper.Map<UserEntity, UserDetail>(userEntity);
        }
    }
}
