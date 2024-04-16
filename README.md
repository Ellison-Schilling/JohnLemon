# John Lemon's Haunted Jaunt - Modified
 Assignment 2 for CS410

 Contributors: Alex Passanante, Ellison Schilling

* Dot product [contributed by Alex Passanante]: Added a mechanic so the MC looks towards the mouse during play. This Uses a dot product to convert a vector derived from the mouse position and the center of the screen 
to an angle based off of an identity vector based on the worlds y rotation. More is written in the PlayerMovement script.

* Particle Trigger [contributed by Ellison Schilling]: Added a particle system and script that trigger when any of the five corridor rugs are stepped on by the player. This is done by the use of collider boxes on each of the carpets that trigger when the user's collider comes into range of contact and turn on the particle system. The effect is the appearence of dust coming up out of the carpets when they are steppd on by the user.

* Sound Effect/Trigger [contributed by Russell Soohoo]: Added a new audio clip, of footsteps on a rug, that triggers when any of the five corridor rugs are walked on by the player. This uses collider boxes on each of the carpets that trigger when the user's collider comes into contact with a rug. When a player walks on a rug, it sounds as if the player is actually walking on a rug. When the player is walking on the floor, it plays the original footsteps audio clip.
