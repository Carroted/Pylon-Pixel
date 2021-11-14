Cutscene Toolkit for Unity
Version 1.0.0  |  By Carroted

Licensed under MIT License. A copy of the license can be found in this folder.

This is a useful solution for cutscenes in Unity!
This works with both 3D and 2D games!

You will find several scripts in here:
     · CutsceneManager.cs
	· This is a script which can start a cutscene, and decides wether control from the player is taken away, if the camera position is animated, and other things. A lot of variables are tooltipped, so you can hover over stuff to get an explanation.
     · TaggedObjectSensor.cs
	· This is a very useful script, for cutscenes, yes, but can also be used for much more. This can trigger events when an object of a certain tags enters it's trigger collider(s), when it stays, and/or when it exits. You can add events to it like you would on things like UI buttons, or event listeners. You have an array of tags you can set for what objects are accepted to trigger the events. An example of a usage is starting a cutscene when a player enters a certain zone.
     · CutsceneDialog.cs
	· Unless you fork or contribute to Pylon Pixel, you will most likely have to modify almost all of this script. For this reason, and to prevent errors from occuring when you import this in other projects, in releases of Cutscene Toolkit for Unity, the code for the Pylon Pixel implementation is commented out. CutsceneDialog is only useful for games with dialog, and should be modified to work with whatever system you use.

You will also find prefabs in the Prefabs folder:
     · Cutscene Manager
        · Example Cutscene Manager object
     · Tagged Object Sensor
	· Tagged Object Sensor ready to drag and drop. This is ready for 3D games.
     · Tagged Object Sensor 2D
	· Tagged Object Sensor ready to drag and drop. This is ready for 2D games.

In the Gizmos folder you will find all the icons used for the scripts and prefabs, in PNG and SVG format. These are taken from https://fonts.google.com/icons under the Apache License 2.0 (https://www.apache.org/licenses/LICENSE-2.0.html).

Created by Alex_Sour, released under Carroted.