Team Members: 
-Tony D'Alesandro
-Taylor Liu
-Jose Berrios 
-Keit Vu

Program Controls: 
	Z&B: Tells link to attack with the item in hand
	WASD + Arrowkeys: Move the link (can only move one direction at a time. You cannot override movement)
        Escape: Goes to the inventory  and pause game
        R: Reset the whole game
        M: Mutes sound 
	Q: Quit game
	E: Damage link
	Mouse right-click: goes to the previous room (does not do room transition)
	Mouse left-click: goes to the next room ( does not do room transition)
	Left shift: toggle hit box on all entities Debug mode (cannot take damage in debug mode)
        When having the map in inventory and clicking a room it teleport you to the room.

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
	
Have not implemented:
    -possibly pause state (if not the same as the inventory screen)
    
Bug:
    -when in inventory and press m plays a split second of low health
