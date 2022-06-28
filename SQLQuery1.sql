DECLARE @registrado bit, @mensaje VARCHAR(100)

EXEC sp_RegistrarUsuario 'pandikwa@gmail.com','83a1a3b43d874cd40cdbb5782d2373abee86def2501750347a57982e75c5a632', @registrado output, @mensaje output

SELECT @registrado
SELECT @mensaje
SELECT * FROM USUARIO;

EXEC sp_ValidarUsuario 'pandikwa@gmail.com', '83a1a3b43d874cd40cdbb5782d2373abee86def2501750347a57982e75c5a632'

--TRUNCATE TABLE USUARIO;