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


## Vereisten MDE:
### WIRE FRAMES:
https://xd.adobe.com/view/0bcb3d6e-f527-4916-b84e-95a61c445ef6-5e98/

#### PLATFORMEN:
 * UWP
 * Android

#### CRUD:
 * Create: 
	* Alle gebruikers zullen games kunnen toevoegen
	* Administrators zullen events kunnen toevoegen
	* Administrators kunnen nieuwe openings toevoegen
 * Read: 
	* De app kan moves van een game uitlezen en weergeven aan de gebruiker
	* Iedereen zal een overzicht kunnen zien van al zijn games
	* Iedereen kan een overzicht zien van verschillende openings
	* Iedere gebruiker zal een overzicht van events kunnen zien
 * Update: 
	* Annoaties aanpassen en naam dat je gegeven hebt aan je game aanpassen.
	* Administrators kunnen data van events aanpassen
 * Delete: 
	* Games dat je geüpload hebt kan je ook verwijderen.
	* Administrators kunnen events verwijderen

### NATIVE SERVICES:
 * Locatie bijhouden van een gebruiker.
 * Een profile picture om een gebruiker te voorzien van profielfoto.
 
### UNIT TESTS:
 * Unit tests om te testen dat de pgn correct uitgelezen wordt.
 * Tests om te controleren of moves doen wat je wilt dat ze doen.
