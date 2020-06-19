# Physics

## Character

The object that represents the in game character uses Rigidbody 2D component which gives the character a particular mass and enables easy use of gravity.
It allowed us to make a fairly intuitive for gamers and exciting jumping system. 

Properties of the characters Rigidbody 2D
Body Type: Dynamic
Use Auto Mass: No
Mass: 1
Linear Drag: 0
Angular Drag: 0
Gravity Scale: 7.4
Collision Detection: Discrete
Sleeping Mode: Start Awake
Interpolate: None

Because the games world is built in a specific why we are not using continous collision detection. Discrete way of doing that is good enough.

Character also uses Edge Collider 2D that allows the player to stand on ground or hit the ceiling and prevents walking through walls.

## Environment and world in the game

All objects in the game that the player may interact with have their own colliders which are adjusted to the shapes of mentioned objects. 
Environment (walls, ceilings and floors) was created by using a tilemap system. The Tilemap has own Tilemap Collider 2D component.
Obstacles have their own colliders that are used as triggers. When a players body touches an obstacle, the obstacles collider triggers an event in the games code (mostly players death).

## Glue

## Ice

# Particle effects

## Blood

## Smoke
