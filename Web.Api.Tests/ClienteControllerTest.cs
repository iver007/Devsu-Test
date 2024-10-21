using Web.Api.Controllers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using Application.Services;
using MassTransit;
using FluentValidation;
using Application.Dto;
using System.Security.Claims;
using FluentValidation.Results;
using AutoMapper;
using Domain.Interface.Repository;
using Infrastructure.Repository;

namespace Web.Api.Tests
{
    public class ClienteControllerTests
    {
        private Mock<ClienteController> clienteController;
        private readonly Mock<ClienteService> mockClienteService = new Mock<ClienteService>();
        private readonly Mock<IPublishEndpoint> mockPublishEndpoint = new Mock<IPublishEndpoint>();
        private readonly Mock<IValidator<ClienteDto>> mockValidator = new Mock<IValidator<ClienteDto>>();
       
        [SetUp]
        public void setup()
        {
            var controllerContext = new ControllerContext() { HttpContext = new DefaultHttpContext() { User = null } };

            clienteController = new Mock<ClienteController>(
                mockClienteService.Object,
                mockPublishEndpoint.Object,
                mockValidator.Object);

            clienteController.Setup(x => x.Ok(It.IsAny<object>())).Returns(new OkObjectResult("true"));
            clienteController.Object.ControllerContext = controllerContext;
        }

        [Test]
        public async Task AddClienteAsync_ReturnsOkResult()
        {
            mockClienteService.Setup(service => service.AddCliente(It.IsAny<ClienteDto>()))
               .ReturnsAsync(new ApiResponse());
           mockValidator.Setup(service => service.Validate(It.IsAny<ClienteDto>()))
               .Returns(new FluentValidation.Results.ValidationResult());

            ClienteDto dto = new ClienteDto();
            dto.Nombre = "iver";

            var actionResult = await clienteController.Object.AddClienteAsync(dto);

            var realResult = (OkObjectResult)actionResult.Result;

            Assert.That(realResult.StatusCode == StatusCodes.Status200OK);
        }
    }
}
