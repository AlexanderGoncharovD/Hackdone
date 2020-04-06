using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Debug
{
	public static class AppDebug
	{
		#region Private Methods

		private static Text _debufText;

		#endregion

		#region Public Fields

		public static bool isDebug = true;

		#endregion
		
		public static void Info(string message)
		{
			if (_debufText == null)
			{
				_debufText = GameObject.FindGameObjectWithTag("Debug").GetComponent<Text>();
			}
			_debufText.text += $"\n{message}";
		}
	}
}
