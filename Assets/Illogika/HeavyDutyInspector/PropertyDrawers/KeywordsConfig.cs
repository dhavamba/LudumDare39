//----------------------------------------------
//            Heavy-Duty Inspector
//      Copyright © 2014 - 2017  Illogika
//----------------------------------------------
using UnityEngine;
using System.Linq;
using System.Collections.Generic;

namespace HeavyDutyInspector
{

	public class KeywordsConfig : ScriptableObject
	{

		public List<KeywordCategory> keyWordCategories = new List<KeywordCategory>();

	}

	[System.Serializable]
	public class KeywordCategory : System.Object
	{
		public string name;

		[System.NonSerialized]
		public bool expanded;

		public List<string> keywords = new List<string>();

		public KeywordCategory()
		{
			name = "";
		}

		public KeywordCategory(string name)
		{
			this.name = name;
		}
	}

}
