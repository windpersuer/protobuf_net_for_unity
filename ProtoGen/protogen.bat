::Release\protogen.exe -i:input\test_msg.proto -o:output\test_msg.cs -ns:Client.Metadata
::Release\protogen.exe -i:input\test_msg.proto -o:output\test_msg.cs -ns:Client.Metadata -p:import="Client"
::pause

::路径
set SOURCE_PATH=.\input
set TARGET_PATH=.\output
set PROTOGEN_PATH=.\Release\protogen.exe

::删除之前创建的文件
del %TARGET_PATH%\*.* /f /s /q
echo "Start"

for /f "delims=" %%i in ('dir /b "%SOURCE_PATH%\*.proto"') do (
    echo "Transfer %%i to %%~ni.cs"
    %PROTOGEN_PATH% -i:%SOURCE_PATH%\%%i -o:%TARGET_PATH%\%%~ni.cs -ns:Client.ProtoBuf
)

echo "End"
pause