using System;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using UIKit;

namespace TechTalk.iOS
{

	public enum IconsEnum
	{
		[Description("Gallery")]
		Gallery 	= '\uf03e',
		[Description("Cool option")]
		CoolOption	= '\uf164',
		[Description("For noobs")]
		ForNoobs	= '\uf19d',
		[Description("Rush B")]
		RushB		= '\uf0fb',
		[Description("About")]
		About		= '\uf001'
	}
	public class IconMapper
	{
		private const string SPACE = " ";

		public static void MapMenuTextLabel(UILabel label)
		{
			var icon = GetCharForDescription<IconsEnum>(label.Text);
			label.Text = icon + SPACE + label.Text;
			label.Font = UIFont.FromName("FontAwesome", 20f);
			label.TextColor = EpamStyles.PrimaryColor4;
		}

		private static char GetCharForDescription<T>(string textDesc)
		{
			Type type = typeof(T);
			string[] names = Enum.GetNames(type);
			foreach (string name in names)
			{
				FieldInfo field = type.GetField(name);

				if (field != null)
				{
					DescriptionAttribute attr =
						   Attribute.GetCustomAttribute(field,
							 typeof(DescriptionAttribute)) as DescriptionAttribute;
					if (attr != null && attr.Description!=null && attr.Description.Equals(textDesc))
					{
						return Convert.ToChar((int)Enum.Parse(type, name)); ;
					}
				}
			}

			return ' '; // here we can use some constant
		}

	}


}

