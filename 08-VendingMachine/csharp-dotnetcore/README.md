# Vending Machine Kata

In this exercise you will build the brains of a vending machine.  It will
accept money, make change, maintain inventory, and dispense products.  All the
things that you might expect a vending machine to accomplish.

The point of this kata to to provide a larger than trivial exercise that can be
used to practice TDD.  A significant portion of the effort will be in
determining what tests should be written and, more importantly, written next.

## Hardware Limitations

The different components of a vending machine communication via serial
communications, and don't have another way to query each other.  The separate
components are:

  * Coin Acceptor
  * Controller
  * Selector Button Panel
  * Display - These are *write-only* devices.  It is not possible to read from the device.
  * Product Dispenser
  * Product Sensor (to see if stock is present)

A serial bus class has been provided which works much like an actual serial
interface.  It has a Send() and a Recv() method.  What is sent can be read via
Recv().  This will eliminate the need for most mocks.


## Features

### Accept Coins
  
_As a vendor_  
_I want a vending machine that accepts coins_  
_So that I can collect money from the customer_  

The vending machine will accept valid coins and reject invalid ones.  When a
valid coin is inserted the amount of the coin will be added to the current
amount and the display will be updated.  When there are no coins inserted, the
machine displays INSERT COIN.  Rejected coins are placed in the coin return.

Assume that your vending machine will be operating near the U.S. border with
Canada, and currency of both countries will be present.  Your machine should
accept only U.S. or only Canadian coins of 5 cents or higher.  You may choose
to accept dollar coins or not.

Your machine should always reject euro coins or the Canadian twonie, which feel
superficially like a U.S. quarter.

*NOTE:* Coin acceptors do not know about quarters, nickels, dimes, or game
tokens.  They distinguish coins by a combination of diameter and weight.  Your
code should reflect that for determining what kind of coin has been inserted.
Most commercially available coin accepters can be programmed to accept any kind
of coin, including arcade tokens.


### Select Product

_As a vendor_  
_I want customers to select products_  
_So that I can give them an incentive to put money in the machine_  

There are three products: cola for $1.00, chips for $0.50, and candy for $0.65.
When the respective button is pressed and enough money has been inserted, the
product is dispensed and the machine displays THANK YOU for a few seconds.  After
the THANK YOU message is dismissed, it will display INSERT COIN and the current amount will be set
to $0.00.  If there is not enough money inserted then the machine displays
PRICE and the price of the item and subsequent checks of the display will
display either INSERT COIN or the current amount as appropriate.

Note: it is possible to receive coins while "THANK YOU" is being displayed.

### Make Change

_As a vendor_  
_I want customers to receive correct change_  
_So that they will use the vending machine again_  

When a product is selected that costs less than the amount of money in the
machine, then the remaining amount is placed in the coin return.

### Return Coins

_As a customer_  
_I want to have my money returned_  
_So that I can change my mind about buying stuff from the vending machine_  

When the return coins button is pressed, the money the customer has placed in
the machine is returned and the display shows INSERT COIN.

### Sold Out

_As a customer_  
_I want to be told when the item I have selected is not available_  
_So that I can select another item_  

When the item selected by the customer is out of stock, the machine displays
SOLD OUT.  If the display is checked again, it will display the amount of money
remaining in the machine or INSERT COIN if there is no money in the machine.

### Exact Change Only

_As a customer_  
_I want to be told when exact change is required_  
_So that I can determine if I can buy something with the money I have before inserting it_  

When the machine is not able to make change with the money in the machine for
any of the items that it sells, it will display EXACT CHANGE ONLY instead of
INSERT COIN.
