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

namespace ZipPay.Business.Handlers.QueryHandler
{
    public class GetUserListHandler : IRequestHandler<GetUserListQuery, List<UserDetail>>
    {
        private readonly IUserReadRepository _userRepository;
        private readonly IMapper _mapper;
        public GetUserListHandler(IUserReadRepository userRepository,IMapper mapper)
        {
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }


        public async Task<List<UserDetail>> Handle(GetUserListQuery request, CancellationToken cancellationToken)
        {
            var userEntities = await _userRepository.GetUserListAsync();
            return _mapper.Map<List<UserEntity>,List<UserDetail>>(userEntities);
        }
    }
}
