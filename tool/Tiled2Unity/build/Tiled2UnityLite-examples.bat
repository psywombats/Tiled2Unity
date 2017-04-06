@echo off
pushd %~dp0
rem This is hardcoded to expect the Tiled2Unity test project at location ..\..\..\

set ObjectTypeXml=""
rem set ObjectTypeXml="..\..\..\Tiled2UnityTest\Assets\Maps\objecttypes.xml"
set TiledTmx="..\..\..\Tiled2UnityTest\Assets\Maps\Test.tmx"
set Tiled2UnityDir="..\..\..\Tiled2UnityTest\Assets\Tiled2Unity"

cscs Tiled2UnityLite.cs --help

echo Command: cscs Tiled2UnityLite.cs --object-type-xml=%ObjectTypeXml% %TiledTmx% %Tiled2UnityDir%
cscs Tiled2UnityLite.cs --object-type-xml=%ObjectTypeXml% %TiledTmx% %Tiled2UnityDir%

popd