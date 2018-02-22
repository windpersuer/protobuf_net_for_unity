# protobuf_net_for_unity
# protobuf_for_unity
google's protobuf 3.2.0 for Unity3d 5.x

source:
[google's protobuf](https://github.com/google/protobuf/tree/master/csharp)<br>
version: 3.2.0<br>
apply to: Unity3d 5.x<br>
notes: Unity 2017 and later version, please use google official version<br>
<br>
instruction:<br>
open the unity project: unity_project_protobuf<br>
![](https://raw.githubusercontent.com/windpersuer/protobuf_for_unity/master/doc/Project.png)<br><br>

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
![](https://github.com/windpersuer/protobuf_for_unity/blob/master/doc/Log.png)<br><br>
it worked! <br>

<br>
and then, we should define 'test_msg.proto' in ./proto_origin<br>
```protobuf
syntax = "proto3";

message TheMsg {
  string name = 1;
  int32 num = 2;
}
```

and, if you haven't set the "envionment variables" of your Operation System, then set it like this: <br>
Path=C:/.../protobuf_for_unity/protoc.exe<br>
proto_path=C:/.../protobuf_for_unity/protoc.exe<br>
Of course, you can copy 'protoc.exe' to anywhere, as long as you filled the right path<br>

at last,  click 'generate_proto.bat' to generate 'TestMsg.cs' into ./proto_autocode<br>
and copy 'TestMsg.cs' to unity project<br>

