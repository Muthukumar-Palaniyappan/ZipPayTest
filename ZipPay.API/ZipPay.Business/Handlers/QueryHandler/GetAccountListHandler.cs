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
    public class GetAccountListHandler : IRequestHandler<GetAccountListQuery, List<AccountDetail>>
    {
        private readonly IAccountReadRepository _accountRepository;
        private readonly IMapper _mapper;
        public GetAccountListHandler(IAccountReadRepository accountRepository,IMapper mapper)
        {
            _accountRepository = accountRepository ?? throw new ArgumentNullException(nameof(accountRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }


        public async Task<List<AccountDetail>> Handle(GetAccountListQuery request, CancellationToken cancellationToken)
        {
            var accountEntities = await _accountRepository.GetAccountListAsync();
            return _mapper.Map<List<AccountEntity>,List<AccountDetail>>(accountEntities);
        }
    }
}
