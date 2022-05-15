[Unit 2 - Basic Gameplay](https://learn.unity.com/project/unit-2-basic-gameplay)  
- New Functionality
  - The player can move left and right based on the user’s left and right key presses
  - The player will not be able to leave the play area on either side
  - The player can press the Spacebar to launch a projectile prefab,
  - Projectile and Animals are removed from the scene if they leave the screen
  - The player can press the S to spawn an animal
  - Animal selection and spawn location are randomized
  - Camera projection (perspective/orthographic) selected
  - Animals spawn on a timed interval and walk down the screen
  - When animals get past the player, it triggers a “Game Over” message
  - If a projectile collides with an animal, both objects are removed

- New Concepts & Skills
  - Adjust object scale
  - If-statements
  - Greater/Less than operators
  - Create Prefabs
  - Override Prefabs
  - Test for Key presses
  - Instantiate objects
  - Destroy objects
  - Else-if statements
  - Spawn Manager
  - Arrays
  - Keycodes
  - Random generation
  - Local vs Global variables
  - Perspective vs Isometric projections
  - Create custom methods/functions
  - InvokeRepeating() to repeat code
  - Colliders and Triggers
  - Override functions
  - Log Debug messages to console

[Challenge 2 - Play Fetch](https://learn.unity.com/tutorial/challenge-2-play-fetch-with-random-values-and-arrays)  
- Make the balls spawn from the top of the screen
  - Hint - Click on the Spawn Manager object and look at the “Ball Prefabs” array
- Make the player spawn dogs
  - Hint - Click on the Player object and look at the “Dog Prefab” variable
- The balls should only be destroyed when coming into direct contact with a dog
  - Hint - Check out the box collider on the dog prefab
- Balls should be destroyed when they leave the bottom of the screen and dogs should be destroyed when they leave the left side of the screen
  - Hint - In the DestroyOutOfBounds script, double-check the lowerLimit and leftLimit variables, the greater than vs less than signs, and which position (x,y,z) is being tested
- Ball 1, 2, and 3 should be spawned randomly
  - Hint - In the SpawnRandomBall() method, you should declare a new random int index variable, then incorporate that variable into the Instantiate call
- Bonus - Make the spawn interval a random value between 3 seconds and 5 seconds
  - Hint - Set the spawnInterval value to a new random number between 3 and 5 seconds in the SpawnRandomBall method

[Bonus Features 2 - Share your Work](https://learn.unity.com/tutorial/bonus-features-2-share-your-work)  
- Easy: Vertical player movement
  - Look at how we are doing the left and right movement range.
- Medium: Aggressive animals
  - Look at how we are currently spawning animals and doing collisions.
- Hard: Game user interface
  - You will need to update the score and lives in the DetectCollisions script, and update the lives in the DestroyOutOfBounds script.
- Expert: Animal hunger bar
  - You will need to add a UI Slider object in World space Render Mode as a prefab for each animal, then set the slider’s value through a script every time the animal is fed.
