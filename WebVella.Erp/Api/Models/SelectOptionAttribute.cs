using System;

namespace WebVella.Erp.Api.Models
{
	public enum SelectOptionType { String, Int }

	[AttributeUsage(AttributeTargets.All, AllowMultiple = false)]
	public class SelectOptionAttribute : Attribute
	{
		private string _label = string.Empty;
		private string _iconClass = string.Empty;
		private string _color = string.Empty;
		private bool _isVisible = true;
		private SelectOptionType _selectOptionType = SelectOptionType.Int;

		public virtual string Label
		{
			get { return _label; }
			set { _label = value; }
		}

		public virtual string IconClass
		{
			get { return _iconClass; }
			set { _iconClass = value; }
		}

		public virtual string Color
		{
			get { return _color; }
			set { _color = value; }
		}

		public virtual bool IsVisible
		{
			get { return _isVisible; }
			set { _isVisible = value; }
		}

		public virtual SelectOptionType SelectOptionType
		{
			get { return _selectOptionType; }
			set { _selectOptionType = value; }
		}
	}
}
