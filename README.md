# spatialrpg-server
Server for spatial rpg game.

## Routes
This server uses a web api for communicating with game clients. All communication to/from the web service is done using JSON. The api has the following routes available:

`GET /api/server`
Returns information about the server including version number. Clients should verify that the server version matches the version expected by the client.

`POST /api/user/authentication`
Authenticates a user login. Expects user and password fields in body. Returns session token. Session token must be included in message header for all protected routes.

`POST /api/user/new`
Creates a new user account. User information expected in body.

### Protected Routes
All routes below this point require the user to be authenticated and to pass a valid token in the message header.

`POST /api/user/logout`
Kills the user session for the provided token, logging out the user.

`GET /api/user/:id`
Get information on a specific user.

`POST /api/user/update/:id`
Update the user's information. User token must match user you are updating.

`POST /api/user/position/:id`
Update the user's position.  User token must match user you are updating.

`GET /api/party/:userid`
Get the monsters in the user's party. User token must match user id provided.

`POST /api/party/remove/:userid/:monsterid`
Remove a monster from the user's party. User token must match user id provided. Monster must be owned by user and be in user's party.

`POST /api/party/add/:userid/:monsterid`
Add a monster to a user's party. User token must match user id provided. Monster must be owned by user and not already in user's party.

`POST /api/encounter/new/:userid/:encountertypeid`
Creates a new encounter of a specific monster at a user's position. Development only route.

`GET /api/encounter/:id`
Get information on a specific encounter.

`POST /api/encounter/action/:id`
User action during an encounter. Action information expected in body.

`GET /api/monster`
Returns list of all possible kinds of monsters.

`GET /api/monster/user/:userid`
Returns a list of all the monsters owned by that user. User token must match user id provided.

`GET /api/monster/:id`
Get information on a specific monster. Monster must be owned by user matching token provided.


