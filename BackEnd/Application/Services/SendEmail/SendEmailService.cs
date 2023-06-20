using Application.Common.Exceptions;
using Application.Common.Response;
using Application.Cqrs.ArtificialIntelligence.Queries;
using Application.Cqrs.User.Commands;
using Application.DTOs.ArtificialIntelligence;
using Application.DTOs.Email;
using Application.Interfaces.ArtificialIntelligence;
using Application.Interfaces.Email;
using Application.Interfaces.SendEmail;
using Application.Interfaces.User;
using Application.Services.ArtificialIntelligence;
using AutoMapper;
using Domain.Interfaces;
using MediatR;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.SendEmail
{
    public class SendEmailService : ISendEmailService
    {
        private readonly IArtificialIntelligenceService _artificialIntelligenceService;
        private readonly IUserService _userService;
        private readonly IEmailService _emailService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _autoMapper;
        private readonly string _urlPage;

        public SendEmailService(IArtificialIntelligenceService artificialIntelligenceService, 
                                IUserService userService, 
                                IEmailService emailService, 
                                IUnitOfWork unitOfWork, 
                                IMapper mapper,
                                IConfiguration configuration)
        {
            _artificialIntelligenceService = artificialIntelligenceService;
            _userService = userService;
            _emailService = emailService;
            _unitOfWork = unitOfWork;
            _autoMapper = mapper;
            _urlPage = configuration["UrlPage"];

        }
        public async Task GenerateEmail()
        {
            //Consultar las IA con el atributo "isNew" en true
            var itemsA = await _artificialIntelligenceService.GetArtificialIntelligenceNew();

            //Generar el contenido del correo electrónico
            if (itemsA.Data.Count > 0)
            {
                var response = new EmailDto();

                response.Body = "<html><body>";
                response.Body += "<h1>Inteligencias Artificiales nuevas de la semana:</h1>";
                foreach (var item in itemsA.Data)
                {
                    response.Body += "<h2>" + item.Name + "</h2>";
                    response.Body += "<p>" + item.Description + "</p>";
                }
                response.Body += "<a href='"+ _urlPage + "' target='_blank'>Ir a nuestra pagina web</a>";
                response.Body += "</body></html>";
                //Enviar el correo electrónico a los usuarios
                var itemsU = await _userService.GetUsers();
                foreach (var item in itemsU.Data)
                {
                    response.To = item.Email;
                    response.Subject = "Nueva Inteligencia Artificial - Ven a ver";
                    _emailService.SendEmail(response);
                }
                //Actualizar el atributo "isNew" de las IA a false
                foreach (var item in itemsA.Data)
                {
                    try
                    {
                        var artificialIntelligence = _autoMapper.Map<Domain.Models.ArtificialIntelligence>(item);
                        artificialIntelligence.IsNew = false;
                        await _unitOfWork.ArtificialIntelligenceRepository.Put(artificialIntelligence);
                    }
                    catch (Exception ex)
                    {
                        var message = ex.Message;
                    }

                }

            }

        }

        public async Task<ApiResponse<bool>> RecoverPassword(RecoverPasswordCommand request)
        {
            var response = new ApiResponse<bool>();

            try
            {
                var UserExist = _unitOfWork.UserRepository.Get().FirstOrDefault(x => x.Email == request.Email);

                if (UserExist == null)
                {
                    throw new BadRequestException("El correo no esta registrado");
                }

                var email = new EmailDto();

                email.Body = "<html><body>";
                email.Body += "<h2>Cambia la contraseña</h2>";
                email.Body += "<p>Presiona el texto de abajo para cambiar la contraseña</p>";
                email.Body += "<a href='" + _urlPage+ "recoverPassword" + "' target='_blank'>Recuperar Contraseña</a>";
                email.Body += "</body></html>";
                email.To = request.Email;
                email.Subject = "Recuperar Contraseña";
                _emailService.SendEmail(email);

                response.Data = true;
                response.Result = true;
                response.Message = "Ok";
            }
            catch (Exception ex)
            {
                response.Result = false;
                response.Message = $"Error al eliminar el registro, consulte con el administrador. {ex.Message} ";
                throw;
            }
            return response;
        }
    }
}


