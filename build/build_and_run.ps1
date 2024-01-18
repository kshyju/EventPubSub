# Set the paths to your project directories
$publisherProjectPath = "..\src\SimplePublisher"
$subscriberProjectPath = "..\src\SimpleSubscriber"

# Set the output directory
$outputDirectory = "..\out"

Write-Output "    Cleaning the solution..."
dotnet clean ".\..\EventPubSub.sln"

Write-Output "    Publishing SimplePublisher project..."
dotnet publish $publisherProjectPath -c Release -r win-x64 -o $outputDirectory\SimplePublisher

Write-Output "    Publishing SimpleSubscriber project..."
dotnet publish $subscriberProjectPath -c Release -o $outputDirectory\SimpleSubscriber

# Run publisher and subcriber

#Write-Output "Running SimplePublisher and SimpleSubscriber executables"
$fooExecutable = Join-Path $outputDirectory "SimplePublisher\SimplePublisher.exe"
$barExecutable = Join-Path $outputDirectory "SimpleSubscriber\SimpleSubscriber.exe"

Start-Process $fooExecutable
Start-Process $barExecutable
