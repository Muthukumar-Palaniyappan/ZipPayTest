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
    public class CreateAccountHandler : IRequestHandler<CreateAccountCommand,AccountDetail>
    {
        private readonly IAccountWriteRepository _accountWriteRepository;
        private readonly IAccountReadRepository _accountReadRepository;
        private readonly IUserReadRepository _userReadRepository;
        private readonly IMapper _mapper;
        public CreateAccountHandler(IUserReadRepository userReadRepository, IAccountReadRepository accountReadRepository, IAccountWriteRepository accountWriteRepository,IMapper mapper)
        {
            _userReadRepository = userReadRepository ?? throw new ArgumentNullException(nameof(userReadRepository));
            _accountReadRepository = accountReadRepository ?? throw new ArgumentNullException(nameof(accountReadRepository));
            _accountWriteRepository = accountWriteRepository ?? throw new ArgumentNullException(nameof(accountWriteRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }


        public async Task<AccountDetail> Handle(CreateAccountCommand request, CancellationToken cancellationToken)
        {
            await ValidateUserId(request);
            await ValidateAccount(request);
            var newAccountEntity = GetAccountEntity(request);
            await _accountWriteRepository.CreateAccountAsync(newAccountEntity);
            return _mapper.Map<AccountEntity,AccountDetail>(newAccountEntity);
        }

        private AccountEntity GetAccountEntity(CreateAccountCommand request)
        {
            return new AccountEntity()
            {
                UserId = request._Account.UserId,
                Balance = request._Account.Balance,
                AccountNumber = GenerateNewAccountNumber(),
                IsAccountActive = true
            };
        }

        private async Task ValidateAccount(CreateAccountCommand request)
        {
            var accountEntity = await _accountReadRepository.GetAccountByUserIdAsync(request._Account.UserId);
            if (accountEntity != null)
                throw new BadRequestException("An Active Account already exists for this user");
        }

        private async Task ValidateUserId(CreateAccountCommand request)
        {
            var userEntity = await _userReadRepository.GetUserByUserIdAsync(request._Account.UserId);
            if (userEntity == null)
                throw new BadRequestException("User doesn't exist");
            if (userEntity.MonthlyIncome - userEntity.MonthlyExpense < 1000)
                throw new BadRequestException("User is in-eligible to have an account");
        }

        private long GenerateNewAccountNumber()
        {
         return new Random(40000000).Next(40000000, 49999999);
        }
    }
}
