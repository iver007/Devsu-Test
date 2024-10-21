using Application.Dto;
using Application.Profiles;
using Application.Services;
using AutoMapper;
using Domain.Entity;
using Domain.Interface.Repository;
using Moq;
using NUnit.Framework;
using System.Security.Claims;

namespace Application.Test.Services
{
    public class ClienteServiceTest
    {
        private Mock<ClienteService> mockClienteService;

        private IMapper mapper;
        private Mock<IClienteRepository> mockClienteRepository;
      
        public ClienteServiceTest()
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile<CustomerProfile>();
                mc.AllowNullCollections = false;
            });

            this.mapper = mappingConfig.CreateMapper();

            mockClienteRepository = new Mock<IClienteRepository>();
        }

        [SetUp]
        public void Setup()
        {
            mockClienteService = new Mock<ClienteService>(
                mockClienteRepository.Object,
                this.mapper);
        }

        [Test]
        public async Task UpdateCliente_ReturnsError()
        {
            mockClienteRepository.Setup(x => x.GetClienteByCodClienteAsync(It.IsAny<Guid>())).ReturnsAsync((Cliente)null);

            Guid userId = Guid.NewGuid();
            var clienteDto = new ClienteDto();

            var result = await this.mockClienteService.Object.UpdateCliente(userId, clienteDto);

            Assert.That(result.IsFailed, Is.EqualTo(true));
            Assert.That(result.Message, Is.EqualTo("No exists Usuario"));
        }
}
}