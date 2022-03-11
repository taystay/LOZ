Team Members: 
-Tony D'Alesandro
-Taylor Liu
-Jose Berrios 
-Keit Vu

Program Controls: 
	Z&N: Tells link to attack
	WASD + Arrowkeys: Move the link
	Number keys (1234...): Create Link's item
	R: Reset the current room enemies
	Q: Quit game
	E: Damage link
	Mouse right-click: goes to the previous room
	Mouse left-click: goes to the next room
	Left shift: toggle hit box on all entities

Tools used:
	-paint.net
		-used for sprite frame and calculating the box of each frame
	-Asperite
		-used on the enemies sprite to make a personal spritesheet of enemies
		and cut unneccessary enemies from the spritesheet

Citation:
	-for SpriteBatch.Begin(...)
		-the paramter idea was from:
		https://stackoverflow.com/questions/34626732/seeing-wrap-texture-when-using-clamp-mode-in-monogame-pictures-incl
		https://csharp.hotexamples.com/examples/Microsoft.Xna.Framework.Graphics/SpriteBatch/Begin/php-spritebatch-begin-method-examples.html
	

Bugs:
	-Sometimes when link transitions from room to room the hitbox does not update and follow link. This allows him to walk outside of the room 
	(the room with the jellies starts the bug) and then it persist to the other rooms.

	-When going between room to room sometimes the rooms skip rooms

`	-When transitioning from room to room link sometimes is permanently
