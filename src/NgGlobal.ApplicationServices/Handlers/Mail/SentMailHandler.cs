using AutoMapper;
using MailKit.Net.Smtp;
using MediatR;
using Microsoft.Extensions.Options;
using MimeKit;
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
    public class SentMailHandler : IRequestHandler<SentMailCommand, bool>
    {
        private readonly IMapper _mapper;
        private readonly IOptions<MailOption> _mailOption = default;
        private readonly IRepository<Mail> _mailRepository = default;

        public SentMailHandler(IMapper mapper, IRepository<Mail> mailRepository, IOptions<MailOption> mailOption)
        {
            _mapper = mapper;
            _mailOption = mailOption;
            _mailRepository = mailRepository;
        }

        public async Task<bool> Handle(SentMailCommand request, CancellationToken cancellationToken)
        {
            var mail = _mapper.Map<Mail>(request);
            var senderResult = SentMessage(request);
            if (senderResult)
            {
                return await _mailRepository.CreateAsync(mail);
            }

            return senderResult;
        }

        public bool SentMessage(SentMailCommand model)
        {
            try
            {
                var message = new MimeMessage();
                message.From.Add(new MailboxAddress(model.Name, model.Email));
                message.To.Add(new MailboxAddress("NgGLobal", "oqruadze1997@gmail.com"));
                message.Subject = model.ReasonForEnquiry;
                message.Body = new TextPart("plain") { Text = $"Sender phone : ${model.PhoneNumber}, ${model.Message}" };

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
