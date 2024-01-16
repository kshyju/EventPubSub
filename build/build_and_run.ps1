# Set the paths to your project directories
$publisherProjectPath = "..\src\SimplePublisher"
$subscriberProjectPath = "..\src\SimpleSubscriber"

# Set the output directory
$outputDirectory = "..\out"

# Build and publish Foo project
dotnet publish $publisherProjectPath -c Release -o $outputDirectory\SimplePublisher

# Build and publish Bar project
dotnet publish $subscriberProjectPath -c Release -o $outputDirectory\SimpleSubscriber

# Run publisher and subcriber
$fooExecutable = Join-Path $outputDirectory "SimplePublisher\SimplePublisher.exe"
$barExecutable = Join-Path $outputDirectory "SimpleSubscriber\SimpleSubscriber.exe"

Start-Process $fooExecutable
Start-Process $barExecutable
