# Hedron-Toss-VR
This is a code sample from my VR game, Hedron Toss. These classes highlight some of the core game development patterns and techniques used to drive the game.

Summary Notes:

The Hedron follows the [State design pattern](https://en.wikipedia.org/wiki/State_pattern), representing a Finite State Machine. The core gameflow is dictated by the state of the hedron- was it a valid throw? was it caught? did it bounce? Using this technique prevented a sea of boolean variables and errors from uncaught edge cases. Each state also broadcasts Unity Events to drive the GameManager and other logic without having to riddle the finite state machine with external references.

The controller input utilizes the [Command pattern](https://en.wikipedia.org/wiki/Command_pattern) to decouple VR controller input from any direction actions. This was primarily beneficial in seamlessly remapping controls to actions (which happened a lot throughout development), and in providing more flexibility when adding to actions downstream.
