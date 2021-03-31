GoldBadgeConsoleChallenge

The solution in this repository holds 3 separate console applications:

1)Cafe Menu Editing Application
2)Insurance Claims Processing and Editing Application
3)Insurance Email Editing Application

Below, you'll find the assignment parameters for each console application, along with my notes in regards to the functionality and build of each.

===============================================================

ASSIGNMENT 1: Komodo Cafe Menu

Komodo cafe is getting a new menu. The manager wants to be able to create new menu items, delete menu items, and receive a list of all items on the cafe's menu. She needs a console app.

The Menu Items:
A meal number, so customers can say "I'll have the #5"
A meal name
A description
A list of ingredients,
A price

Your Task:
Create a Menu Class with properties, constructors, and fields.
Create a MenuRepository Class that has methods needed.
Create a Test Class for your repository methods. (You don't need to test your constructors or objects, just your methods)
Create a Program file that allows the cafe manager to add, delete, and see all items in the menu list.

Notes:
We don't need to be able to update items right now.

====Developer Notes:

Within the solution, this assignment can be found under _01_Cafe.ConsoleApp, _01_Cafe.Repository, and _01_Cafe.UnitTest.

By running programUI, you will be able to view the full menu, add meals to the menu, and delete meals from the menu. A function to update menu items was not included as it was not required by the assignement.

When searching for a meal, be sure to search by meal name and not by number.

===============================================================

ASSIGNMENT 2: Komodo Claims Department

Komodo has a bug in its software and needs some new code.

The Claim has the following properties:
ClaimID
ClaimType
Description
ClaimAmount
DateOfIncident
DateOfClaim
IsValid
Komodo allows an insurance claim to be made up to 30 days after an incident took place. If the claim is not in the proper time limit, it is not valid.

A ClaimType could be the following:
Car
Home
Theft
 

The app will need methods to do the following:
Show a claims agent a menu:
Choose a menu item:
1. See all claims
2. Take care of next claim
3. Enter a new claim
For #1, a claims agent could see all items in the queue listed out like this:

ClaimID	Type	Description	Amount	DateOfAccident	DateOfClaim	IsValid
1	Car	Car accident on 465.	$400.00	4/25/18	4/27/18	true
2	Home	House fire in kitchen.	$4000.00	4/11/18	4/12/18	true
3	Theft	Stolen pancakes.	$4.00	4/27/18	6/01/18	false
For #2, when a claims agent needs to deal with an item they see the next item in the queue.

Here are the details for the next claim to be handled:
ClaimID: 1
Type: Car
Description: Car Accident on 464.
Amount: $400.00
DateOfAccident: 4/25/18
DateOfClaim: 4/27/18
IsValid: True
Do you want to deal with this claim now(y/n)? y
When the agent presses 'y', the claim will be pulled off the top of the queue. If the agent presses 'n', it will go back to the main menu.

For #3, when a claims agent enters new data about a claim they will be prompted for questions about it:

Enter the claim id: 4
Enter the claim type: Car
Enter a claim description: Wreck on I-70.
Amount of Damage: $2000.00
Date Of Accident: 4/27/18
Date of Claim: 4/28/18
This claim is valid.
 

Your goal is to do the following:
1. Create a Claim class with properties, constructors, and any necessary fields.
2. Create a ClaimRepository class that has proper methods.
3. Create a Test Class for your repository methods.
4. Create a Program file that allows a claims manager to manage items in a list of claims.

====Developer Notes:

Within the solution, this assignment can be found under _02_Claims.ConsoleApp, _02_Claims.Repository, and _02_Claims.UnitTest.

By running programUI, you will be able to view all claims, pull next claim from queue for processing, and enter new claims. An update claim function is not present, as it was not part of the assignment requirements. The application will notify you if the claim is valid nor invalid, based off the 30 day deadline between incident and claim date.

===============================================================

ASSIGNMENT 3: Komodo Insurance Email Problem

Komodo Insurance is trying to send an email to everyone in the world. They want to share some of their great deals with current, past, and potential customers.

For their current customers, they want to send an appreciation email, something that says this:
"Thank you for your work with us. We appreciate your loyalty. Here's a coupon."

For past customers, they want to send a note that says something like this:
"It's been a long time since we've heard from you, we want you back".

For potential customers who have never worked with Komodo, they want to send an email that simply states what deals Komodo is currently offering. It would be something like this:
"We currently have the lowest rates on Helicopter Insurance!"

Along with defining the proper class for a customer, your task will be to make an application that allows administrators to do CRUD methods: create, read, update, and delete details about individual customers.

List View:
In addition to CRUD options, an administrator needs to show all customers in alphabetical order in a list like this:

FirstName  LastName  Type        Email
Jake        Smith     Potential   We currently have the lowest rates on Helicopter Insurance!
James       Smith     Current     Thank you for your work with us. We appreciate your loyalty. Here's a coupon.
Jane        Smith     Past        It's been a long time since we've heard from you, we want you back
Be sure to Unit Test your Repository methods.

Out of scope:
Actually sending an email. We are just creating the string for the email.

====Developer Notes:

Within the solution, this assignment can be found under _03_Greeting.ConsoleApp, _03_Greeting.Repository, and _03_Greeting.UnitTest.

By running programUI, you will be able to create a new customer entry, view customer greeting list in alphabetical order, search a customer by name, update a customer profile, delete a customer from the greeting list, and prepare an email to either the full greeting list or email a single customer. As you will see, emails cannot actually be sent.

When searching for a customer, be sure to type their full name.
