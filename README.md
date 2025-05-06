# Test notes

## AI Usage
The goal for the test was to implement an "Undo Move" feature. Since it was specified that the Solitaire game itself was not the focus and that a minimal carad movement setup would work, I used chat-gpt4 to quickly create a drag and drop card system. That code would be changed and adapted later, but it helped speed up the development.

The prompt was simple: 

_"make me a unity 3d project. It has to be a solitaire game. Cards needs to be able to be dragged and dropped between stacks."_

It provided what is shown in commit d59eedb: “Added AI-prvided code for fast draggable cards and dropzones.” 

Besides this, I used Visual Studio Code + Copilot, which is an AI assistant that provides very helpful suggestions. I can't list all the uses I did since there are a lot - it's very useful, specially if you name your variables / functions / classes in a way that it can infer what you are trying to do. Still, the generated code still needs to be thoroughly checked because it sometimes suggests unoptimal or just plain wrong things.

# Technical decisions

## Undo feature

I implemented the undo feature with a Command pattern. I always find it useful to implement undo features like this, since it keeps the operation and its counterpart in its own class, making it easier to maintain and avoiding changes to other classes - respecting SRP. It also decouples the "client" class from the "operator" class, helping further with SRP.

Since I implemented it using interfaces, it is also extensible: adding new Commands would not affect any previous code. This means OCP is respected.

Also, encapsulating a command in a class fits well with the Model-View-XZY variants that I value using.

The business logic in this example is mostly contained in the IPile implementations - currently NoRulesPile. I decided to have the Piles - and not the Cards - hold most of the logic because they're better suited to hold the future logic that would come in a full Solitaire game. Checking if a pile should receive a card is the logic that would surely have to be implemented, and the Piles are the ones with all the info. This of course could change depending on where the gameplay is headed, but this is my assumption with the information I have right now.

# MVC architecture

I decided to add a quick implementation of MVC since it would take me very little time and it made the code a lot more modular and easier to navigate. 
- This implementation of MVC uses the Controller as the nexus between the Models and the Views.
- It receives user requests through the View, which get processed as Use Cases.
- In this example, use cases where defined in functions within the Controller, but in a more complex project, they would be isolated into their own classes.
- The controller retrieves the information it needs to process the request and tells the models to process it - business logic and data reside in the model.
- If any data needs to get returned to the user, it tells the Views to show the results.
- Presentation logic like movements and parenting is contained in the Views.

There are many flavors of MVC/MVVM/MVP - regardless of which one, I feel it's a good practice that makes separates responsibilities, makes navigating unfamiliar code a lot easier, and thus makes it a lot easier to maintain.

# Tests

I set up Assembly Definition Files and linked them (including TMPro). This was in order to very quickly add a test suite to showcase that abstractions are important. This is specially true for the Models in an MVC, which are the ones holding the business logic and data. 

The tests in the project are extremely simple - I actually asked Copilot to write them for me - because the tests themselves were not my goal. My goal was showing that the classes are abstracted correctly and adding tests to the project would therefore be simple.

# Future improvements

A plethora of improvements could be added to the project. This would be mostly driven by the product and business needs, but for sake of suggestions, I will list some here:
- Complete Solitaire features
- Adding new IPile classes with more restrictions
- Adding default card dealings to start with some initial cards
- More tests
- Better visuals - Suits icons would be first
- Deck Editor in Unity - for this project I assumed a normal deck, but maybe we would want custom decks. Would be easy to do with a custom editor
- Save/load game
- etc.

# Closing

I hope you enjoyed this explaination and I am looking forward to discussing it with you!

