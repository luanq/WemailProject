﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wemail.DAL.DTOs;

namespace Wemail.DAL
{
    public class HTTPHelper
    {
        private static List<ContactDTO> contacts = new List<ContactDTO>()
        {
            new ContactDTO { Mail = "test@163.com", Age = 18, Name = "juster",  Phone = "12345678910" }
        };
        public static UserDTO Login(string account, string password)
        {
            if (string.IsNullOrEmpty(account) || string.IsNullOrEmpty(password)) 
                return null;

            if (account.Equals("juster") && password.Equals("123456")) 
                return new UserDTO() { Token = "0ca175b9c0f726a831d895e269332461" };

            return null;
        }
        public static List<ContactDTO> GetContacts()
        {
            var result = new List<ContactDTO>();
            result.AddRange(contacts);
            return result;
        }
        public static bool Insert(string mail, string phone, string name, int age)
        {
            contacts.Add(new ContactDTO { Mail = mail, Age = age, Name = name,  Phone = phone });
            return true;
        }
        public static List<MailDTO> GetMails()
        {
            var sender = new ContactDTO { Mail = "zhuzhen723723@163.com", Age = 18, Name = "juster", Phone = "12345678910" };
            var receiver = new ContactDTO { Mail = "zhuzhen723723@163.com", Age = 18, Name = "juster",Phone = "12345678910" };

            var mails = new List<MailDTO>
            {
                new MailDTO { Subject = "test1 mail 1" , Sender = sender , Reciver = receiver , SendTime = DateTime.Now , ReciverTime = DateTime.Now, Content = "test mail content" },
                new MailDTO { Subject = "test1 mail 2" , Sender = sender , Reciver = receiver , SendTime = DateTime.Now , ReciverTime = DateTime.Now, Content = "test mail content" },
                new MailDTO { Subject = "test1 mail 3" , Sender = sender , Reciver = receiver , SendTime = DateTime.Now , ReciverTime = DateTime.Now, Content = "test mail content" },
                new MailDTO { Subject = "test1 mail 4" , Sender = sender , Reciver = receiver , SendTime = DateTime.Now , ReciverTime = DateTime.Now, Content = "test mail content" },
                new MailDTO { Subject = "test1 mail 5" , Sender = sender , Reciver = receiver , SendTime = DateTime.Now , ReciverTime = DateTime.Now, Content = "test mail content" },
                new MailDTO { Subject = "test1 mail 6" , Sender = sender , Reciver = receiver , SendTime = DateTime.Now , ReciverTime = DateTime.Now, Content = "test mail content" },
                new MailDTO { Subject = "test1 mail 7" , Sender = sender , Reciver = receiver , SendTime = DateTime.Now , ReciverTime = DateTime.Now, Content = "test mail content" },
                new MailDTO { Subject = "test1 mail 8" , Sender = sender , Reciver = receiver , SendTime = DateTime.Now , ReciverTime = DateTime.Now, Content = "test mail content" },
                new MailDTO { Subject = "test1 mail 9" , Sender = sender , Reciver = receiver , SendTime = DateTime.Now , ReciverTime = DateTime.Now, Content = "test mail content" },
                new MailDTO { Subject = "test1 mail 10" , Sender = sender , Reciver = receiver , SendTime = DateTime.Now , ReciverTime = DateTime.Now , Content = "test mail content" }
            };
            return mails;
        }
    }
}
