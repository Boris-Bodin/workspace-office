# Workspace Addon for Microsoft Word

This project is an addon for Microsoft Word that provides a workspace functionality. It was developed in C# and uses the Microsoft Office Tools for Word for integration with Microsoft Word.

## Features

- Custom Task Pane: The addon includes a custom task pane named "Workspace". This task pane can be toggled on and off within Word.
- Document Management: The addon provides functionality for opening and creating new documents within the workspace.

## Code Structure

The project consists of several C# files:

- `ThisAddIn.cs`: This is the main entry point for the addon. It handles the startup and shutdown of the addon, as well as document opening and creation.
- `WorkspaceService.cs`: This file contains the service for managing the workspace. It includes methods for initializing the workspace, updating the collection of documents, and handling file and folder operations.
- `WordSaveHandler.cs`: This file contains a handler for saving Word documents. It includes events that are triggered after a document is saved.

## Usage

To use the addon, open Microsoft Word. The "Workspace" task pane should be visible. If not, it can be toggled on and off.

## Note

This project is old, and it is not guaranteed to work with current versions of Microsoft Word. It is provided for archival purposes only.