# Algemene beschrijving:
Voor het IMI project zou ik graag een applicatie willen maken 
waar je schaakgames kan uploaden naar je app via het uploaden van
een pgn file (https://nl.wikipedia.org/wiki/Portable_Game_Notation) 
of het copy pasten van de tekst van deze pgn file in de app.
In deze pgn file staan alle moves dat gespeeld zijn voor die bepaalde
schaakgame en staat ook de uitslag van deze game. 
Eenmaal deze geüpload is, wil ik het mogelijk maken voor de
gebruiker om zijn games opnieuw te kunnen zien binnen de app en bij elke 
move dat hij wilt annotaties bij kan schrijven. Ook zou ik een pagina
willen maken waar de gebruiker al de statistieken van zijn geüploade games
kan zien. bv: Aantal gespeelde games, % gewonnen/verloren/gelijke games, ...
Een gebruiker moet ingelogd zijn om de applicatie te gebruiken.


## Vereisten PIN:
#### CRUD PAGINA:
 * Een pagina voor de admin dat gebruikers kan deleten, aanpassen en zijn games/statistics mee kan zien.
 * Een pagina waar je een overzicht krijgt van games dat een bug hebben. Als er geen bug in een bepaalde 
 game zit kan de admin op een knop klikken om dit weg te doen.
 * Een pagina waar een admin een overzicht krijgt van alle events, events kan aanmaken, editeren en verwijderen.
 
#### NIET-CRUD PAGINA:
 * Een pagina waar je de statistieken van de speler kan zien. Bijvoorbeeld: het aantal gespeelde games en 
 het percentage gewonnen/verloren en  gelijke games, de meeste gebruikte openings van een bepaalde speler 
 met daarbij het percentage gewonnen/verloren/gelijke games.
 * Ik zal ook proberen met signalR een schaakgame te maken. Dit spel gaat waarschijnlijk niet 100% volgens alle regels
 van schaken zijn.
