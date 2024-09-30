# Set the paths to search for
$foldersToDelete = @("logs", "bin", "obj", ".vs", ".idea")

# Function to delete folders
function Delete-Folders {
    param (
        [string[]]$folderNames
    )

    foreach ($folderName in $folderNames) {
        Write-Host "Searching and deleting '$folderName' folders..."

        # Search for directories recursively and delete them
        Get-ChildItem -Path . -Recurse -Directory -Force |
        Where-Object { $_.Name -in $folderNames } |
        ForEach-Object {
            try {
                Remove-Item -Path $_.FullName -Recurse -Force -ErrorAction Stop
                Write-Host "Deleted folder: $($_.FullName)" -ForegroundColor Green
            } catch {
                Write-Host "Failed to delete folder: $($_.FullName). Error: $_" -ForegroundColor Red
            }
        }
    }
}

# Call the function
Delete-Folders -folderNames $foldersToDelete
