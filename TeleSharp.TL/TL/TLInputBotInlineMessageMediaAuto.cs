using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleSharp.TL;
namespace TeleSharp.TL
{
	[TLObject(691006739)]
    public class TLInputBotInlineMessageMediaAuto : TLAbsInputBotInlineMessage
    {
        public override int Constructor
        {
            get
            {
                return 691006739;
            }
        }

             public int flags {get;set;}
     public string caption {get;set;}
     public TLAbsReplyMarkup reply_markup {get;set;}


		public void ComputeFlags()
		{
			flags = 0;
flags = reply_markup != null ? (flags | 4) : (flags & ~4);

		}

        public override void DeserializeBody(BinaryReader br)
        {
            flags = br.ReadInt32();
caption = StringUtil.Deserialize(br);
if ((flags & 4) != 0)
reply_markup = (TLAbsReplyMarkup)ObjectUtils.DeserializeObject(br);
else
reply_markup = null;


        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            ComputeFlags();
bw.Write(flags);
StringUtil.Serialize(caption,bw);
if ((flags & 4) != 0)
ObjectUtils.SerializeObject(reply_markup,bw);

        }
    }
}
