using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using McSaas.Houses;
using McSaas.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace McSaas.Sesidents
{
    public class Resident : FullAuditedEntity
    {
        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 电话
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// 身份证
        /// </summary>
        public string CardID { get; set; }

        /// <summary>
        /// 微信号
        /// </summary>
        public string Webchat { get; set; }

        /// <summary>
        /// 性别
        /// </summary>
        public Sex Sex { get; set; }

        /// <summary>
        /// 房子,一对多
        /// </summary>
        public ICollection<House> Houses { get; }
    }
}
