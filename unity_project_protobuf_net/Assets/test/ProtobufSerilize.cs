using System.IO;
using System.Text;
using ProtoBuf;

public class ProtobufSerilize  
{

	/// <summary>
	/// 序列化
	/// </summary>
	/// <typeparam name="T"></typeparam>
	/// <param name="t"></param>
	/// <returns></returns>
	public static string Serialize<T>(T t)
	{
		using (MemoryStream memoryStream = new MemoryStream())
		{
			Serializer.Serialize<T>(memoryStream, t);
			byte [] bytes = memoryStream.ToArray ();
			string result = Encoding.UTF8.GetString (bytes);
			return result;
		}
	}

	/// <summary>
	/// 反序列化
	/// </summary>
	/// <typeparam name="T"></typeparam>
	/// <param name="content"></param>
	/// <returns></returns>
	public static T DeSerialize<T>(string content)
	{
		byte [] bytes = Encoding.UTF8.GetBytes (content);
		using (MemoryStream memoryStream = new MemoryStream(bytes))
		{
			T t = Serializer.Deserialize<T>(memoryStream);
			return t;
		}
	}


	public static string SerializeNew<T>(T t)
	{
		string filePath = "C:\\D\\test.txt";
		using (Stream stream = File.Open (filePath, FileMode.CreateNew))
		{
			Serializer.Serialize<T>(stream, t);
		}
	}

	public static T DeSerializeNew<T>()
	{
		string filePath = "C:\\D\\test.txt";
		using (FileStream stream = new FileStream (filePath, FileMode.Open)) 
		{
			T t = Serializer.Deserialize<T>(stream);
			return t;
		}
	}
}
