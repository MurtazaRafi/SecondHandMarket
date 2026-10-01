<img width="413" height="314" alt="image" src="https://github.com/user-attachments/assets/34535c1d-0fad-4964-8265-92a74a985fff" /># Second Hand Market
Experimented with building a Web Application similar to Swedish second hand market Blocket.
## Pages

## One interesting problem I solved in this project 
Something difficult and interesting I solved in this project was with the flexible picture upload problem, when putting a new advertisment.
### The Problem
When having a couple of pictures, lets say 5-6 and we want to remove a picture from the beginning - this creates a problem, because we want all the pictures to move left one step. But this can't be done with list or array datatype for example.
Here the importance of using the right data type was extra important and something I learned.

#### Demonstrating the problem
When wanting to put an advertisement (by first clicking 'create' button) one encounters the problem while putting several pictures like below:

<img width="713" height="578" alt="image" src="https://github.com/user-attachments/assets/70670d33-efa6-4e42-8666-1477185e0249" />

And adding two pictures:
<img width="413" height="314" alt="image" src="https://github.com/user-attachments/assets/06abd074-35c8-4b9a-8691-210d3d4d1151" />

Then it wouldn't be possible to 'dynamically' remove the first one so that second (or rest of the pictures) moves one step to the left. This problem occcurs with arrays and lists.

### The Solution - Use linked-list data type instead
The idea of using a linked-list is very appropriate here because it is a flexible data type and all the pictures arranges appropriately.

#### Demonstrating the solution using linked-list data type for the pictures
Add several pictures:

<img width="409" height="346" alt="image" src="https://github.com/user-attachments/assets/551c8057-1859-4261-9813-52f85a4bf3ce" />

Remove one:

<img width="415" height="338" alt="image" src="https://github.com/user-attachments/assets/1503fd5b-c1d9-4bb6-91cb-2b474666762e" />

Every picture moves left one step as it should behave. Also the "add image"/"lägg bild" moves one step to the left.
