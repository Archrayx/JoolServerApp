using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using JoolServerApp.Service;
using System.Collections.Generic;
using JoolServerApp.Data;
using Moq;
using JoolServerApp.Repo;

namespace JoolServerApp.Web
{
    [TestClass]
    public class UserTests
    {
        //private readonly Mock<JoolServerEntities> _context = new Mock<JoolServerEntities>();
        private readonly Mock<IRepository<tblUser>> _context = new Mock<IRepository<tblUser>>();
        private IUserService userService;

        [TestInitialize]
        public void Setup()
        {
            userService = new UserService(_context.Object);
        }

        [TestMethod]
        public void GetAllUsersTest()
        {
            throw new NotImplementedException();
        }

        [TestMethod]
        public void GetUserTest(long id)
        {
            throw new NotImplementedException();
        }

        [TestMethod]
        public void insertUserTest(tblUser user)
        {
            throw new NotImplementedException();
        }

        [TestMethod]
        public void UpdateUserTest(tblUser user)
        {
            throw new NotImplementedException();
        }

        [TestMethod]
        public void DeleteUserTest(tblUser user)
        {
            throw new NotImplementedException();
        }

    }
}