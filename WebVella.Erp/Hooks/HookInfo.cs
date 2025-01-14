using System;

namespace WebVella.Erp.Hooks
{
	public class HookInfo
	{
		public HookAttachmentAttribute AttachAttribute { get; set; }

		public HookAttribute HookAttribute { get; set; }

		public Type Type { get; set; }

		public object Instance { get; set; }

	}
}
