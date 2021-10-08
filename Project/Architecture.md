# pschopping_Boodschappen

## Architeccture 
/Note: zie ook Boodschappen.png voor een diagram van de app. 

De applicatie is opgebouwd a.d.h.v het MVC model. Er is daarnaast een database laag toegevoegd. 
De backend is gemaakt in C#, de frontend maakt gebruik van REACT. 
De database maakt gebruik van MySQL. 

## Layers

*Database layer: Database met drie tabellen; 
1) Recepten, bevat alle ingevoerde recepten. 
2) Aanbiedingen, bevat alle aanbiedingen. 
3) Inhouse, bevat alle ingevoerde producten die al in huis zijn. 

*Model 
Bevat alle code die gebruikt wordt om berekening uit te voeren op de gegegevens van de tabellen. 
De berekening van de percentages aanbiedingen wordt in een van deze classes geregeld. 

*Controllers
Alle controllers die de verbinding tussen de frontend en de backend. 
Dit omvat zowel de opvraag van gegevens uit de tabellen als de opvraag van berekeningen. 

De controllers maken gebruik van een of meerdere data transfer objects. 

*View
Volledige frontend van de applicatie. Bevat alle pagina's en functies die in de frontend gebruikt worden. 


*Unit tests
De unit tests zijn opgesplits in twee catergorien, de model tests en controller tests. 

*Folders 
De code voor de backend en frontend staat in de projectreact folder. 
De unit tests staan in de aparte test folders. 

De applicatie kan gestart worden via ProjectReact.sln 