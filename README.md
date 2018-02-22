# protobuf_net_for_unity
google's protobuf 2.* for Unity3d 2018

source:
[google's protobuf](https://github.com/google/protobuf/tree/master/csharp)<br>
version: 2.*<br>
apply to: Unity3d 2018<br>
notes: Unity 5.0 and before version, please use protobuf_for_unity version<br>
<br>
instruction:<br>
open the unity project: unity_project_protobuf_net<br>
![](https://raw.githubusercontent.com/windpersuer/protobuf_net_for_unity/master/doc/Project.png)<br><br>

notice the 'NewBehaviourScript.cs' click unity run<br>
```C#
    private void _TestProtobuff ()
    {
        //1. new a message.
        TheMsg message_1 = new TheMsg ();
        message_1.Name = "steve jobs";
        message_1.Num = 19550224;
        Debug.Log ("message1: " + message_1.ToString());

        //2. write byte buffer to file.
        byte[] byte_buffer;
        using (MemoryStream memoryStream = new MemoryStream())
        {
            message_1.WriteTo (memoryStream);
            byte_buffer = memoryStream.ToArray ();
        }

        //3. read message from byte buffer.
        TheMsg message_2 = TheMsg.Parser.ParseFrom (byte_buffer);
        Debug.Log ("message2: " + message_2.ToString ());
    }
```
log out: <br>
![](https://github.com/windpersuer/protobuf_net_for_unity/blob/master/doc/Log.png)<br><br>
it worked! <br>

at last, cd './ProtoGen/', click 'protogen.bat' to generate './input/test_msg.cs' into './output/test_msg.cs'<br>
and copy 'test_msg.cs' to unity project<br>


and 'test_msg.proto' in ./ProtoGen/input/<br>
```
protobuf
syntax = "proto2";

message TheMsg {
  string name = 1;
  int32 num = 2;
}
```
<br>
