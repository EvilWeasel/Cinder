# Szenario: Endpunkt für Passwort-Änderung
```typescript
class user {
	id: int,
	name: string,
	password: string
}
```
Ersetzen der Zielressource (eg. anhand der ID) mit einem komplett neuem Objekt
PUT /user/5
body:
```json
{
	"name": "günter",
	"password": "new-password"
}
```
Teilweise Modifizierung einer, oder mehrer Werte einer Zielressource (eg. anhand der ID)
PATCH /user/5
body:
```json
{
	"password": "new-password"
}
```
