::Release\protogen.exe -i:input\test_msg.proto -o:output\test_msg.cs -ns:Client.Metadata -p:import="Client"
::-ns是当前文件的命名空间，可以通过.proto当中的package来完成；
::-p:import是当前文件引用的别的命名空间; 
::.proto当中的import是引用了其他文件/类才需要的。
::pause

::路径
set SOURCE_PATH=.\input
set TARGET_PATH=.\output\csharp
set PROTOGEN_PATH=.\Release\protogen.exe

::删除之前创建的文件
del %TARGET_PATH%\*.* /f /s /q
echo "------Start-----"

::for /f "delims=" %%i in ('dir /b "%SOURCE_PATH%\*.proto"') do (
::    echo "Transfer %%i to %%~ni.cs"
::    %PROTOGEN_PATH% -i:%SOURCE_PATH%\%%i -o:%TARGET_PATH%\%%~ni.cs
::)

::dir /b如果使用了/s的话，则直接打印出完整路径了，所以导出时就不再需要进行路径拼接了
for /f "delims=" %%i in ('dir /b /s "%SOURCE_PATH%\*.proto"') do (
    echo "Transfer %%i to %%~ni.cs"
    %PROTOGEN_PATH% -i:%%i -o:%TARGET_PATH%\%%~ni.cs
)

echo "-----End-----"
pause