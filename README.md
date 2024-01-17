# SavingObjects

An example of saving and loading game objects

## Instructions

- Left click on the ground to change the ground type
- Right click on the screen to drop a new block
- Click Clear to reset the scene
- Click Save to save the scene
- Click Load to load it

## How it works

The state of the scene is converted to `LevelData` by the `CreateLevelData` function, which is then converted to a JSON format string by the `JsonUtility` library. That string is saved to a file in your User folder. To load the level data, the process is reversed. First, the JSON string is loaded from the file in your User folder. Then, the string is used to create the `LevelData` structure. This is done automatically by the `JsonUtility` library. Finally the level data is used to re-create the state of the scene by the `LoadFromLevelData` function.
