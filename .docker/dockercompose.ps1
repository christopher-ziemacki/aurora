param([string]$configuration="debug", [switch]$build)

$configuration = $configuration.ToLower();

$dockerComposeParameters = ""

if($build) {
    $dockerComposeParameters += "--build";
}

if($configuration -eq "debug") {
    docker-compose -p aurora -f .docker\dockercompose.debug.yml up $dockerComposeParameters
}
elseif ($configuration -eq "watch") {
    docker-compose -p aurora -f .docker\dockercompose.watch.yml up $dockerComposeParameters
}
else { 
    Write-Host "Configuration '$configuration' is not known"
}