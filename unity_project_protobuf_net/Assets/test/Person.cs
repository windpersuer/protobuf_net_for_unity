using ProtoBuf;

[ProtoContract]
class Person
{
	[ProtoMember(1)]
	public int Id { get; set; }
	[ProtoMember(2)]
	public string Name { get; set; }
	[ProtoMember(3)]
	public Address Address { get; set; }
}