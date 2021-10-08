# pschopping_Boodschappen

## Algemeen 

De appliticatie heeft als primair doel om een match te maken tussen (favoriete) recepten en huidige aanbiedingen. 
De gebruiker voert zijn of haar recepten in in de applicatie. Vervolgens kan de gebruiker aanbiedingen invoeren en eventueel producten die al in huis zijn. 

De app geeft vervolgens een lijst met recepten die (deels) gemaakt kunnen worden met de aanbiedingen. 
Deze lijst geeft aan hoeveel ingredienten in de aanbieding zijn, welk percentage van de ingredienten in de aanbieding zijn en al in huis zijn en de gemiddelde korting. 
Per recept kan vervolgens gekeken worden waar de ingredienten in de aanbieding zijn en hoe vaak de aanbieding gekocht moet worden. 

## Install instructions 

De backend van de applicatie is geschreven in C# met Visual Studio, de front-end is gemaakt met REACT. 
Voor de databases is MySQL gebruikt. 

## Unit Tests 

Er zijn twee categorieen unit tests gebruikt. 

1) Domain Unit Tests
Deze testen de berekening die uitgevoerd worden op de ingevoerde gegevens. 
Het doel is testen of de berekening juist uitgevoerd worden, bijvoorbeeld of de percentages correct berekend worden. 

2) API Tests
Deze tests hebben vooral als doel om te controleren of de juiste gegevens geleverd worden door de tabellen van de databases. 
Implicit testen deze ook of de syntax van de SQL statements correct zijn. 