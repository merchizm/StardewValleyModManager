# Stardew Valley Mod Manager

A simple and user-friendly application to manage your Stardew Valley mods.

## Features

- Easily activate and deactivate mods without deleting them
- Launch Stardew Valley with SMAPI directly from the application
- Verify mod validity by checking for manifest.json files
- Access useful Stardew Valley modding resources
- Simple and intuitive interface

## Requirements

- .NET Framework 4.7.2 or higher
- Stardew Valley game with SMAPI installed
- Windows operating system

## Installation

1. Download the latest release from the [Releases](https://github.com/yourusername/StardewValleyModManager/releases) page
2. Extract the zip file to the game files location on your computer
3. Run `StardewValleyModManager.exe`

## Usage

### First Time Setup

1. When you first run the application, you'll need to set the path to your Stardew Valley game directory
2. Click on "Browse" and navigate to your Stardew Valley installation folder (where StardewModdingAPI.exe is located)
3. The application will create "Mods" and "DeactivatedMods" folders if they don't already exist

### Managing Mods

- **Activate a Mod**: Select a mod from the "Deactivated Mods" list and click "Activate"
- **Deactivate a Mod**: Select a mod from the "Active Mods" list and click "Deactivate"
- **Launch Game**: Click the "Launch Game" button to start Stardew Valley with your active mods

### Transferring Mods

To transfer mods from your computer to the game directory:
1. Download mod files from Nexus Mods or other sources
2. Extract the mod files if they are in a compressed format (zip, rar, etc.)
3. Place the extracted mod folder into the "Mods" folder in your Stardew Valley game directory
   - Typically located at `C:\Program Files (x86)\Steam\steamapps\common\Stardew Valley\Mods`
   - Or use the "Browse" function in the application to locate your game directory
4. The mod should appear in the "Active Mods" list when you refresh the application
5. If you want to temporarily disable a mod without deleting it, use the "Deactivate" button

### Resources

The application provides quick links to useful Stardew Valley modding resources:
- Stardew Valley Wiki
- Nexus Mods
- SMAPI Documentation
- Stardew Valley Forums
- Stardew Valley Discord

## Building from Source

1. Clone the repository
2. Open the solution in Visual Studio
3. Build the solution (Ctrl+Shift+B)
4. Run the application (F5)

## Contributing

Contributions are welcome! Please feel free to submit a Pull Request.

## License

This project is licensed under the MIT License - see the LICENSE file for details.

## Acknowledgments

- [Stardew Valley](https://www.stardewvalley.net/) by ConcernedApe
- [SMAPI](https://smapi.io/) - The Stardew Modding API
