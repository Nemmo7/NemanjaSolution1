cd /

cd "C:\NemanjaTest1\bin\Debug"

@echo off

set max=.set count=.

echo starting test execution

echo =======================

"C:\Program Files (x86)\Microsoft Visual Studio\2019\Community\Common7\IDE\MSTest.exe" /testcontainer:googlesearch.orderedtest

echo all done

pause

@exit

