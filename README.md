# GDIM32-Final
## Check-In
### Group Devlog

We ended up using Gizmos to help with debugging the Physics Object Pick Up. There was a bug where the player just wasn't able to pick any physics object up, even though the code was sound and should have been working correctly. We ended up using a Line Gizmo to draw out the Raycast that was used in the Class, as since the code was sound, it must have been an issue outside of the code. The gizmo revealed that the Ray was incredibly short and simply didn't reach far enough to pick objects up. Without the Gizmo, it would have been significantly harder to diagnose the problem with the Physics Object Pick Up, and the continued trial and error would have been a massive waste of time. 

### Individual Devlogs
### Sjofn Quist
I created the ObjectPickUp and RatMovement Classes for the project. The Trello and Proposal were especially helpful as I was able to use the Proposal as a jumping off point for my scripts and the Trello for organization. I did a decent chunk of my work at home, so having Trello available to check which tasks were in progress or which ones Sean had already taken was super convenient! There were some small architecture changes from our proposal, but they were a result of debugging for the most part. Certain parts of the proposal didn't end up working as I envisioned, and it took some changes to get everything functioning properly.

For future games, I will definitely go more in depth with my proposal/plan for each mechanic within them. Having the Proposal readily available for me to reference helped prevent me become stuck on how to approach certain tasks or roadblocks as I worked.

### Sean Elston
For this stage of the project, I contributed the movement script as well as the script handling the camera movement tied to the players mouse movement. Additionaly I added in the first bit of logic for tracking where objects are in a scene in order to detect when a a player is placing or moving an object in the correct area to trigger the quests that will be built later down the line. 

The movement and mouse look at scripts were fairly simple, both primarily have their code written in the update method with no additional methods being written as it was simple enough to add that code into the update method (However if more code is added the update methods later I may write an individual method for both movement and mouse look at scripts) Movent script takes a float from player input and adds those together, then multiplying that final vector3 by a variable called movespeed, which is exposed in the editor to make adjusting player movement easier, and then being multiplied by time.Deltatime. Similar type of code for the mouse script just geting a float from the x and y Input from the players mouse, instead of applying a transform applying a rotation to the camera as well as a rotation to the player collider so the whole player moves when the mouse turns. 

The Quest Zone Script was more complicated than the previous two, the script is a component of objects that include collider triggers that tell the game when an object is placed inside that zone. It utelizes the OnTriggerEnter code, and then runs an if statement to check to see if the item in the trigger has a specific tag, if so it fires an event to the locator in the scene, which then triggers the UI to update in the UI script attatched to the canvas gameObject, I also wrote a method inside the locator called QuestObjectScored, that the QuestZone script will call when it needs to trigger the event that updates the UI for when a player has moved and object in the scene.

Finally I did the first pass of greybox blockout in the scene getting our level to a state where we can visualize how we are going to be playing in the scene. 

I think our proposal overall was detailed enough as we were able to get a good start planning out what needed to be done based on that proposal. Additionaly trello has been pretty useful for organizing and planning what we need to do. So when I finish a task I can immdeatly move on to the next thing on our list. 

## Final Submission
### Group Devlog
Put your group Devlog here.


### Team Member Name 1
Put your individual final Devlog here.
### Team Member Name 2
Put your individual final Devlog here.
### Team Member Name 3
Put your individual final Devlog here.

## Open-Source Assets
Cite any open-source assets here. Put them in a LIST, and use correctly formatted LINKS.
