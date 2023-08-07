using BlacksmithWorkshopBusinessLogic.MailWorker;
using BlacksmithWorkshopContracts.BusinessLogicsContracts;
using BlacksmithWorkshopContracts.SearchModels;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BlacksmithWorkshopView
{
    public partial class FormMessage : Form
    {
        private readonly ILogger _logger;
        private readonly IMessageInfoLogic _logic;
        private readonly AbstractMailWorker _mailWorker;
        private readonly IClientLogic _clientLogic;
        private string? _id;
        public string Id { set { _id = value; } }
        public FormMessage(ILogger<FormMessage> logger, IMessageInfoLogic messageInfoLogic, AbstractMailWorker abstractMailWorker, IClientLogic clientLogic)
        {
            InitializeComponent();
            _logger = logger;
            _logic = messageInfoLogic;
            _clientLogic = clientLogic;
            _mailWorker = abstractMailWorker;
        }
        private void ButtonSend_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxBody.Text))
            {
                MessageBox.Show("Заполните содержимое письма", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _logger.LogInformation("Отправка ответа");
            try
            {
                var view = _logic.ReadElement(new() { MessageId = _id });
                if (view != null)
                {
                    var operationResult = _logic.Update(new()
                    {
                        MessageId = view.MessageId,
                        IsRead = view.IsRead,
                        ReplyText = textBoxReply.Text
                    });
                    if (!operationResult)
                    {
                        throw new Exception("Ошибка при сохранении. Дополнительная информация в логах.");
                    }
                    _mailWorker.MailSendAsync(new()
                    {
                        MailAddress = _clientLogic.ReadElement(new ClientSearchModel { Id = view.ClientId })!.Email,
                        Subject = textBoxSubject.Text,
                        Text = textBoxReply.Text,
                    });
                    MessageBox.Show("Сохранение и отправление прошло успешно", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DialogResult = DialogResult.OK;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка сохранения исполнителя");
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void FormMessage_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(_id))
            {
                try
                {
                    _logger.LogInformation("Получение письма");
                    var view = _logic.ReadElement(new MessageInfoSearchModel
                    {
                        MessageId = _id
                    });
                    if (view == null)
                    {
                        return;
                    }
                    textBoxSender.Text = view.SenderName;
                    textBoxSubject.Text = view.Subject;
                    textBoxBody.Text = view.Body;
                    if (!view.IsRead)
                    {
                        var updateResult = _logic.Update(new()
                        {
                            MessageId = _id,
                            ReplyText = view.ReplyText,
                            IsRead = true,
                        });
                        if (!updateResult)
                        {
                            throw new Exception("Ошибка при обновлении");
                        }
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Ошибка получения письма");
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                }
            }
        }
    }
}
