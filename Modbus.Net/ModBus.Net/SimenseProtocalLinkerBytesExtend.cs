﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModBus.Net
{
    public class SimenseTcpProtocalLinkerBytesExtend : ProtocalLinkerBytesExtend
    {
        public override byte[] BytesExtend(byte[] content)
        {
            Array.Copy(new byte[]{0x03,0x00,0x00,0x00,0x02,0xf0,0x80}, 0, content, 0, 7);
            Array.Copy(ValueHelper.Instance.GetBytes((ushort)content.Length), 0, content, 2, 2);
            return content;
        }

        public override byte[] BytesDecact(byte[] content)
        {
            byte[] newContent = new byte[content.Length - 7];
            Array.Copy(content, 7, newContent, 0, newContent.Length);
            return newContent;
        }
    }
}
