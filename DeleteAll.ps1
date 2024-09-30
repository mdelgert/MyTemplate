# Get the current directory where the script is running from
$currentDirectory = Get-Location

# Function to delete all contents inside the current directory
function Delete-AllContents {
    param (
        [string]$directoryPath
    )

    # Get all items (files and folders) in the directory
    Get-ChildItem -Path $directoryPath -Force |
    ForEach-Object {
        try {
            # Attempt to delete each item
            Remove-Item -Path $_.FullName -Recurse -Force -ErrorAction Stop
            Write-Host "Deleted: $($_.FullName)" -ForegroundColor Green
        } catch {
            Write-Host "Failed to delete: $($_.FullName). Error: $_" -ForegroundColor Red
        }
    }
}

# Warning message and confirmation prompt
$warningMessage = "WARNING: You are about to delete ALL contents in the folder: $currentDirectory. This action cannot be undone."
Write-Host $warningMessage -ForegroundColor Yellow

# Prompt the user for confirmation
$confirmation = Read-Host "Are you sure you want to proceed? Type 'YES' to confirm"

if ($confirmation -eq "YES") {
    # Call the function to delete everything inside the current directory
    Delete-AllContents -directoryPath $currentDirectory
    Write-Host "All contents inside $currentDirectory have been deleted." -ForegroundColor Green
} else {
    Write-Host "Operation canceled. No files were deleted." -ForegroundColor Red
}
