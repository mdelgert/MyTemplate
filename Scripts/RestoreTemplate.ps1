# Define paths
$basePath = ".."  # This assumes the script is in the "Scripts" folder
$filesToRestore = @(
    "$basePath\MyTemplate.sln",
    "$basePath\MyTemplate.ConsoleApp\MyTemplate.ConsoleApp.csproj",
    "$basePath\MyTemplate.Shared\MyTemplate.Shared.csproj",
    "$basePath\MyTemplate.TestProject\MyTemplate.TestProject.csproj"
)

# Function to replace text in a file
function Replace-TextInFile {
    param (
        [string]$filePath,
        [string]$searchText,
        [string]$replaceText
    )

    # Read the file content
    $fileContent = Get-Content -Path $filePath -Raw

    # Replace the text
    $fileContent = $fileContent -replace [regex]::Escape($searchText), $replaceText

    # Save the updated content back to the file
    Set-Content -Path $filePath -Value $fileContent
}

# Replacement mappings
$replacements = @{
    '$safeprojectname$' = "MyTemplate"
}

# Loop through each file and apply the replacements
foreach ($file in $filesToRestore) {
    Write-Host "Processing file: $file"
    
    foreach ($searchText in $replacements.Keys) {
        $replaceText = $replacements[$searchText]
        Replace-TextInFile -filePath $file -searchText $searchText -replaceText $replaceText
        Write-Host "Replaced '$searchText' with '$replaceText' in $file"
    }
}

Write-Host "Restoration to original files completed."
