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


## Vereisten PRI:
#### VUE.JS:
 * Ik zal een pagina aanmaken waar admins users kunnen maken, deleten, bekijken en aanpassen.
 * Een pagina waar je annotaties kan schrijven bij een move.
 * Games kunnen verwijderen en de naam kunnen aanpassen.
 * Voor de externe api ben ik nog niet zeker wat ik zal doen.
 
 
#### CRUD:
 * Create: Je kan games aanmaken.
 * Read: De app kan moves van een game uitlezen en weergeven aan de gebruiker
 * Update: Annoaties aanpassen en naam dat je gegeven hebt aan je game aanpassen.
 * Delete: Games dat je geüpload hebt kan je ook verwijderen.

#### CONTROLLERS:
 * GameController
 * userController
 * evenementenController (verzameling van schaak evenementen)
 * pionController
