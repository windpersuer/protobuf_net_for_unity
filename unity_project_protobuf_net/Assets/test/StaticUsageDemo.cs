/*
using UnityEngine;  
using UnityEditor;  
using System.Collections.Generic;  
using ProtoBuf;  
using System;  
using System.IO;  
using System.Xml.Serialization;  

namespace StaticUsageDemo  
{  
	[ProtoContract]  
	[Serializable]  
	public class TestDataTable  
	{  
		[ProtoMember(1)]  
		public TestData[] Data = new TestData[0];  
	}  

	[ProtoContract]  
	[Serializable]  
	public class TestData  
	{  
		[ProtoMember(6, IsRequired = true)]  
		public float value { get; set; }  
		[ProtoMember(1, IsRequired = true)]  
		public int UserID { get; set; }  
		[ProtoMember(2, IsRequired = false)]  
		public string UserName { get; set; }  
		[ProtoMember(3, IsRequired = false)]  
		public string UserName2 { get; set; }  
		[ProtoMember(4, IsRequired = false)]  
		public string UserName3 { get; set; }  
		[ProtoMember(5, IsRequired = false)]  
		public string UserName4 { get; set; }  
	}  

	public static class StaticUsageDemo  
	{  
		[MenuItem("Metadata/Create")]  
		public static void CreateFile()  
		{  

			var dataTable = new TestDataTable();  
			int count = 100000;  

			List<TestData> list = new List<TestData>(count);  
			for ( int i =0; i < count; ++i )  
			{  
				list.Add(new TestData  
				{  
					UserID = 0,  
					UserName = "AAA",  
					UserName2 = "AAA",  
					UserName3 = "AAA",  
					UserName4 = "AAA",  
					value = 1,  
				});  
			}  
			dataTable.Data = list.ToArray();  



			{  
				Stream file = File.Open("Tools/Output/TestData.dat", FileMode.OpenOrCreate);  
				try  
				{  
					Debug.Log("tableCount:" + dataTable.Data.Length);  


					Serializer.Serialize<TestDataTable>(file, dataTable);  


					file.Seek(0, SeekOrigin.Begin);  
					TestDataTable table;  

					table = Serializer.Deserialize<TestDataTable>(file);  


					Debug.Log("tableCount:" + table.Data.Length);  
					Debug.Log(string.Format("method 2:{0}", table.Data[1].UserName));  
				}  
				finally  
				{  
					file.Close();  
				}  
			}  

			return;  
		}  
	}  
}  
*/