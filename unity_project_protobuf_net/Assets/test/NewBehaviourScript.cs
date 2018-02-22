using UnityEngine;
using System.Collections.Generic;
using System.IO;
using Client.Metadata;

public class NewBehaviourScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Space))
		{
			_TestProtobuff2 ();
		}
	}

	private void _TestProtobuff2 ()
	{
		//1. new a message.
		TheMsg message_1 = new TheMsg ();
		message_1.name = "steve jobs";
		message_1.num = 32766;
		Debug.Log ("message1: " + message_1.ToString());

		//2. write byte buffer to file.
		string content = ProtobufSerilize.Serialize<TheMsg>(message_1);
		Debug.Log (content);
		File.WriteAllText("C:/D/message.txt", content);

		TheMsg message2 = ProtobufSerilize.DeSerialize<TheMsg>(content);
		Debug.Log ("message2: " + message2.name);
	}

	private void _TestProtobuff ()
	{
		var p1 = new Person
		{
			Id = 10000,
			Name = "八百里开外",
			Address = new Address
			{
				Line1 = "Line1",
				Line2 = "Line2"
			}
		};

		var p2 = new Person
		{
			Id = 10000,
			Name = "一枪",
			Address = new Address
			{
				Line1 = "Flat Line1",
				Line2 = "Flat Line2"
			}
		};

		//写入文件
		List<Person> pSource = new List<Person>() { p1, p2 };
		string content = ProtobufSerilize.Serialize<List<Person>>(pSource);
		Debug.Log (content);
		File.WriteAllText("C:/D/hello.txt", content);


		Debug.Log ("解析部分");
		List<Person> pResult = ProtobufSerilize.DeSerialize<List<Person>>(content);
		foreach (Person p in pResult)
		{
			Debug.Log (p.Name);
		}
	}
}
