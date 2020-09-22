# Physics

## Character

The object that represents the in game character uses Rigidbody 2D component which gives the character a particular mass and enables easy use of gravity.
It allowed us to make a fairly intuitive for gamers and exciting jumping system. 

Properties of the characters Rigidbody 2D:
* Body Type: Dynamic
* Use Auto Mass: No
* Mass: 1
* Linear Drag: 0
* Angular Drag: 0
* Gravity Scale: 7.4
* Collision Detection: Discrete
* Sleeping Mode: Start Awake
* Interpolate: None

Because the games world is built in a specific why we are not using continous collision detection. Discrete way of doing that is good enough.

Character also uses Edge Collider 2D that allows the player to stand on ground or hit the ceiling and prevents walking through walls.

## Environment and obstacle objects

All objects in the game that the player may interact with have their own colliders which are adjusted to the shapes of mentioned objects. 
Environment (walls, ceilings and floors) was created by using a tilemap system. The Tilemap has own Tilemap Collider 2D component.
Obstacles have their own colliders that are used as triggers. When a players body touches an obstacle, the obstacles collider triggers an event in the games code (mostly players death).

## Terrain obstacles

There are 2 terrain obstacles implemented in a form of "ice" and "glue". Ice gradualy decreases players velocity and glue reduces players speed and makes jumping harder by reducing the force of the jump. 

# Particle effects

## Blood

When a collision between a player and a lethal obstacle happens a *splat* particle effect is made. In the location where the mentioned collision happened, a burst of red particles is created. Then the aforementioned particles fall on the enviroment and background where they randomly draw a sprite representing blood, randomly scale and rotate them. The blood stays till players finishes the level.

## Smoke

At the start of every level a board with a text acompanied by particle systems on the sides. The particle systems are meant to represent smoke coming out of a heavy machinery. 

The particle system properties: 
* Duration: 5.00
* Looping: Yes
* Prewarm: No
* Start Delay: 0
* Start Lifetime: 1-3
* Start Speed: 8
* Start Size: 0.5-3
* Start Rotation: 0
* Gravity Modifier: 0
* Emitter Velocity: Transform
* Max Particles: 1000
