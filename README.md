# GDIM32-Final
## Check-In 1
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

## Check-In 2

### Group Devlog
#### Prompt 1
So far we are fairly far along the way of our planned features, At the momment NPC's, The first two quests, and the Physics system are fully functional. This means we only need to add the remaining quests and then work on implimenting the visual parts of the game. The rest of the prioritization is going to be on finishing the remaining quests, which should not be too hard since the quests are coded in a manner that allow for the us to create them without having to re write much code (Using Inheritance). Once the quests are completley done much of the time is going to be spent on visual polish and any remaining features we feel will make the gameplay feel better, tuning the scripts, etc. Our focus has been on building our scripts and acrchitecture to be scaleable to a degree so that if we need to add more things we dont have to move around a lot of parts of our game (Decoupling our code) The biggest change going forward on how we use our time is definetly spending a bit more time working on the artistic and visual aspects of the game. 
#### Prompt 2
In our game, we're using ScriptableObjects for the NPC dialog. Using a SO that holds an array of strings named "NPCDialog", we can enter each line of dialog the NPC says, which is then used in the class Q_NPCInteract, which then cycles through the lines of dialog given to the NPC from the SO after the player presses "E" within a certain range of the player. This makes it very easy to organize which NPC will say what, as well as remain easily editable without needing to hunt down the NPC who's dialog you're trying to edit. Alongside this, this allows us to create basic dialog options for specific NPCS, such as NPCS that will always give the player a plunging task or NPCS that will always give the player a restocking task. This prevents us from needing to constantly rewrite dialog for NPCS or needing to come up with new uneccesary dialog for tasks that already have dialog associated with them

### Individual Devlogs
### Sjofn Quist
I wrote all of the NPC scripts, created the level design, and refactored some previous code regarding the Player Movement to switch it from using the Character Controller component to a rigidbody component as it was causing some bugs. Alongside this, I also tried to stay on top of bug fixes throughout the week and squashed a couple of them.

It takes me a while to finish a task, longer than I would generally like as I believe my ability to read code isn't all there yet. I generally struggle with some of my "code comprehension" and oftentimes I need to google things as I go along to remember where to put things and what specifically things do. I feel like the only real way to improve upon this skill is to simply code more and spend more time reading it, which is what I've been doing. Alongisde this project, I've been adding more things to my senior port project and contributing to some friend's projects just so I can sink more time into this skill, and I am seeing some improvement with my ability to actually understand what I'm reading. I have a habit of OVER-estimating how long tasks will take me, though, and at times I've found myself literally running out of things to do because I inadvertantly take "smaller" tasks that don't take me as long as I expected them to. I honestly do this with most subjects, and what I've found helps me the most is breaking tasks into a bunch of smaller tasks I /know/ won't take me very long, so i'm more comfortable taking multiple at a time and overall getting more done in my work time without floundering as I realize I finished my "main" task of the day.

### Sean Elston

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
