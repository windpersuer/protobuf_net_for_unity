namespace Client.Protobuf
{
	public partial class TheMsg
	{
		public override string ToString ()
		{
			return string.Format ("[TheMsg: name={0}, num={1}]", name, num);
		}
	}
}
