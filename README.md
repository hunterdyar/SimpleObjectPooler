# Simple Object Pooler
An example project demonstrating two object pooling systems. 

The code started with the twin stick example from [this example project](https://github.com/hunterdyar/UnitySimpleCharacterControllers), included.

The first example pooler is in the TwinStickWeaponManager.cs class.
The second, a more "generic" solution is simply called GenericObjectPooler.cs.

## Background
In Unity, one often needs to create and destroy game objects of the same type frequently. Bullets are the canonical example, but I have used object poolers to help with UI elements, level generation scripts, and more.

It's more performative to enable a GameObject that already exists in the games memory, than it is to create one. If one knows it's likely to have to create an object and destroy it frequently (like bullets), one could use an object pool.

Basically, instead of destroying the bullet, we disable it and add it to a list. Then instead of creating one, we grab one from that list and enable it. 
