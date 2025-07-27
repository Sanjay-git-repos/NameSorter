# NameSorter

A simple console app that sorts names by last name, then given names.

## Requirements

- [.NET 6 SDK](https://dotnet.microsoft.com/download/dotnet/6.0) or later  
- Visual Studio 2022 (optional, for development)

## Running During Development

You can run the app directly from source using the .NET CLI:

1. Place your input file `unsorted-names-list.txt` in the solution root folder.
2. Run this command from the solution root folder:

   dotnet run --project NameSorter -- ./unsorted-names-list.txt

This will:
- Print the sorted names to the console  
- Write the sorted names to `sorted-names-list.txt` in the working directory

## Publishing as a Standalone Executable

To run the app as: name-sorter ./unsorted-names-list.txt

Option 1 – Manually via .NET CLI:

1. Open a terminal in the solution root folder.
2. Run the publish command:
   dotnet publish NameSorter/NameSorter.csproj -c Release -r win-x64 --self-contained true -p:PublishSingleFile=true -p:UseAppHost=true -o publish
3. Rename the executable:
   rename publish\NameSorter.exe name-sorter.exe
4. Copy your input file into the `publish` folder:
   copy unsorted-names-list.txt publish\
5. Run the app from the `publish` folder:
   cd publish
   .\name-sorter.exe ./unsorted-names-list.txt

This will:
- Print the sorted names to the console  
- Create `sorted-names-list.txt` in the `publish` folder

Option 2 – With Script (Recommended for Windows):

1. Double-click on provided `publish-run-name-sorter.bat` script from the solution root folder.

This will:
- Clean and re-publish the app  
- Rename the output to `name-sorter.exe`  
- Copy `unsorted-names-list.txt`  
- Run the app automatically

## Notes
- Change `win-x64` to your target runtime as needed (e.g., `linux-x64`, `osx-x64`).  
- You can add the `publish` folder to your system PATH to run `name-sorter` from anywhere.