using System.IO;
using System.Text;
using ProtoBuf;

public class ProtobufSerilize  
{
	public static void Serialize<T>(T t, string filePath)
	{
		if(File.Exists(filePath))
		{
			File.Delete (filePath);
		}
		using (FileStream fileStream = new FileStream (filePath, FileMode.CreateNew))
		{
			Serializer.Serialize<T>(fileStream, t);
			fileStream.Flush ();
		}
	}

	public static T DeSerialize<T>(string filePath)
	{
		using (FileStream fileStream = new FileStream (filePath, FileMode.Open))
		{
			T t = Serializer.Deserialize<T>(fileStream);
			return t;
		}
	}



	/*
	public static string SerializeNew<T>(T t)
	{
		using (MemoryStream memoryStream = new MemoryStream())
		{
			Serializer.Serialize<T>(memoryStream, t);
			byte [] bytesBuffer = memoryStream.ToArray ();
			File.WriteAllBytes (filePath, bytesBuffer);

			string content = Encoding.UTF8.GetString (bytesBuffer);
			return content;
		}
	}

	public static T DeSerializeNew<T>()
	{
		byte [] bytesBuffer = Encoding.UTF8.GetBytes (content);
		using (MemoryStream memoryStream = new MemoryStream(bytesBuffer))
		{
			T t = Serializer.Deserialize<T>(memoryStream);
			return t;
		}
	}
	*/
}
