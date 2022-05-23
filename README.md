# DD-internship
A simple console app to manange contents of a shopping cart and generate invoices. The user is presented to a list of products from which he has the option to choose. After adding an item in the cart an invoice is generated. The total costs, fees and the potential discounts are all computed upon this invoices generation. The app is build using a layered arhitecture UI/Service/Repos/Models and contains the following classes: UI- deals with the user interaction, sends the input from the user to the service layer and prints the output of the service layer in the console Service- interacts directly with the repos (product catalog/shopping cart) ShoppingCart- List of Product objects and a dictionary to store each items count in the cart ProductCatalog- List of predefined Product objects ShippingRate- Static class with enums reffering to Country codes. it also uses a dictionary to return a specific country shipping rate Product-class describing an item (name, price,country of origin, weight) Invoice- based on the contents of the shopping cart this class comutes the total costs,fees and discounts of that cart Program- main program

How to use the app: On start-up, the product catalog is displayed The user can choose between 2 options:

Add an item
Exit
