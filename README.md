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
    E: Heal link
    Mouse right-click: goes to the previous room (does not do room transition)
    Mouse left-click: goes to the next room ( does not do room transition)
    Left shift: toggle hit box on all entities Debug mode (cannot take damage in debug mode)
        When having the map in inventory and clicking a room it teleport you to the room.
    P: Pause state
    |: Debug mode
    F+G(hold both) : cheat codes to add bombs
    W+U (hold both): cheat codes to add rupees
    L+O (hold both): cheat code to add portal gun
    H: Hardcore mode

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
        -https://csharp.hotexamples.com/examples/Microsoft.Xna.Framework.Graphics/SpriteBatch/Begin/php-spritebatch-begin-method-examples.html
        -https://stackoverflow.com/questions/1276763/how-do-i-get-the-list-of-keys-in-a-dictionary
        -https://stackoverflow.com/questions/34626732/seeing-wrap-texture-when-using-clamp-mode-in-monogame-pictures-incl
        -https://stackoverflow.com/questions/1082917/mod-of-negative-number-is-melting-my-brain
        -https://csharp.hotexamples.com/examples/Microsoft.Xna.Framework.Graphics/SpriteBatch/Begin/php-spritebatch-begin-method-examples.html
        -http://rbwhitaker.wikidot.com/monogame-texture-atlases-2 
        -https://stackoverflow.com/questions/31104248/monogame-rotating-a-sprite
        -https://stackoverflow.com/questions/1276763/how-do-i-get-the-list-of-keys-in-a-dictionary
       - https://www.c-sharpcorner.com/article/loop-through-enum-values-in-c-sharp/
        -https://docs.microsoft.com/en-us/dotnet/api/system.enum.getnames?view=net-6.0
        -https://docs.microsoft.com/en-US/troubleshoot/developer/visualstudio/csharp/general/file-io-operation
        -https://docs.monogame.net/api/Microsoft.Xna.Framework.Rectangle.html#Microsoft_Xna_Framework_Rectangle_Contains_System_Single_System_Single_
        -https://stackoverflow.com/questions/41317291/setting-the-magnitude-of-a-2d-vector#41321162
        -https://docs.microsoft.com/en-us/dotnet/api/system.numerics.vector2.normalize?view=net-6.0
        -https://community.monogame.net/t/get-the-actual-screen-width-and-height-on-windows-10-c-monogame/10006
        -https://stackoverflow.com/questions/6246074/mono-c-sharp-get-application-path
        -https://docs.microsoft.com/en-us/dotnet/api/system.string.remove?view=net-6.0
        -https://community.monogame.net/t/how-to-make-lightsources-torch-fire-campfire-etc-in-dark-area-2d-pixel-game/8058/20
        -https://zeldauniverse.net/media/music/the-legend-of-zelda-original-soundtrack/  (background music)
        -https://www.noproblo.dayjo.org/ZeldaSounds/ (sounds)
        -https://www.sounds-resource.com/nes/legendofzelda/   (sounds)
        -https://docs.microsoft.com/en-us/previous-versions/windows/xna/bb195053(v=xnagamestudio.42)  (sound effect)
        -https://docs.microsoft.com/en-us/previous-versions/windows/xna/dd940203(v=xnagamestudio.42)  (sound effect instance)
        
        
BUGS: None

Refactor:
The code was refactor using lambda operator to reduce lines of code.
