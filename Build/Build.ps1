$version = "1.0.1.0"
$infoVersion = "1.0.1"

$baseDir  = resolve-path ..
$buildDir = "$baseDir\Build"
$sourceDir = "$baseDir\Src"
$toolsDir = "$baseDir\Tools"
$releaseDir = "$baseDir\Release"

$signAssemblies = $true
$signKeyPath = "C:\Untech.SharePoint.pfx"

$msbuild = "C:\Program Files (x86)\MSBuild\14.0\bin\amd64\MSBuild.exe";
$nuget = "$toolsDir\NuGet\NuGet.exe";


$builds = @(
    @{
        Name = "Untech.SharePoint"; 
        Packages=@("Untech.SharePoint.Common", "Untech.SharePoint.Client", "Untech.SharePoint.Server"); 
        Constants = "PUBLISH"; 
    }
    @{
        Name = "Untech.SharePoint.All"; 
        TestsName = "Untech.SharePoint.Common.Tests"; 
    }
);

function Update-AssemblyInfoFiles {
    param([string] $workingSourceDir, [string] $assemblyVersionNumber, [string] $fileVersionNumber, [string] $infoVersionNumber)

    $assemblyVersionPattern = 'AssemblyVersion\("[0-9]+(\.([0-9]+|\*)){1,3}"\)'
    $fileVersionPattern = 'AssemblyFileVersion\("[0-9]+(\.([0-9]+|\*)){1,3}"\)'
    $infoVersionPattern = 'AssemblyInformationalVersion\(".+?"\)'

    $assemblyVersion = 'AssemblyVersion("' + $assemblyVersionNumber + '")';
    $fileVersion = 'AssemblyFileVersion("' + $fileVersionNumber + '")';
    $infoVersion = 'AssemblyInformationalVersion("' + $infoVersionNumber + '")';
    
    Get-ChildItem -Path $workingSourceDir -r -filter AssemblyInfo.cs | %{
        $filename = $_.FullName
    
        (Get-Content $filename) | % {
            % {$_ -replace $assemblyVersionPattern, $assemblyVersion } |
            % {$_ -replace $fileVersionPattern, $fileVersion } |
            % {$_ -replace $infoVersionPattern, $infoVersion }
        } | Set-Content $filename -Encoding UTF8
    }
}

function Build-MSBuild($build)
{
    $name = $build.Name

    Write-Host
    Write-Host "Restoring $sourceDir\$name.sln" -ForegroundColor Green
    [Environment]::SetEnvironmentVariable("EnableNuGetPackageRestore", "true", "Process")
    # exec { .\Tools\NuGet\NuGet.exe update -self }
    & $nuget restore $sourceDir\$name.sln `
        -verbosity detailed `
        -source "https://www.nuget.org/api/v2;https://www.myget.org/F/nuget"
    

    $constants = Get-Constants $build.Constants $signAssemblies

    Write-Host
    Write-Host "Building $sourceDir\$name.sln" -ForegroundColor Green

    & $msbuild "/t:Clean;Rebuild" `
        /p:Configuration=Release `
        "/p:Platform=Any CPU" `
        /p:PlatformTarget=AnyCPU `
        /p:AssemblyOriginatorKeyFile=$signKeyPath `
        /p:SignAssembly=$signAssemblies `
        /p:TreatWarningsAsErrors=$treatWarningsAsErrors `
        /p:VisualStudioVersion=14.0 `
        /p:DefineConstants=`"$constants`" `
        $sourceDir\$name.sln
    


    $build.Packages | %{
        Write-Host
        Write-Host "Packing $_" -ForegroundColor Green

        & $nuget pack $sourceDir\$_\$_.csproj `
            -IncludeReferencedProjects `
            -Prop Configuration=Release `
            -OutputDirectory $releaseDir
    }
}

function Get-Constants($constants, $includeSigned)
{
  $signed = if ($includeSigned) { ";SIGNED" }

  return "$constants$signed"
}

Update-AssemblyInfoFiles $sourceDir $version $version $infoVersion
Build-MSBuild $builds[0]