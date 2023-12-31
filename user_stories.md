# User stories

Priorization: 
- mandatory (M)
- optional (O)
- nice-to-have (N)

## Story#1
As a user, I want to be able to place objects in my space of living using a camera on my phone.
- ~~1.1 the app opens in both IOS and Android (M)~~ *Only Android.*
- [x] 1.2 the app opens a camera view (M)
- [x] 1.3 the app inserts a 3d object into the view (M)
- [x] 1.4 the object can be moved around and rotated in the view (M)

## Story#2A (Minimum)
As a user, I want to be able to resize AR -objects in my environment.
- [x] 2A.1 objects in the app are resizeable (O) *(Was implemented in the beginning, 
but eventually scrapped from the final product since it is good that the furniture objects stay in their original size.)*

## Story#2B (Desirable)
As a user, I want to be able to see the object in the real-life scale.
- [x] 2B.1 the application scans the room for measurements (O) 
- ~~2B.2 the object is scaled according to the room's scale (O)~~ *Object has its original scale.*

## Story#3
As a user, I want to use a tool to find objects to place in the AR environment.
- [x] 3.1 the user can choose from different 3d objects (M)
- ~~3.2 the user can search objects by category (O)~~ *Left open as an issue.*
- ~~3.3 the user can filter or rearrange the search results by price, etc. (N)~~ *Left open as an issue.*
- [x] 3.4 the user can select objects from a list. (O)
- [x] 3.5 the user can navigate between scenes using an arrow button. (O)

## Story#4
As a user, I want to be able to anchor multiple objects in my environment.
- [x] 4.1 the app stores the location of the placed object (N)
- [x] 4.2 another object can be added into the view, without the previous object disappearing (N)
- [x] 4.3 the user is able to delete an object from the view (N)
- ~~4.4 the user is able to clear all objects from the view (N)~~ *Extra feature, scrapped.*

## Story#5
As a user, I want the objects to anchor to the floor, so that the object placement looks and feels realistic.
- [x] 5.1 the app recognizes different surfaces in the camera view (M)
- [x] 5.2 the object anchors to the floor (M)
- [x] 5.3 the application creates a new plane to anchor game objects to (O)

## Story#6
As a user, I want to be able to take a picture of the view with the placed object(s).
- ~~6.1 the app has a camera button, which takes a screenshot of the view (N)~~ *Left open as an issue.*
- ~~6.2 the photo is saved in the phone's memory (N)~~ *Left open as an issue.*
