protogen_help
C:\D\work\protobuf\protobuf(liuzhen)\protobuf_net_for_unity\ProtoGen>Release\protogen.exe
protobuf-net:protogen - code generator for .proto
usage: protogen -i:{infile2} [-i:{infile2}] [-o:{outfile}] [-t:{template}] [-p:{prop}[=value]] [-q] [-d]

-i: Input file(s); proto definitions, either as text or pre-compiled binary (via protoc)
-o: Output file; if none specified, writes to stdout
-t: Template to use; defaults to csharp
-p: Property for the template; value defaults to true; use -p:help to view available options
-q: Quiet; suppresses header
-d: Include all dependencies of the input files in the set so the set is self-contained.
-ns: Default namespace; used in code generation when no package is specified

Examples:

protogen -i:input.proto -o:output.cs
protogen -i:input.proto -o:output.xml -t:xml
protogen -i:input.proto -o:output.cs -p:datacontract -q
protogen -i:input.proto -o:output.cs -p:observable=true


C:\D\work\protobuf\protobuf(liuzhen)\protobuf_net_for_unity\ProtoGen>cd Release

C:\D\work\protobuf\protobuf(liuzhen)\protobuf_net_for_unity\ProtoGen\Release>protogen.exe -p:help
protobuf-net:protogen - code generator for .proto

        CSharp template for protobuf-net.
        Options:
        General:
          "help" - this page
        Additional serializer support:
          "xml" - enable explicit xml support (XmlSerializer)
          "datacontract" - enable data-contract support (DataContractSerializer; requires .NET 3.0)
          "binary" - enable binary support (BinaryFormatter; not supported on Silverlight)
        Other:
          "protoRpc" - enable proto-rpc client
          "observable" - change notification (observer pattern) support
          "preObservable" - pre-change notification (observer pattern) support (requires .NET 3.5)
          "partialMethods" - provide partial methods for changes (requires C# 3.0)
          "detectMissing" - provide *Specified properties to indicate whether fields are present
          "lightFramework" - omit additional attributes not included in CF/Silverlight
          "asynchronous" - emit asynchronous methods for use with WCF
          "clientProxy" - emit asynchronous client proxy class
          "import" - additional namespaces to import (semicolon delimited)
          "fixCase" - change type/member names (types/properties become PascalCase; fields become camelCase)