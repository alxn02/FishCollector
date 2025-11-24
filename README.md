# Fish Collector

## Overview
This is a Unity 2D game where the player controls a ship to collect fish in the order they are placed.  

- Left-click the ship to activate it  
- Right-click anywhere in the scene to spawn a fish  
- The ship moves automatically to collect fish in spawn order  

## Controls
- Left Mouse Button: Activate the ship  
- Right Mouse Button: Place a fish  

## Requirements
- Unity 2021.3 or later (2D project)  
- Rigidbody2D and BoxCollider2D on the Ship  
- BoxCollider2D (Trigger ON) on the Fish prefab  
- FishCollector script attached to Main Camera  

## Notes
The ship collects fish in spawn order and destroys them upon collision.
