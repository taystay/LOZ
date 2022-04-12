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
        P: pause state
        |: Debug mode

Tools used:
    -paint.net
        -used for sprite frame and calculating the box of each frame
    -Asperite
        -used on the enemies sprite to make a personal spritesheet of enemies
        and cut unneccessary enemies from the spritesheet
        -Audioacity
            -used for audio files

Citation:
    -for SpriteBatch.Begin(...)
        -the paramter idea was from:
        https://stackoverflow.com/questions/34626732/seeing-wrap-texture-when-using-clamp-mode-in-monogame-pictures-incl
        https://csharp.hotexamples.com/examples/Microsoft.Xna.Framework.Graphics/SpriteBatch/Begin/php-spritebatch-begin-method-examples.html
        -https://zeldauniverse.net/media/music/the-legend-of-zelda-original-soundtrack/  (background music)
        -https://www.noproblo.dayjo.org/ZeldaSounds/ (sounds)
        -https://www.sounds-resource.com/nes/legendofzelda/   (sounds)
        -https://docs.microsoft.com/en-us/previous-versions/windows/xna/bb195053(v=xnagamestudio.42)  (sound effect)
        -https://docs.microsoft.com/en-us/previous-versions/windows/xna/dd940203(v=xnagamestudio.42)  (sound effect instance)
        
    
Bug:
    -When resetting game the inventory does not reset

