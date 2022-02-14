using AutoMapper;
using MailKit.Net.Smtp;
using MediatR;
using Microsoft.Extensions.Options;
using MimeKit;
using MimeKit.Text;
using NgGlobal.ApplicationServices.Commands;
using NgGlobal.ApplicationServices.ConfigurationOptions;
using NgGlobal.CoreServices.Repositories.Abstractions;
using NgGlobal.DatabaseModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NgGlobal.ApplicationServices.Handlers
{
    public class SetMailAboutCarHandler:IRequestHandler<SetMailAboutCarCommand,bool>
    {
        private readonly IMapper _mapper;
        private readonly IOptions<MailOption> _mailOption = default;
        private readonly IRepository<CarInfoMail> _carMailRepository;

        public SetMailAboutCarHandler(IMapper mapper,IOptions<MailOption> mailOption, IRepository<CarInfoMail> carMailRepository)
        {
            _mapper = mapper;
            _mailOption = mailOption;
            _carMailRepository = carMailRepository;
        }

        public async Task<bool> Handle(SetMailAboutCarCommand request, CancellationToken cancellationToken)
        {
            var carMail = _mapper.Map<CarInfoMail>(request);
            var senderResult = SentMessage(request);
            if (senderResult)
            {
                return await _carMailRepository.CreateAsync(carMail);
            }

            return senderResult;
        }

        public bool SentMessage(SetMailAboutCarCommand model)
        {
            try
            {
                var message = new MimeMessage();
                message.From.Add(new MailboxAddress(model.PhoneNumber, model.Email));
                message.To.Add(new MailboxAddress("NgGLobal", "oqruadze1997@gmail.com"));
                message.Subject = "Cars";
                message.Body = new TextPart(TextFormat.Html) { 
                    Text = $"<ul>" +
                        $"<li>Full Name : ${model.FullName}</li>" +
                        $"<li>Year : ${model.Year}</li>" +
                        $"<li>Car Mark : ${model.CarMark}</li>" +
                        $"<li>Car Model : ${model.CarModel}</li>" +
                        $"<li>Message : ${model.Message}</li>" +
                    $"</ul>" 
                };

                using (SmtpClient client = new())
                {
                    client.Connect("smtp.gmail.com", 587, false);
                    client.Authenticate(_mailOption.Value.Email, _mailOption.Value.Password);
                    client.Send(message);
                    client.Disconnect(true);
                }

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
