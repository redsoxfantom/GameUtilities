[![Build Status](http://ec2-52-0-23-21.compute-1.amazonaws.com:8080/buildStatus/icon?job=GameUtilities)](http://ec2-52-0-23-21.compute-1.amazonaws.com:8080/job/GameUtilities/)

GameUtilities
====
A simple game engine developed to learn design pattern principles. Why make a game engine? Because I don't want to die of boredom making something else.  
This should not be used to make an actual game as I'm not putting any particular effort into efficiency, only maintainability. Hopefully someone can use this as a learning tool, or a horrible warning. Not sure which yet.

Structure
----
GameUtilities is based off a simple component-based architecture. A 'Level' is defined as a World object, which acts as a container for 'Entities', which make up everything in the world. Entities serve as containers for 'Components', which define all behaviors an Entity can have.  
Eventually, Services will be added as well. Services encapsulate core functions of the engine (i.e, the filesystem, sound card, etc.) and can handle requests to perform an action.

TODO:  
* Add a service that handles input from a keyboard and mouse  
* Long term: Add ability to define simple 2D GUI overlays for buttons, HUD, etc.
