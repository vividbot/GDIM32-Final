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
### Sean Elston
#### Prompt 1
For this portion of the project I have contributed creating and completing the quest logic within the game. As well as the UI blockout showing the player which quest is active, along with how many quests they have completed, and if the game is over. Additionally I created the logic to both end and restart the game whenever the player completes all of the required quests. I worked on and created a few diffrent classes during this stretch of the project. I worked on making the QuestManager class fully functional to Instantiate and start quests, and then I created the "Quest" parent class, which each individual quest inherits from. The parent class outlines some basic behaviours (IE subscribing to the Locator to receive score events from the QuestZone class) additionally it outlines basic scoring structure, and basic UI spawning structure so that each quest will spawn some sort of UI when it is started. I also created children of the Quest class for each quest, these have overriden methods from the base class based on what the specifc needs are for the quest but stay relativley similar to the parent class.
#### Prompt 2
I think that I often underestimated how long certain things would take as well as overestimated certain tasks depending on the perceived complexity of each task. I think that as I code more and more I am starting to get a better understanding of how certain architectures will be constructed for games and have a better understanding of what to start with. A lot of the time I start with an idea on how ot structure somthing but as I start building it seems becomes more complicated than I initially estimated, mostly due to running into new logic challenges I hadnt anticipated when I was starting the task. On the other hand certain tasks were easier to complete than I had initially thought, for example I was expecting to spend a long time creating the list function to list which tasks had been completed, and thought it was a fairly complicated concept to create. But after starting I realized it was far easier than it seemed after consulting the unity documentation on lists and how to add those lists to text. I think that my estimates overall were fairly close to being accurate, if not having some leeway in either direction of taking too long or finishing early on certain tasks. 

I think now that I have more experience building certain pieces of code I have a better idea of how long certain things will take, writing out how a class might function or using pseudo code is also helpful for me understanding how long somthing might take as it helps me realize what parts will need to be put together in order to get somthing to work. 

 
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
