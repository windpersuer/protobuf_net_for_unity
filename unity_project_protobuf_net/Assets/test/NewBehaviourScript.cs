using UnityEngine;
using System.Collections.Generic;
using System.IO;
using Client.Metadata;

public class NewBehaviourScript : MonoBehaviour {

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(Input.GetKeyDown(KeyCode.Space))
		{
			_TestProtobuff ();
		}
	}

	private void _TestProtobuff ()
	{
		var p1 = new Person
		{
			Id = 10000,
			Name = "apple inc.",
			Address = new Address
			{
				Line1 = "Cupertino, California, USA",
				Line2 = "Shenzhen, Guangdong, China"
			}
		};

		var p2 = new Person
		{
			Id = 10000,
			Name = "spacex corp.",
			Address = new Address
			{
				Line1 = "Hawthorne, California, USA",
				Line2 = "Shanghai, China"
			}
		};

		string filePath = "C:/D/persons.txt";
		{
			//2
			List<Person> personList = new List<Person>() { p1, p2 };
			ProtobufSerilize.Serialize<List<Person>>(personList, filePath);
			string persons = string.Empty;
			foreach (Person p in personList)
			{
				persons += p.Name + ", ";
			}
			Debug.Log (persons);
		}

		{
			//3
			List<Person> personList = ProtobufSerilize.DeSerialize<List<Person>> (filePath);
			string persons = string.Empty;
			foreach (Person p in personList)
			{
				persons += p.Name + ", ";
			}
			Debug.Log (persons);
		}
	}

	private void _TestProtobuff2 ()
	{
		//1. new a message.
		TheMsg message_1 = new TheMsg ();
		message_1.name = "steve jobs";
		message_1.num = 20111005;
		Debug.Log ("message_1: " + message_1.ToString());

		string filePath = "C:\\D\\message.txt";
		{
			//2. write byte buffer to file.
			ProtobufSerilize.Serialize<TheMsg>(message_1, filePath);
		}

		{
			//3. read content.
			TheMsg message_2 = ProtobufSerilize.DeSerialize<TheMsg>(filePath);
			Debug.Log ("message_2: " + message_2.ToString());
		}
	}
}
