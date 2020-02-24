using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Threading;
using System.Threading.Tasks;
using ZipPay.Business.Handlers.QueryHandler;
using ZipPay.Business.Mapper;
using ZipPay.Business.Messages.Commands;
using ZipPay.Data.Entities;
using ZipPay.Data.Repositories.Read;
using ZipPay.Data.Repositories.Write;
using ZipPay.DataContract;
using ZipPay.DataContract.Exceptions;
using FluentAssertions;

namespace ZipPay.Business.Tests
{
    [TestClass]
    public class CreateUserHandlerTest
    {
        private  Mock<IUserWriteRepository> _userWriteRepositoryMock;
        private  Mock<IUserReadRepository> _userReadRepositoryMock;
        private  IMapper _mapper;
        private CreateUserHandler _createUserHandlerSut { get; set; }
        private CreateUserCommand createuserCommand { get; set; }

        [TestInitialize]
        public void TestInitialize()
        {
            _userWriteRepositoryMock = new Mock<IUserWriteRepository>();
            _userReadRepositoryMock = new Mock<IUserReadRepository>();
            _mapper =  MappingProfile.InitializeAutoMapper().CreateMapper();
            createuserCommand = GetCreateUserCommand();
            _createUserHandlerSut = new CreateUserHandler(_userReadRepositoryMock.Object,
                _userWriteRepositoryMock.Object, _mapper);
        }

        private CreateUserCommand GetCreateUserCommand()
        {
            return new CreateUserCommand(new User() { EmailAddress = "un@fdomain.com", MonthlyExpense = 100, MonthlyIncome = 100000, UserName = "Name" });
        }
        private UserEntity GetRetrievedEntity()
        {
            return new UserEntity() { UserName="retrievedUser", EmailAddress = "retrieved@domain.com", MonthlyIncome = 10000, MonthlyExpense = 5000 };
        }

        [TestMethod]
        public  void Handle_ShouldCreateUser()
        {
            //Arrange
            UserEntity retrievedUser = null;
            _userReadRepositoryMock.Setup(s => s.GetUserByEmailAsync(It.IsAny<string>())).ReturnsAsync(retrievedUser);
            //Act
            var result =  _createUserHandlerSut.Handle(createuserCommand, CancellationToken.None).Result;
            //Assert          
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.UserId);
            Assert.AreEqual(result.UserName, createuserCommand._User.UserName);
            Assert.AreEqual(result.MonthlyExpense, createuserCommand._User.MonthlyExpense);
            Assert.AreEqual(result.MonthlyIncome, createuserCommand._User.MonthlyIncome);
        }

        [TestMethod]
        public  void Handle_UserAlreadyExists()
        {
            //Arrange
            UserEntity retrievedUser = GetRetrievedEntity();
            _userReadRepositoryMock.Setup(s => s.GetUserByEmailAsync(It.IsAny<string>())).ReturnsAsync(retrievedUser);
            
            //Act 
            Func<Task> createUser = async () => await _createUserHandlerSut.Handle(createuserCommand, CancellationToken.None);

            //Assert
            createUser.Should().Throw<BadRequestException>()
                .WithMessage($"User with email address { createuserCommand._User.EmailAddress} already exists.");

        }

      
    }
}
