set Nuget=%1
set Version=%2
set StartDir=%CD%

cd %Nuget%
dotnet nuget push "StartDir\%Nuget%\bin\Debug\%Nuget%.%Version%.nupkg" --source "github"
cd %StartDir%