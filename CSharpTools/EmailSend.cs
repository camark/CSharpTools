using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace CSharpTools
{
    class EmailSend
    {
        #region 发送邮件
        /// <summary>
        /// 发送邮件
        /// </summary>
        /// <param name="sub">主题</param>
        /// <param name="body">内容</param>
        /// <param name="smtp">SMTP服务器</param>
        /// <param name="userName">注册的邮箱如aa@163.com </param>
        /// <param name="pwd">邮箱密码</param>
        /// <param name="nicName">发送邮件时候使用的昵称</param>
        /// <param name="sendUser">要发送的用户的邮箱</param>
        /// <returns></returns>
        public static int SendMail(string sub, string body, string smtp, string userName, string pwd, string nicName, string sendUser)
        {

            //邮件发送服务器
            SmtpClient mySmtpClient = new SmtpClient(smtp); // host and port
            //发送邮件的账号 密码
            mySmtpClient.Credentials = new System.Net.NetworkCredential(userName, pwd);
            //加密
            //mySmtpClient.EnableSsl = true;
            //新建邮件
            MailMessage NewMsg = new MailMessage();
            //发件人
            NewMsg.From = new MailAddress(userName, nicName);
            //收件人
            NewMsg.To.Add(new MailAddress(sendUser));
            //NewMsg.To.Add(new MailAddress("小小汪的邮箱"));
            //邮件主题
            NewMsg.Subject = sub;
            //邮件的正文、编码方式
            NewMsg.Body = body;
            NewMsg.BodyEncoding = System.Text.Encoding.UTF8;
            NewMsg.IsBodyHtml = true;
            //附件
            //NewMsg.Attachments.Add(new Attachment(CVPath));
            //邮件的优先级
            NewMsg.Priority = MailPriority.High;
            //发送
            try
            {
                mySmtpClient.Send(NewMsg);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return 0;
        }
        #endregion
    }
}
