SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE SP_Users_Insert
	@firstName VARCHAR(255) = NULL,
	@lastName VARCHAR(255) = NULL,
	@email VARCHAR(155) = NULL,
	@password VARCHAR(255) = NULL,
	@idRol INT = NULL
AS
SET NOCOUNT ON;
BEGIN
	BEGIN TRY
		BEGIN
			DECLARE @SCOPEIDENTITY INT;
			INSERT INTO users (firstName, lastName, email, password, systemDate, status)
			VALUES(@firstName, @lastName, @email, @password, getdate(), 1);
				SET @SCOPEIDENTITY = SCOPE_IDENTITY();
				IF @idRol != 0
					INSERT INTO userRol(idUser, idRol)
						VALUES(@SCOPEIDENTITY, @idRol);
							SELECT @SCOPEIDENTITY AS idUser
		END
	END TRY
		BEGIN CATCH
			SELECT ERROR_MESSAGE() AS ERROR,
				ERROR_NUMBER() AS ERROR_NRO
		END CATCH;
END
