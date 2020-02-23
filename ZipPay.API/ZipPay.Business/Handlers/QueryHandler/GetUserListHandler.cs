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
    public class GetUserListHandler : IRequestHandler<GetUserListQuery, List<User>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public GetUserListHandler(IUserRepository userRepository,IMapper mapper)
        {
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }


        public async Task<List<User>> Handle(GetUserListQuery request, CancellationToken cancellationToken)
        {
            var userEntities = await _userRepository.GetUserListAsync();
            return _mapper.Map<List<UserEntity>,List<User>>(userEntities);
        }
    }
}
