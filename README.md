# Gameloft Test Task - Technical Game Designer

## Project Overview
This project is a Unity scene assembled as a technical game design test assignment.

Implemented features:
- controllable player character
- interactive farming plots with staged crop growth
- collectible objects
- NPC animals with wandering behavior and interaction
- camera controls, physics interactions, animations, and skybox

## Unity Version
`2022.3.62f3`

## Setup Instructions
1. Clone the repository
2. Open Unity Hub
3. Add the project folder
4. Open the project with Unity `2022.3.62f3`
5. Open scene: `Assets/_Project/Scenes/EnchantedGarden.unity`
6. Press Play

## Controls
- `WASD` - Move
- `Left Shift` - Run
- `Right Mouse Button` + Mouse - Rotate camera (yaw/pitch)
- `Mouse Wheel` - Zoom in/out
- `E` - Interact

## Gameplay Features
- planting and harvesting crops with staged visual growth (`seedling -> growing -> ready`)
- crop growth timer shown in the interaction prompt while growing
- collectibles (trigger-based and interaction-based)
- animal wandering and pet interaction prompt

## Notes
- If NPCs are not moving, find the `NavMesh Surface` object in the scene and click `Bake` in its `NavMeshSurface` component.
